using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Security;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

namespace advt.Entity
{
    [MetadataType(typeof(advt_user_group_mappingValidation))]
    public partial class advt_user_group_mapping
    {
    }

    public partial class advt_user_group_mappingValidation
    {

        [Display(Name = "id")]
        public object id;

        [Display(Name = "groupid")]
        public object groupid;

        [Display(Name = "pid")]
        public object pid;

        [Display(Name = "sort")]
        public object sort;

        [Display(Name = "available")]
        public object available;
    }
}