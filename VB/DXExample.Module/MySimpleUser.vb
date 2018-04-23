Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace DXExample.Module
	Public Class MySimpleUser
		Inherits SimpleUser
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		<Association("BOs-Users"), Browsable(False)> _
		Public ReadOnly Property BOs() As XPCollection(Of BaseClass)
			Get
				Return GetCollection(Of BaseClass)("BOs")
			End Get
		End Property
	End Class

End Namespace
