using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MySolution.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Payment : BaseObject
    {
        public Payment(Session session) : base(session) { }
        private double rate;
        public double Rate
        {
            get
            {
                return rate;
            }
            set
            {
                if (SetPropertyValue(nameof(Rate), ref rate, value))
                    OnChanged(nameof(Amount));
            }
        }
        private double hours;
        public double Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (SetPropertyValue(nameof(Hours), ref hours, value))
                    OnChanged(nameof(Amount));
            }
        }
        /*Use this attribute to specify that the value of this property depends on the values of other fields.
          The expression that you pass as a parameter calculates the property value.*/
        [PersistentAlias("Rate * Hours")]
        public double Amount
        {
            get { return (double)(EvaluateAlias(nameof(Amount)) ?? 0); }
        }
    }
}