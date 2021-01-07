using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Security;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

namespace advt.Entity
{
    [MetadataType(typeof(advt_pageValidation))]
    public partial class advt_page
    {
    }

    public partial class advt_pageValidation
    {

        [Display(Name = "id")]
        public object id;

        [Display(Name = "name")]
        public object name;

        [Display(Name = "parea")]
        public object parea;

        [Display(Name = "paction")]
        public object paction;

        [Display(Name = "pcontroller")]
        public object pcontroller;

        [Display(Name = "description")]
        public object description;

        [Display(Name = "available")]
        public object available;
    }
}