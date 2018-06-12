'**************************** Module Header ******************************\
' Module Name:  UndoChangesHelper.vb
' Project:      VBEFUndoChanges
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to undo the changes in Entity Framework.
' This file contains the methods that undo the changes in different levels 
' using DbContext or ObjectcContext.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports System.Linq
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Reflection

Namespace VBEFUndoChanges
    Public Module UndoChangesHelper
#Region "UndoOperationsOfDbContext"
        ''' <summary>
        ''' This method undoes the changes in Context level using DbContext.
        ''' </summary>
        ''' <param name="context">Undo the changes in this context</param>
        <System.Runtime.CompilerServices.Extension()> _
        Public Sub UndoDbContext(ByVal context As DbContext)
            If context Is Nothing Then
                Throw New ArgumentException()
            End If

            ' Undo the changes of the all entries.
            For Each entry As DbEntityEntry In context.ChangeTracker.Entries()
                Select Case entry.State
                    ' Under the covers, changing the state of an entity from 
                    ' Modified to Unchanged first sets the values of all 
                    ' properties to the original values that were read from 
                    ' the database when it was queried, and then marks the 
                    ' entity as Unchanged. This will also reject changes to 
                    ' FK relationships since the original value of the FK 
                    ' will be restored.
                    Case EntityState.Modified
                        entry.State = EntityState.Unchanged
                    Case EntityState.Added
                        entry.State = EntityState.Detached
                        ' If the EntityState is the Deleted, reload the date from the database.  
                    Case EntityState.Deleted
                        entry.Reload()
                    Case Else
                End Select
            Next entry
        End Sub

        ''' <summary>
        ''' This method undoes the changes in DbEntities level using DbContext.
        ''' </summary>
        ''' <typeparam name="T">Type of the DbEntities</typeparam>
        ''' <param name="context">Undo the changes in this context</param>
        <System.Runtime.CompilerServices.Extension()> _
        Public Sub UndoDbEntities(Of T As Class)(ByVal context As DbContext)
            If context Is Nothing Then
                Throw New ArgumentException()
            End If

            ' Undo the changes of the T type entries.
            For Each entry As DbEntityEntry(Of T) In context.ChangeTracker.Entries(Of T)()
                Select Case entry.State
                    Case EntityState.Modified
                        entry.State = EntityState.Unchanged
                    Case EntityState.Deleted
                        entry.Reload()
                    Case EntityState.Added
                        entry.State = EntityState.Detached
                    Case Else

                End Select
            Next entry
        End Sub

        ''' <summary>
        ''' This method undoes the changes in DbEntity level using DbContext.
        ''' </summary>
        ''' <param name="context">Undo the changes in this context</param>
        ''' <param name="entity">Undo the changes of the Entity</param>
        <System.Runtime.CompilerServices.Extension()> _
        Public Sub UndoDbEntity(ByVal context As DbContext, ByVal entity As Object)
            If context Is Nothing OrElse entity Is Nothing Then
                Throw New ArgumentException()
            End If

            ' Get the entry of the entity, and then undo the changes.
            Dim entry As DbEntityEntry = context.Entry(entity)
            If entry IsNot Nothing Then
                Select Case entry.State
                    Case EntityState.Modified
                        entry.State = EntityState.Unchanged
                    Case EntityState.Deleted
                        entry.Reload()
                    Case EntityState.Added
                        entry.State = EntityState.Detached
                    Case Else
                End Select
            End If
        End Sub

        ''' <summary>
        ''' This method undoes the changes in DbEntity Property level using DbContext.
        ''' </summary>
        ''' <param name="context">Undo the changes in this context</param>
        ''' <param name="entity">Undo the changes in the Entity</param>
        ''' <param name="propertyName">Undo the changes of the Property</param>
        <System.Runtime.CompilerServices.Extension()> _
        Public Sub UndoDbEntityProperty(ByVal context As DbContext, ByVal entity As Object, ByVal propertyName As String)
            If context Is Nothing OrElse entity Is Nothing OrElse propertyName Is Nothing Then
                Throw New ArgumentException()
            End If

            Try
                Dim entry As DbEntityEntry = context.Entry(entity)
                If entry.State = EntityState.Added OrElse entry.State = EntityState.Detached Then
                    Return
                End If

                ' Get and Set the Property value by the Property Name.
                Dim propertyValue As Object = entry.OriginalValues.GetValue(Of Object)(propertyName)
                entry.Property(propertyName).CurrentValue = entry.Property(propertyName).OriginalValue
            Catch
                Throw
            End Try
        End Sub
