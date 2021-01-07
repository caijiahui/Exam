using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace advt.Manager.Services
{
    /// <summary>
    /// 下拉列表
    /// </summary>
    public class LOV
    {
        private static string chosestr = "===请选择===";

        private static List<SelectListItem> m_Role_List;

        public static List<SelectListItem> Role_List
        {
            get
            {

                if (m_Role_List == null)
                {
                    m_Role_List = new List<SelectListItem>();
                    m_Role_List.Add(new SelectListItem { Text = "游客", Value = ((int)Entity.Status.RoleStatus.Guest).ToString() });
                    m_Role_List.Add(new SelectListItem { Text = "会员", Value = ((int)Entity.Status.RoleStatus.Member).ToString() });
                    m_Role_List.Add(new SelectListItem { Text = "组管理员", Value = ((int)Entity.Status.RoleStatus.Groupadmin).ToString() });
                    m_Role_List.Add(new SelectListItem { Text = "管理员", Value = ((int)Entity.Status.RoleStatus.Admin).ToString() });
                }
                return m_Role_List;
            }
        }

        private static List<SelectListItem> m_Sex_List;
        public static List<SelectListItem> Sex_List
        {
            get
            {

                if (m_Sex_List == null)
                {
                    m_Sex_List = new List<SelectListItem>();
                    m_Sex_List.Add(new SelectListItem { Text = "男", Value = ((int)Entity.Status.Sex.Man).ToString() });
                    m_Sex_List.Add(new SelectListItem { Text = "女", Value = ((int)Entity.Status.Sex.Woman).ToString() });
                    m_Sex_List.Add(new SelectListItem { Text = "保密", Value = ((int)Entity.Status.Sex.Secrecy).ToString() });
                }
                return m_Sex_List;
            }
        }

        private static List<SelectListItem> m_CategoryType_List;

        /// <summary>
        /// 分类类别。
        /// </summary>
        public static List<SelectListItem> CategoryType_List
        {
            get
            {
                if (m_CategoryType_List == null)
                {
                    m_CategoryType_List = new List<SelectListItem>();
                    m_CategoryType_List.Add(new SelectListItem { Text = chosestr, Value = "" });
                    m_CategoryType_List.Add(new SelectListItem { Text = "分类类别(有子分类)", Value = ((int)Entity.Status.CategoryType.category).ToString() });
                    m_CategoryType_List.Add(new SelectListItem { Text = "最终类别(无子分类)", Value = ((int)Entity.Status.CategoryType.unsubsategory).ToString() });
                }
                return m_CategoryType_List;
            }
        }

        private static List<SelectListItem> m_Normal_List;

        public static List<SelectListItem> Normal_List
        {
            get
            {

                if (m_Normal_List == null)
                {
                    m_Normal_List = new List<SelectListItem>();
                    m_Normal_List.Add(new SelectListItem { Text = chosestr, Value = "" });
                    m_Normal_List.Add(new SelectListItem { Text = "允许", Value = ((int)Entity.Status.Normal.Enable).ToString() });
                    m_Normal_List.Add(new SelectListItem { Text = "禁止", Value = ((int)Entity.Status.Normal.Disable).ToString() });
                    m_Normal_List.Add(new SelectListItem { Text = "待审核", Value = ((int)Entity.Status.Normal.Verify).ToString() });
                }
                return m_Normal_List;
            }
        }

        private static List<SelectListItem> m_attr_input_type;

        public static List<SelectListItem> Attr_input_type
        {
            get
            {
                if (m_attr_input_type == null)
                {
                    m_attr_input_type = new List<SelectListItem>();
                    m_attr_input_type.Add(new SelectListItem { Text = "手工输入", Value = "1" });
                    m_attr_input_type.Add(new SelectListItem { Text = "选择输入", Value = "2" });
                    m_attr_input_type.Add(new SelectListItem { Text = "多行文本输入", Value = "3" });
                }
                return m_attr_input_type;
            }
        }
        

        private static List<SelectListItem> m_Available_True_False;

        public static List<SelectListItem> Available_True_False
        {
            get
            {
                if (m_Available_True_False == null)
                {
                    m_Available_True_False = new List<SelectListItem>();
                    m_Available_True_False.Add(new SelectListItem { Text = "是", Value = ((int)Entity.Status.Normal.Enable).ToString() });
                    m_Available_True_False.Add(new SelectListItem { Text = "否", Value = ((int)Entity.Status.Normal.Disable).ToString() });
                }
                return m_Available_True_False;
            }
        }

        private static List<SelectListItem> m_Available_List;

        public static List<SelectListItem> Available_List
        {
            get
            {
                if (m_Available_List == null)
                {
                    m_Available_List = new List<SelectListItem>();
                    m_Available_List.Add(new SelectListItem { Text = chosestr, Value = "" });
                    m_Available_List.Add(new SelectListItem { Text = "允许", Value = ((int)Entity.Status.Normal.Enable).ToString() });
                    m_Available_List.Add(new SelectListItem { Text = "禁止", Value = ((int)Entity.Status.Normal.Disable).ToString() });
                }
                return m_Available_List;
            }
        }

        private static List<SelectListItem> m_AttachmentType_List;

        /// <summary>
        /// 快速解决问题列表(库存不足,订购商品)
        /// </summary>
        public static List<SelectListItem> AttachmentType_List
        {
            get
            {
                if (m_AttachmentType_List == null)
                {
                    m_AttachmentType_List = new List<SelectListItem>();
                    m_AttachmentType_List.Add(new SelectListItem { Text = "附件", Value = ((int)Entity.Status.AttachmentType.file).ToString() });
                    m_AttachmentType_List.Add(new SelectListItem { Text = "图像", Value = ((int)Entity.Status.AttachmentType.image).ToString() });
                    m_AttachmentType_List.Add(new SelectListItem { Text = "视频", Value = ((int)Entity.Status.AttachmentType.video).ToString() });
                }
                return m_AttachmentType_List;
            }
        }

        public static string GetText(List<SelectListItem> o, string v)
        {
            SelectListItem _sl= o.Where(a => a.Value.Equals(v)).FirstOrDefault();
            return (_sl == null) ? string.Empty : _sl.Text;
        }
    }
}
