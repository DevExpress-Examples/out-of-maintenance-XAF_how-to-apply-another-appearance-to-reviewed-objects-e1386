using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;

namespace DXExample.Module {
    public class MarkAsReadViewController : ViewController {
        public MarkAsReadViewController() {
            TargetViewType = ViewType.DetailView;
            TargetObjectType = typeof(BaseClass);
        }
        protected override void OnActivated() {
            base.OnActivated();
            if (View.ObjectSpace.Session.IsNewObject(View.CurrentObject)) {
                View.ObjectSpace.Committed += new EventHandler(ObjectSpace_Committed);
            } else {
                AddObjectToUserBOs();
            }
        }
        void ObjectSpace_Committed(object sender, EventArgs e) {
            AddObjectToUserBOs();
        }
        private void AddObjectToUserBOs() {
            MySimpleUser currentUser = (MySimpleUser)SecuritySystem.CurrentUser;
            BaseClass currentObject = (BaseClass)View.CurrentObject;
            if (currentUser.BOs.Lookup(currentObject.Oid) == null) {
                currentUser.BOs.Add(currentUser.Session.GetObjectByKey<BaseClass>(currentObject.Oid));
                currentUser.Save();
                currentUser.Session.CommitTransaction();
            }
        }
    }
}