#End Region


#Region "UndoOperationsOfObjectContext"
        ''' <summary>
        ''' This method undoes the changes in Context level using ObjectContext.
        ''' </summary>
        ''' <param name="context">Undo the changes in this context</param>
        <System.Runtime.CompilerServices.Extension()> _
        Public Sub UndoObjectContext(ByVal context As ObjectContext)
            If context Is Nothing Then
                Throw New ArgumentException()
            End If

            ' If the states of the entities are Modified or Deleted, refresh the date from the database.
            Dim collection As IEnumerable(Of Object) = From e In context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified Or EntityState.Deleted)
                                                       Select e.Entity
            context.Refresh(RefreshMode.StoreWins, collection)

            ' If the states of the entities are Added, detach these new entities.
            Dim AddedCollection As IEnumerable(Of Object) = From e In context.ObjectStateManager.GetObjectStateEntries(EntityState.Added)
                                                            Select e.Entity
            For Each addedEntity As Object In AddedCollection
                context.Detach(addedEntity)
            Next addedEntity
        End Sub

        ''' <summary>
        ''' This method undoes the changes in ObjectEntities level using ObjectContext.
        ''' </summary>
        ''' <typeparam name="T">Type of the ObjectEntites</typeparam>
        ''' <param name="context">Undo the changes in this context</param>
        ''' <param name="objectSets">Undo the changes in the objectSets</param>
        <System.Runtime.CompilerServices.Extension()> _
        Public Sub UndoObjectEntities(Of T As EntityObject)(ByVal context As ObjectContext, ByVal objectSets As ObjectSet(Of T))
            If context Is Nothing OrElse objectSets Is Nothing Then
                Throw New ArgumentException()
            End If

            Dim collection As IEnumerable(Of T) = From o In objectSets.AsEnumerable()
                                                  Where o.EntityState = EntityState.Modified OrElse o.EntityState = EntityState.Deleted
                                                  Select o
            context.Refresh(RefreshMode.StoreWins, collection)

            Dim AddedCollection As IEnumerable(Of T) = (
                From e In context.ObjectStateManager.GetObjectStateEntries(EntityState.Added)
                Select e.Entity).ToList().OfType(Of T)()
            For Each entity As T In AddedCollection
                context.Detach(entity)
            Next entity
        End Sub

        ''' <summary>
        ''' This method undoes the changes in ObjectEntity level using ObjectContext.
        ''' </summary>
        ''' <param name="context">Undo the changes in this context</param>
        ''' <param name="entity">Undo the changes of the entity</param>
        <System.Runtime.CompilerServices.Extension()> _
        Public Sub UndoObjectEntity(ByVal context As ObjectContext, ByVal entity As EntityObject)
            If context Is Nothing OrElse entity Is Nothing Then
                Throw New ArgumentException()
            End If

            If entity.EntityState = EntityState.Modified OrElse entity.EntityState = EntityState.Deleted Then
                context.Refresh(RefreshMode.StoreWins, entity)
            ElseIf entity.EntityState = EntityState.Added Then
                context.Detach(entity)
            End If
        End Sub

        ''' <summary>
        ''' This method undoes the changes in ObjectEntity Property level using ObjectContext.
        ''' </summary>
        ''' <param name="context">Undo the changes in this context</param>
        ''' <param name="entity">Undo the changes in the entity</param>
        ''' <param name="propertyName">Undo the changes of the Property</param>
        <System.Runtime.CompilerServices.Extension()> _
        Public Sub UndoObjectEntityProperty(ByVal context As ObjectContext, ByVal entity As EntityObject, ByVal propertyName As String)
            If context Is Nothing OrElse entity Is Nothing OrElse propertyName Is Nothing Then
                Throw New ArgumentException()
            End If

            Try
                ' Get the entry from the entity, so we can get the original values. And then we use the 
                ' reflection to set the property value of the entity.
                Dim entry As ObjectStateEntry = context.ObjectStateManager.GetObjectStateEntry(entity)
                If entry.State <> EntityState.Added AndAlso entry.State <> EntityState.Detached Then
                    Dim propertyValue As Object = entry.OriginalValues(propertyName)
                    Dim propertyInfo As PropertyInfo = entity.GetType().GetProperty(propertyName)
                    propertyInfo.SetValue(entity, propertyValue, Nothing)

                End If
            Catch
                Throw
            End Try
        End Sub
#End Region
    End Module


End Namespace
