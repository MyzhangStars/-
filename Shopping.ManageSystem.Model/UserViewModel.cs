using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shopping.ManageSystem.Model
{
    public class UserViewModel
    {
        [StringLength(20)]
        public string UserName { get; set; }//用户名

        [StringLength(20)]
        public string UserPass { get; set; }//密码

        [StringLength(20)]
        public string ValidateCode { get; set; }//验证码
    }
}
