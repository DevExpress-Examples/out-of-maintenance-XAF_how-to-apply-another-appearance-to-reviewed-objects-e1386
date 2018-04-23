using System;

using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;

namespace DXExample.Module {
    public class Updater : ModuleUpdater {
        public Updater(Session session, Version currentDBVersion) : base(session, currentDBVersion) { }
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
            MySimpleUser user = Session.FindObject<MySimpleUser>(new BinaryOperator("UserName", name));
            if (user == null) {
                user = new MySimpleUser(Session);
                user.UserName = name;
                user.SetPassword("");
                user.Save();
            }
        }
        private void AddMaster(string name) {
            Master master = Session.FindObject<Master>(new BinaryOperator("MasterName", name));
            if (master == null) {
                master = new Master(Session);
                master.MasterName = name;
                master.Save();
            }
        }
        private void AddDetail(string name) {
            Detail detail = Session.FindObject<Detail>(new BinaryOperator("DetailName", name));
            if (detail == null) {
                detail = new Detail(Session);
                detail.DetailName = name;
                detail.Save();
            }
        }
    }
}
