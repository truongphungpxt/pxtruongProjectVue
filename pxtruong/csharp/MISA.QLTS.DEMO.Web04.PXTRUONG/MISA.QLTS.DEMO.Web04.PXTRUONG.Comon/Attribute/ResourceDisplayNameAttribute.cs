using MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Resources;
using Remotion.Globalization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.DEMO.Web04.PXTRUONG.Comon.Attribute
{
    public class ResourceDisplayNameAttribute: DisplayNameAttribute
    {
      
        private readonly string _resourceName;
        private static readonly ResourceManager _resourceManager = new ResourceManager(typeof(fixedasserttitle));

        public ResourceDisplayNameAttribute()
        {
        }

        public ResourceDisplayNameAttribute(string resourceName)
        {
            _resourceName = resourceName;
        }

        public override string DisplayName
        {
            get
            {

                return _resourceManager.GetString(_resourceName);
            }
        }
    }
}
