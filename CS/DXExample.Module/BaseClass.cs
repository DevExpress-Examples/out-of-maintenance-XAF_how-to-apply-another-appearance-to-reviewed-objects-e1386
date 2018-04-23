using System;
using System.ComponentModel;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace DXExample.Module {
    public class BaseClass : BaseObject {
        public BaseClass(Session session) : base(session) { }
        [Association("BOs-Users")]
        [Browsable(false)]
        public XPCollection<MySimpleUser> Users {
            get { return GetCollection<MySimpleUser>("Users"); }
        }
    }

}
