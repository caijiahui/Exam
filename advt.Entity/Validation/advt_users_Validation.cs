using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Security;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;

namespace advt.Entity
{
    [MetadataType(typeof(advt_usersValidation))]
    public partial class advt_users
    {
    }

    public partial class advt_usersValidation
    {

        [Display(Name = "id")]
        public object id;

        [Display(Name = "username")]
        public object username;

        [Display(Name = "firstname")]
        public object firstname;

        [Display(Name = "lastname")]
        public object lastname;

        [Display(Name = "nickname")]
        public object nickname;

        [Display(Name = "password")]
        public object password;

        [Display(Name = "sex")]
        public object sex;

        [Display(Name = "lastip")]
        public object lastip;

        [Display(Name = "regip")]
        public object regip;

        [Display(Name = "phone")]
        public object phone;

        [Display(Name = "qq")]
        public object qq;

        [Display(Name = "msn")]
        public object msn;

        [Display(Name = "email")]
        public object email;

        [Display(Name = "description")]
        public object description;

        [Display(Name = "roles")]
        public object roles;

        [Display(Name = "usergroupid")]
        public object usergroupid;

        [Display(Name = "createdate")]
        public object createdate;

        [Display(Name = "extcredits2")]
        public object extcredits2;

        [Display(Name = "extcredits1")]
        public object extcredits1;

        [Display(Name = "status")]
        public object status;
    }
}