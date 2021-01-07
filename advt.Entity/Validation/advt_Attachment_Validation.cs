using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Security;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

namespace advt.Entity
{
    [MetadataType(typeof(advt_AttachmentValidation))]
    public partial class advt_Attachment
    {
    }

    public partial class advt_AttachmentValidation
    {

        [Display(Name = "id")]
        public object id;

        [Display(Name = "name")]
        public object name;

        [Display(Name = "savename")]
        public object savename;

        [Display(Name = "path")]
        public object path;

        [Display(Name = "createdt")]
        public object createdt;

        [Display(Name = "createby")]
        public object createby;
    }
}