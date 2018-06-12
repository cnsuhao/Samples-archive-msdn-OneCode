'**************************** Module Header ******************************\
' Module Name:  EFExtensionMethods.vb
' Project:      VBEFBetweenOperator
' Copyright (c) Microsoft Corporation.
' 
' This sample demonstrates how to implement the Between operation in Entity 
' Framework.
' This file includes the extension method that implements the Between operation.
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
Imports System.Linq.Expressions
Imports System.Reflection

Namespace VBEFBetweenOperator
    Public Module EFExtensionMethods
        ''' <summary>
        ''' Use the extension method to implement the Between operation in EF
        ''' </summary>
        ''' <typeparam name="TSource">Type of the entity</typeparam>
        ''' <typeparam name="TKey">Type of the return value</typeparam>
        ''' <param name="source">The entity used to apply the method</param>
        ''' <param name="keySelector">The lambda expression used to get the return value</param>
        ''' <param name="low">Low boundary of the return value</param>
        ''' <param name="high">High boundary of the return value</param>
        ''' <returns>return the IQueryable</returns>
        <System.Runtime.CompilerServices.Extension()> _
        Public Function Between(Of TSource, TKey As IComparable(Of TKey))(
                   ByVal source As IQueryable(Of TSource),
                   ByVal keySelector As Expression(Of Func(Of TSource, TKey)),
                   ByVal low As TKey, ByVal high As TKey) As IQueryable(Of TSource)
            ' Get a ParameterExpression node of the TSource that is used in the expression tree
            Dim sourceParameter As ParameterExpression = Expression.Parameter(GetType(TSource))

            ' Get the body and parameter of the lambda expression
            Dim body As Expression = keySelector.Body
            Dim parameter As ParameterExpression = Nothing
            If keySelector.Parameters.Count > 0 Then
                parameter = keySelector.Parameters(0)
            End If

            ' Get the Compare method of the type of the return value
            Dim compareMethod As MethodInfo = GetType(TKey).GetMethod("CompareTo", {GetType(TKey)})

            ' Expression.LessThanOrEqual and Expression.GreaterThanOrEqua method are only used in
            ' the numeric comparision. If we want to compare the non-numeric type, we can't directly 
            ' use the two methods. 
            ' So we first use the Compare method to compare the objects, and the Compare method 
            ' will return a int number. Then we can use the LessThanOrEqual and GreaterThanOrEqua method.
            ' For this reason, we ask all the TKey type implement the IComparable<> interface.
            Dim upper As Expression = Expression.LessThanOrEqual(
                Expression.Call(body, compareMethod, Expression.Constant(high)),
                Expression.Constant(0, GetType(Integer)))
            Dim lower As Expression = Expression.GreaterThanOrEqual(
                Expression.Call(body, compareMethod, Expression.Constant(low)),
                Expression.Constant(0, GetType(Integer)))

            Dim andExpression As Expression = Expression.And(upper, lower)

            ' Get the Where method expression.
            Dim whereCallExpression As MethodCallExpression = Expression.Call(
                GetType(Queryable),
                "Where",
                New Type() {source.ElementType},
                source.Expression,
                Expression.Lambda(Of Func(Of TSource, Boolean))(andExpression,
                        New ParameterExpression() {parameter}))

            Return source.Provider.CreateQuery(Of TSource)(whereCallExpression)
        End Function
    End Module
End Namespace
