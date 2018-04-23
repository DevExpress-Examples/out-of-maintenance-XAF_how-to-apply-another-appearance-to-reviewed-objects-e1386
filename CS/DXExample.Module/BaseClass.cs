using System;
using System.ComponentModel;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace DXExample.Module {
    [Appearance("ByUsers", Criteria = "Users[Oid = CurrentUserId()].Count > 0", FontColor="Gray", AppearanceItemType="ViewItem", TargetItems="*", Context="ListView")]
    public class BaseClass : BaseObject {
        public BaseClass(Session session) : base(session) { }
        [Association("BOs-Users")]
        [Browsable(false)]
        public XPCollection<MySimpleUser> Users {
            get { return GetCollection<MySimpleUser>("Users"); }
        }
    }

}
