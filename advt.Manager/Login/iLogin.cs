using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using advt.Entity;

namespace advt.Manager
{
    public interface iLogin
    {
        void ClearSession();

        bool Isadmin { get; }

        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        Entity.advt_users UserContext { get; set; }

        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        bool ValidateUser { get; }
    }
}
