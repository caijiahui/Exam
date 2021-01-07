using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Security;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

namespace advt.Entity
{
    [MetadataType(typeof(advt_CategoryValidation))]
    public partial class advt_Category
    {
    }

    public partial class advt_CategoryValidation
    {

        [Display(Name = "id")]
        public object id;

        [Display(Name = "name")]
        public object name;

        [Display(Name = "pid")]
        public object pid;

        [Display(Name = "prop")]
        public object prop;

        [Display(Name = "type")]
        public object type;

        [Display(Name = "description")]
        public object description;

        [Display(Name = "displayorder")]
        public object displayorder;

        [Display(Name = "available")]
        public object available;

        [Display(Name = "origin_id")]
        public object origin_id;

        [Display(Name = "source")]
        public object source;

        [Display(Name = "product_qty")]
        public object product_qty;

        [Display(Name = "ico_addr")]
        public object ico_addr;

        [Display(Name = "origin_ico_id")]
        public object origin_ico_id;

        [Display(Name = "allowdisplay")]
        public object allowdisplay;

        [Display(Name = "allowprominent")]
        public object allowprominent;
    }
}