Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.ConditionalAppearance

Namespace DXExample.Module
	<Appearance("ByUsers", Criteria := "Users[Oid = CurrentUserId()].Count > 0", FontColor:="Gray", AppearanceItemType:="ViewItem", TargetItems:="*", Context:="ListView")> _
	Public Class BaseClass
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		<Association("BOs-Users"), Browsable(False)> _
		Public ReadOnly Property Users() As XPCollection(Of MySimpleUser)
			Get
				Return GetCollection(Of MySimpleUser)("Users")
			End Get
		End Property
	End Class

End Namespace
