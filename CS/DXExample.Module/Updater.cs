using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;

namespace DXExample.Module {
    public class Updater : ModuleUpdater {
        public Updater(DevExpress.ExpressApp.IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            AddUser("Sam");
            AddUser("John");
            AddMaster("master1");
            AddMaster("master2");
            AddMaster("master3");
            AddMaster("master4");
            AddDetail("detail1");
            AddDetail("detail2");
            AddDetail("detail3");
            AddDetail("detail4");
        }
        private void AddUser(string name) {
            MySimpleUser user = ObjectSpace.FindObject<MySimpleUser>(new BinaryOperator("UserName", name));
            if (user == null) {
                user = ObjectSpace.CreateObject<MySimpleUser>();
                user.UserName = name;
                user.SetPassword("");
                user.Save();
            }
        }
        private void AddMaster(string name) {
            Master master = ObjectSpace.FindObject<Master>(new BinaryOperator("MasterName", name));
            if (master == null) {
                master = ObjectSpace.CreateObject<Master>();
                master.MasterName = name;
                master.Save();
            }
        }
        private void AddDetail(string name) {
            Detail detail = ObjectSpace.FindObject<Detail>(new BinaryOperator("DetailName", name));
            if (detail == null) {
                detail = ObjectSpace.CreateObject<Detail>();
                detail.DetailName = name;
                detail.Save();
            }
        }
    }
}
