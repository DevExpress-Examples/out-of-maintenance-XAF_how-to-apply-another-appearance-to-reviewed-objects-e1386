Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Namespace DXExample.Module
	Public Class MarkAsReadViewController
		Inherits ViewController
		Public Sub New()
			TargetViewType = ViewType.DetailView
			TargetObjectType = GetType(BaseClass)
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			If View.ObjectSpace.Session.IsNewObject(View.CurrentObject) Then
				AddHandler View.ObjectSpace.Committed, AddressOf ObjectSpace_Committed
			Else
				AddObjectToUserBOs()
			End If
		End Sub
		Private Sub ObjectSpace_Committed(ByVal sender As Object, ByVal e As EventArgs)
			AddObjectToUserBOs()
		End Sub
		Private Sub AddObjectToUserBOs()
			Dim currentUser As MySimpleUser = CType(SecuritySystem.CurrentUser, MySimpleUser)
			Dim currentObject As BaseClass = CType(View.CurrentObject, BaseClass)
			If currentUser.BOs.Lookup(currentObject.Oid) Is Nothing Then
				currentUser.BOs.Add(currentUser.Session.GetObjectByKey(Of BaseClass)(currentObject.Oid))
				currentUser.Save()
				currentUser.Session.CommitTransaction()
			End If
		End Sub
	End Class
End Namespace
