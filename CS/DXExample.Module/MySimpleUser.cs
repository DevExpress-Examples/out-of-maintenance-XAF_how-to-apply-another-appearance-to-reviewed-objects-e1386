using System;
using System.ComponentModel;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace DXExample.Module {
    public class MySimpleUser : SimpleUser {
        public MySimpleUser(Session session) : base(session) { }
        [Association("BOs-Users")]
        [Browsable(false)]
        public XPCollection<BaseClass> BOs {
            get { return GetCollection<BaseClass>("BOs"); }
        }
    }

}
