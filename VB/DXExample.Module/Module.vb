Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Imports DevExpress.ExpressApp
Imports System.Reflection
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.ConditionalFormatting
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.ExpressApp.Model.Core
Imports System.Drawing


Namespace DXExample.Module
	Public Class ViewsNodesGeneratorUpdater
		Inherits ModelNodesGeneratorUpdater(Of ModelViewsNodesGenerator)
		Public Overrides Sub UpdateNode(ByVal node As ModelNode)
			For Each view As IModelView In CType(node, IModelViews)
				If TypeOf view Is IModelListView AndAlso TypeOf view Is IModelConditionalFormatting AndAlso GetType(BaseClass).IsAssignableFrom((CType(view, IModelListView)).ModelClass.TypeInfo.Type) Then
					Dim rule As IModelConditionalFormattingRule = (CType(view, IModelConditionalFormatting)).ConditionalFormatting.AddNode(Of IModelConditionalFormattingRule)("ByUser")
					rule.Criteria = "Users[Oid = '@CurrentUserID'].Count > 0"
					Dim target As IModelConditionalFormattingTarget = rule.AddNode(Of IModelConditionalFormattingTarget)("Foreground")
					target.Color = Color.Gray
				End If
			Next view
		End Sub
	End Class

	Public NotInheritable Partial Class DXExampleModule
		Inherits ModuleBase
		Public Sub New()
			InitializeComponent()
		End Sub
		Public Overrides Sub AddGeneratorUpdaters(ByVal updaters As ModelNodesGeneratorUpdaters)
			MyBase.AddGeneratorUpdaters(updaters)
			updaters.Add(New ViewsNodesGeneratorUpdater())
		End Sub
	End Class
End Namespace
