using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shopping.ManageSystem.Model
{
    //数据库表名
    [Table("UserInfo")]
    /// <summary>
    /// 用户管理表
    /// </summary>
    public class User
    {
        [Key]
        public int UserID { get; set; }//主键

        [StringLength(20)]
        public string UserName { get; set; }//用户名

        [StringLength(200)]
        public string UserPass { get; set; }//密码

        public bool Is_Delete { get; set; }//是否逻辑删除

        public bool UserSex { get; set; }//性别

        [StringLength(50)]
        public string UserEmail { get; set; }//邮箱

        public DateTime UserTime { get; set; }//编辑时间
    }
}
