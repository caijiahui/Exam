using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Security;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

namespace advt.Entity
{
    [MetadataType(typeof(advt_user_groupValidation))]
    public partial class advt_user_group
    {
    }

    public partial class advt_user_groupValidation
    {

        [Display(Name = "id")]
        public object id;

        [Display(Name = "name")]
        public object name;

        [Display(Name = "available")]
        public object available;
    }
}