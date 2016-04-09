using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
namespace Golestan.AppStart
{
    public class DynamicDataConfig
    {
        static MetaModel _metamodel = new MetaModel();
        public static MetaModel GolestanModel
        {
            get
            {
                return _metamodel ?? new MetaModel();
            }
        }
    }
}