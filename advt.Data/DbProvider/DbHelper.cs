using System;
using System.Data;
using System.Xml;
using System.Collections.Generic;
using System.Data.Common;
using System.Collections;
using System.Threading;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Reflection.Emit;

using advt.Common;
using advt.Config;

namespace advt.Data
{
    /// <summary>
    /// 数据访问助手类
    /// </summary>
    public class DbHelper
    {
#if DEBUG
        public static SqlHelper PE = new SqlHelper { ConnectionString = BaseConfigs.GetBaseConfig().DbconnectstringDebug };
#else
        public static SqlHelper PE = new SqlHelper();
#endif
        public static SqlHelper CTOSCustomer = new SqlHelper { ConnectionString = BaseConfigs.GetBaseConfig().DbconnectstringCTOSCustomer };

    }

}