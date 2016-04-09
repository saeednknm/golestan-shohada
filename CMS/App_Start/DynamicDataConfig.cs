using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
namespace CMS.AppStart
{
    public class DynamicDataConfig
    {
        static MetaModel _model = new MetaModel();
        public static MetaModel DefualtModel
        {
            get
            {
                return _model ?? new MetaModel();
            }
        }
    }
}