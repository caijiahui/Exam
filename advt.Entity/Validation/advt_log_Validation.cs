using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Security;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

namespace advt.Entity
{
    [MetadataType(typeof(advt_logValidation))]
    public partial class advt_log
    {
    }

    public partial class advt_logValidation
    {

        [Display(Name = "id")]
        public object id;

        [Display(Name = "type")]
        public object type;

        [Display(Name = "uid")]
        public object uid;

        [Display(Name = "data")]
        public object data;

        [Display(Name = "fromip")]
        public object fromip;

        [Display(Name = "url")]
        public object url;

        [Display(Name = "fromurl")]
        public object fromurl;

        [Display(Name = "description")]
        public object description;

        [Display(Name = "createdt")]
        public object createdt;
    }
}