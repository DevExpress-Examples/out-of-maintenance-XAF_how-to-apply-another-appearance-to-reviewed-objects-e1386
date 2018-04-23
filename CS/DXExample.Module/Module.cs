using System;
using System.Collections.Generic;

using DevExpress.ExpressApp;
using System.Reflection;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.ConditionalFormatting;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Model.Core;
using System.Drawing;


namespace DXExample.Module {
	public class ViewsNodesGeneratorUpdater : ModelNodesGeneratorUpdater<ModelViewsNodesGenerator> {
		public override void UpdateNode(ModelNode node) {
			foreach(IModelView view in (IModelViews)node) {
				if(view is IModelListView
					&& view is IModelConditionalFormatting
					&& typeof(BaseClass).IsAssignableFrom(((IModelListView)view).ModelClass.TypeInfo.Type)
					) {
					IModelConditionalFormattingRule rule = ((IModelConditionalFormatting)view).ConditionalFormatting.AddNode<IModelConditionalFormattingRule>("ByUser");
					rule.Criteria = "Users[Oid = '@CurrentUserID'].Count > 0";
					IModelConditionalFormattingTarget target = rule.AddNode<IModelConditionalFormattingTarget>("Foreground");
					target.Color = Color.Gray;
				}
			}
		}
	}

    public sealed partial class DXExampleModule : ModuleBase {
        public DXExampleModule() {
            InitializeComponent();
        }
		public override void AddGeneratorUpdaters(ModelNodesGeneratorUpdaters updaters) {
			base.AddGeneratorUpdaters(updaters);
			updaters.Add(new ViewsNodesGeneratorUpdater());
		}
    }
}
