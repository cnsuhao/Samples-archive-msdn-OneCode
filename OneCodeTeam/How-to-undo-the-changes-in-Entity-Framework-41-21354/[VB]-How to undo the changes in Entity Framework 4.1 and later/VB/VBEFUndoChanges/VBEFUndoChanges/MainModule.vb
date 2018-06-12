'**************************** Module Header ******************************\
' Module Name:  MainModule.vb
' Project:      VBEFUndoChanges
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to undo the changes in Entity Framework.
' When we make the changes to the entities, we can use the SaveChanges Method 
' to update the entities in the database. But sometimes some of the changes 
' are wrong, and we need to rollback these changes. In this sample, we 
' demonstrate how to use ObjectContext and DbContext to undo the changes in 
' different levels.
' 1. Context Level;
' 2. Entity Set Level;
' 3. Entity Level;
' 4. Property Level.
' 
' This source is subject to the Microsoft Public License.
' See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL.
' All other rights reserved.
' 
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
'**************************************************************************/

Imports DBMySchool
Imports ObjMySchool

Namespace VBEFUndoChanges
    Friend Class MainModule
        Shared Sub Main(ByVal args() As String)
            Console.WriteLine("Undo Operations in the DbContext")
            UndoDbMySchool()
            Console.WriteLine("Press any key to continue.....")
            Console.WriteLine("=====================================================================")
            Console.ReadKey()


            Console.WriteLine("Undo Operations in the ObjectContext")
            UndoObjectMySchool()

            Console.WriteLine("Press any key to Exit.....")
            Console.ReadKey()
        End Sub

        ''' <summary>
        ''' This method demonstrates how to undo the changes in different levels using DbContext.
        ''' </summary>
        Private Shared Sub UndoDbMySchool()
            Console.WriteLine("Undo changes in DbContext")
            DbUndoChanges.UndoChangesInContext()
            Console.WriteLine()

            Console.WriteLine("Undo changes in DbEntities")
            DbUndoChanges.UndoChangesInEntities()
            Console.WriteLine()

            Console.WriteLine("Undo changes in DbEntity")
            DbUndoChanges.UndoChangesInEntity()
            Console.WriteLine()

            Console.WriteLine("Undo changes in DbEntityProperty")
            DbUndoChanges.UndoChangesInProperty()
            Console.WriteLine()
        End Sub

        ''' <summary>
        ''' This method demonstrates how to undo the changes in different levels using ObjectContext.
        ''' </summary>
        Private Shared Sub UndoObjectMySchool()
            Console.WriteLine("Undo changes in ObjectContext")
            ObjectUndoChanges.UndoChangesInContext()
            Console.WriteLine()

            Console.WriteLine("Undo changes in ObjectEntities")
            ObjectUndoChanges.UndoChangesInEntities()
            Console.WriteLine()

            Console.WriteLine("Undo changes in ObjectEntity")
            ObjectUndoChanges.UndoChangesInEnity()
            Console.WriteLine()

            Console.WriteLine("Undo changes in ObjectEntityProperty")
            ObjectUndoChanges.UndoChangesInProperty()
            Console.WriteLine()
        End Sub




    End Class
End Namespace
