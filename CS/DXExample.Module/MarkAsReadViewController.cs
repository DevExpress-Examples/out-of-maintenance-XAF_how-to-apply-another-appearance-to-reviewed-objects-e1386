using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.SystemModule;

namespace DXExample.Module {
    public class MarkAsReadViewController : ViewController {
        public MarkAsReadViewController() {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(BaseClass);
        }
        protected override void OnActivated() {
            base.OnActivated();
            AddObjectToUserBOs(!ObjectSpace.IsModified);
            View.CurrentObjectChanged += new EventHandler(View_CurrentObjectChanged);
        }
        void View_CurrentObjectChanged(object sender, EventArgs e) {
            AddObjectToUserBOs(!ObjectSpace.IsModified);
        }
        private void AddObjectToUserBOs(bool commitChanges) {
            MySimpleUser currentUser = ObjectSpace.GetObjectByKey<MySimpleUser>(SecuritySystem.CurrentUserId);
            BaseClass currentObject = (BaseClass)View.CurrentObject;
            if (currentObject.Users.IndexOf(currentUser) == -1) {
                currentObject.Users.Add(currentUser);
                if (commitChanges) {
                    ObjectSpace.CommitChanges();
                }
            }
        }
    }
}