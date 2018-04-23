Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Imports DevExpress.ExpressApp
Imports System.Reflection


Namespace DXExample.Module
	Public NotInheritable Partial Class DXExampleModule
		Inherits ModuleBase
		Public Sub New()
			InitializeComponent()
		End Sub
		Public Overrides Sub UpdateModel(ByVal dictionary As Dictionary)
			MyBase.UpdateModel(dictionary)
			For Each listViewNode As DictionaryNode In dictionary.RootNode.FindChildNode("Views").GetChildNodes("ListView", False)
				Dim className As String = listViewNode.GetAttributeValue("ClassName")
				If GetType(BaseClass).IsAssignableFrom(XafTypesInfo.Instance.FindTypeInfo(className).Type) Then
					Dim ruleNode As DictionaryNode = listViewNode.AddChildNode("ConditionalFormatting").AddChildNode("Rule")
					ruleNode.SetAttribute("ID", "ByUser")
					ruleNode.SetAttribute("Criteria", "Users[Oid = '@CurrentUserID'].Count > 0")
					Dim targetNode As DictionaryNode = ruleNode.AddChildNode("Target")
					targetNode.SetAttribute("Color", "Gray")
					targetNode.SetAttribute("Name", "Foreground")
				End If
			Next listViewNode
		End Sub
	End Class
End Namespace
