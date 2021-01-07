using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Security;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

namespace advt.Entity
{
    [MetadataType(typeof(advt_posts1Validation))]
    public partial class advt_posts1
    {
    }

    public partial class advt_posts1Validation
    {

        [Display(Name = "id")]
        public object id;

        [Display(Name = "fid")]
        public object fid;

        [Display(Name = "tid")]
        public object tid;

        [Display(Name = "pid")]
        public object pid;

        [Display(Name = "name")]
        public object name;

        [Display(Name = "message")]
        public object message;

        [Display(Name = "ip")]
        public object ip;

        [Display(Name = "htmlon")]
        public object htmlon;

        [Display(Name = "smileon")]
        public object smileon;

        [Display(Name = "attachment")]
        public object attachment;

        [Display(Name = "createdt")]
        public object createdt;

        [Display(Name = "createby")]
        public object createby;

        [Display(Name = "available")]
        public object available;
    }
}