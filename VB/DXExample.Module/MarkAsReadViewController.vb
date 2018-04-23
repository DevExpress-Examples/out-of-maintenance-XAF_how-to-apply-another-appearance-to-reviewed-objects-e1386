Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.SystemModule

Namespace DXExample.Module
	Public Class MarkAsReadViewController
		Inherits ViewController
		Public Sub New()
			TargetViewType = ViewType.DetailView
			TargetObjectType = GetType(BaseClass)
		End Sub
		Protected Overrides Overloads Sub OnActivated()
			MyBase.OnActivated()
			AddObjectToUserBOs((Not ObjectSpace.IsModified))
			AddHandler View.CurrentObjectChanged, AddressOf View_CurrentObjectChanged
		End Sub
		Private Sub View_CurrentObjectChanged(ByVal sender As Object, ByVal e As EventArgs)
			AddObjectToUserBOs((Not ObjectSpace.IsModified))
		End Sub
		Private Sub AddObjectToUserBOs(ByVal commitChanges As Boolean)
			Dim currentUser As MySimpleUser = ObjectSpace.GetObjectByKey(Of MySimpleUser)(SecuritySystem.CurrentUserId)
			Dim currentObject As BaseClass = CType(View.CurrentObject, BaseClass)
			If currentObject.Users.IndexOf(currentUser) = -1 Then
				currentObject.Users.Add(currentUser)
				If commitChanges Then
					ObjectSpace.CommitChanges()
				End If
			End If
		End Sub
	End Class
End Namespace