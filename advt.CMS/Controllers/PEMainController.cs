using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using advt.Entity;
using advt.Manager;
using System.Text.RegularExpressions;
using advt.Common;
using System.IO;
using advt.CMS;
using advt.Model.PageModel;

namespace advt.Web.Controllers
{
    public class PEMainController : BaseController
    {
        [MyAuthorize]
        public ActionResult Index(string tname,string searchdata,string startdt, string enddt, int? page,int tid =1)
        {
            tname = "Engineering";
            Model.PageModel.PEModel model = new Model.PageModel.PEModel();
            model.username = this.UserContext.username.Substring(0,this.UserContext.username.Length-17);
            if (tid == 0)
            {
                return PartialView("IndexLogin",model);
            }
            ViewBag.PartialView = false;
            ViewBag.Index = page ?? 1;
            ViewBag.PageSize = 10;
            model.V_CMSCategory = Data.advt_CMSCategory.Get_advt_CMSCategory(tid);
            model.L_topics = Data.advt_topics.Get_All_Advt_topic_id(ViewBag.PageSize, ViewBag.Index, tid, searchdata,startdt,enddt);
            var count = Data.advt_topics.Get_All_Advt_topic_id(0, 0, tid, searchdata, startdt, enddt);
            ViewBag.RecordCount = count.Count;
            model.L_state = BLL.PEBLL.Get_All_State();
            model.L_categoryname = BLL.PEBLL.Get_All_CategoryName();
            model.L_Bit = BLL.PEBLL.Get_All_Bit();
            var a = Data.advt_users_type.Get_advt_users_type(this.advt_user.username);
            model.isAdministrators = false;
            model.tname = tname;
            if(a!=null)
            {
                if (a.type == "Administrators")
                {
                    model.isAdministrators = true;
                }
            }
            return View(model);
           

        }
        [MyAuthorize]
        public ActionResult Classify(string tid)
        {
            Model.PageModel.PEModel model = new Model.PageModel.PEModel();
            model.username = this.UserContext.username.Substring(0, this.UserContext.username.Length - 17);
            if(!string.IsNullOrEmpty(tid))
            {
                model.tname = tid;
                return PartialView("IndexLogin", model);
            }
            return View(model);
           
        }
        [HttpPost]
        [MyAuthorize]
        public ActionResult UpdateColumn(advt_CMSCategory V_CMSCategory)
        {
            bool result = false;
            var info = BLL.PEBLL.Update_advt_CMSCategory(V_CMSCategory, null, new string[] { "id" });
            if (info == 1)
                result = true;
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [MyAuthorize]
        public ActionResult AddData(advt_topics V_topics)
        {
            bool result = false;
            Model.PageModel.PEModel model = new Model.PageModel.PEModel();
            V_topics.createdt =Convert.ToDateTime(DateTime.Now.Year+"-"+DateTime.Now.Month+"-"+DateTime.Now.Day);//上传时间
            V_topics.username = this.advt_user.username;//分享人
            V_topics.available = (byte)Status.Normal.Enable;
            var info = Data.advt_topics.Insert_advt_topics(V_topics, null, new string[] { "id" });
            if (info == 1)
                result = true;
            return Json(new { result = result, createdate = V_topics.createdt, username = V_topics.username, files = V_topics.attachment,item9 = V_topics.item9 }, JsonRequestBehavior.AllowGet);
        }
        [MyAuthorize]
        public ActionResult AddPPT(HttpPostedFileBase file)
        {
            bool results = false;
            string filepath = "";
            string savefile = "";
            if (file != null)
            {
                string path = Server.MapPath(_AttachmentUploadDirectory_temp);//设定上传的文件路径
                if (!Directory.Exists(path))
                {

                    Directory.CreateDirectory(path);

                }
                String gcode = System.Guid.NewGuid().ToString("N");
                string filenName = '\\' + gcode + file.FileName;

                filepath = path + filenName;

                file.SaveAs(filepath);//上传路径
                savefile ="/Attachment/temp/" + gcode + file.FileName;
                results = true;
            }
            return Json(new { result = results, filepath = savefile,filename = file.FileName }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [MyAuthorize]
        public ActionResult EditData(advt_topics V_topics)
        {
            var result = false;
            V_topics.updatedt = DateTime.Now;//更新时间
            V_topics.username = this.UserContext.username;
            var info = Data.advt_topics.Update_advt_topics(V_topics, null, new string[] { "id","createdt" });
            if (info == 1)
                result = true;
            return Json(new { result = result, update = V_topics.updatedt}, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [MyAuthorize]
        public ActionResult DeleteData(advt_topics V_topics)
        {
            var result = false;
            V_topics.updatedt = DateTime.Now;//更新时间
            V_topics.available = (byte)Status.Normal.Verify;
            var info = Data.advt_topics.Update_advt_topics(V_topics, null, new string[] { "id" });
            if (info == 1)
                result = true;
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [MyAuthorize]
        public ActionResult C_Name_Info(string id)
        {
            int ids = Convert.ToInt32(id);
            var info = Data.advt_CMSCategory.Get_advt_CMSCategory(ids);
            info.categoryname.Replace("\r\n","");
            return Json(new {info = info  }, JsonRequestBehavior.AllowGet);
        }
        [MyAuthorize]
        public ActionResult IndexLogin()
        {
            return View();
        }
        [MyAuthorize]
        public ActionResult User_type(string userid,int? page,string tname)
        {
            ViewBag.PartialView = false;
            ViewBag.Index = page ?? 1;
            ViewBag.PageSize = 10;
            Model.PageModel.PEModel model = new Model.PageModel.PEModel();
            model.username = this.UserContext.username.Substring(0, this.UserContext.username.Length - 17);
            model.L_usertype = Data.advt_users_type.Get_advt_users_type_join_user(ViewBag.PageSize, ViewBag.Index,userid);
            ViewBag.RecordCount = Data.advt_users_type.Get_advt_users_type_join_user(0, 0, userid).Count;
            model.L_Location = BLL.PEBLL.Get_All_Location();
            model.L_type = BLL.PEBLL.Get_All_L_type();
            model.tname = tname;
            return View(model);
        }

        [MyAuthorize]
        public ActionResult MaintainExamType()
        {
            Model.PageModel.PEModel model = new Model.PageModel.PEModel();
            return View(model);
        }
        [MyAuthorize]
        public ActionResult Test()
        {
            var c = Data.ExamType.Get_All_ExamType(1);
            return Json(new { tableData = c}, JsonRequestBehavior.AllowGet);
        }


        [MyAuthorize]
        public void UploadFile(int id,string filename)
        {
            var a = Data.advt_topics.Get_advt_topics(id);
            string fileName = Path.GetFileName(a.attachment);
            string filePath = Server.MapPath(a.attachment);
            Utils.ResponseFile(filePath, a.filename, ""); 
        }
        [MyAuthorize]
        public ActionResult EditUser(advt_users_type model)
        {
            var result = false;
            var isuser = Data.advt_users_type.Get_advt_users_type(model.username);
            if(isuser==null)
            {
                advt_users_type v = new advt_users_type();
                v.username = model.username;
                var info = Data.advt_users_type.Insert_advt_users_type(v, null, new string[] { "id" });
            }
            var list = Data.advt_users_type.Update_advt_users_type_username(model);
            if (list == 1)
                result = true;
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }
    }
}
