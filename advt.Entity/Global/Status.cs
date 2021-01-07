using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace advt.Entity
{
    public class Status
    {
        /// <summary>
        /// Counter Type.
        /// </summary>
        public enum AttachmentType
        {
            /// <summary>
            /// 普通附件
            /// </summary>
            file = 1,
            /// <summary>
            /// 图像文件
            /// </summary>
            image = 2,
            /// <summary>
            /// 上传视频
            /// </summary>
            video = 4

        }
        /// <summary>
        /// 性别
        /// </summary>
        public enum Sex
        {
            /// <summary>
            /// 男
            /// </summary>
            Man = 0x0001,
            /// <summary>
            /// 女
            /// </summary>
            Woman = 0x0002,
            /// <summary>
            /// 保密
            /// </summary>
            Secrecy = 0x0004
        }


        /// <summary>
        /// 分类类别
        /// </summary>
        public enum CategoryType
        {
            /// <summary>
            /// 有子分类
            /// </summary>
            category = 0x0001,
            /// <summary>
            /// 无子分类
            /// </summary>
            unsubsategory = 0x0002
        }

        /// <summary>
        /// Verify = 1,//允许
        /// Enable = 2, //禁止
        /// Disable = 4,//待审核
        /// All = Enable | Disable | Verify //允许 | 禁止 | 待审核
        /// </summary>
        public enum Normal
        {
            /// <summary>
            /// 待审核
            /// </summary>
            Verify = 0x0001,
            /// <summary>
            /// 允许
            /// </summary>
            Enable = 0x0002,
            /// <summary>
            /// 禁止
            /// </summary>
            Disable = 0x0004,
            /// <summary>
            /// 允许 | 禁止 | 待审核
            /// </summary>
            All = Enable | Disable | Verify
        }

        public enum RoleStatus
        {
            /// <summary>
            /// 什么都没有
            /// </summary>
            None = 0x0000,
            /// <summary>
            /// 游客
            /// </summary>
            Guest = 0x0001,
            /// <summary>
            /// 普通用户
            /// </summary>
            User = 0x0002,
            /// <summary>
            /// 会员
            /// </summary>
            Member = 0x0004,
            /// <summary>
            /// 组管理员
            /// </summary>
            Groupadmin = 0x0008,
            /// <summary>
            /// 管理员
            /// </summary>
            Admin = 0x0010
        }

    }
}
