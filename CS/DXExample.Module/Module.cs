using System;
using System.Collections.Generic;

using DevExpress.ExpressApp;
using System.Reflection;


namespace DXExample.Module {
    public sealed partial class DXExampleModule : ModuleBase {
        public DXExampleModule() {
            InitializeComponent();
        }
        public override void UpdateModel(Dictionary dictionary) {
            base.UpdateModel(dictionary);
            foreach (DictionaryNode listViewNode in dictionary.RootNode.FindChildNode("Views").GetChildNodes("ListView", false)) {
                string className = listViewNode.GetAttributeValue("ClassName");
                if (typeof(BaseClass).IsAssignableFrom(XafTypesInfo.Instance.FindTypeInfo(className).Type)) {
                    DictionaryNode ruleNode = listViewNode.AddChildNode("ConditionalFormatting").AddChildNode("Rule");
                    ruleNode.SetAttribute("ID", "ByUser");
                    ruleNode.SetAttribute("Criteria", "Users[Oid = '@CurrentUserID'].Count > 0");
                    DictionaryNode targetNode = ruleNode.AddChildNode("Target");
                    targetNode.SetAttribute("Color", "Gray");
                    targetNode.SetAttribute("Name", "Foreground");
                }
            }
        }
    }
}
