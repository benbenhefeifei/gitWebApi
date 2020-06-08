using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.xbManage
{
    /// <summary>
    /// AdminAccountInfo ---- 管理员基本信息
    /// </summary>
    [Serializable]
    [Table("tb_admin_account")]
    public partial class AdminAccountInfo
    {
        public AdminAccountInfo()
        {
        }

        #region private --- 内部参数
        /// <summary>
        /// 主键
        /// </summary>
        private long _id = 0;
        /// <summary>
        /// 状态【0注销，1有效，2封IP，3封ID，4冻结】
        /// </summary>
        private int _state = 0;
        /// <summary>
        /// 邮箱是否验证
        /// </summary>
        private int _email_active = 0;
        /// <summary>
        /// 电话是否验证
        /// </summary>
        private int _mobile_active = 0;
        /// <summary>
        /// 密码过期时长【15天】
        /// </summary>
        private int _pass_etime = 0;
        /// <summary>
        /// 创建时间,Unix时间戳/毫秒
        /// </summary>
        private int _create_time = 0;
        /// <summary>
        /// 登录账号
        /// </summary>
        private string _login_id = "";
        /// <summary>
        /// 真实姓名
        /// </summary>
        private string _real_name = "";
        /// <summary>
        /// 密码密钥
        /// </summary>
        private string _pass_salt = "";
        /// <summary>
        /// 登录密码
        /// </summary>
        private string _pass_login = "";
        /// <summary>
        /// 授权密码
        /// </summary>
        private string _pass_auth = "";
        /// <summary>
        /// 电子邮箱
        /// </summary>
        private string _email = "";
        /// <summary>
        /// 联系电话
        /// </summary>
        private string _mobile = "";
        #endregion

        /// <summary>
        /// 获取或设置 主键
        /// </summary>
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 状态【0注销，1有效，2封IP，3封ID，4冻结】
        /// </summary>
        [Column("state")]
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// 邮箱是否验证
        /// </summary>
        [Column("email_active")]
        public int EmailActive
        {
            get { return _email_active; }
            set { _email_active = value; }
        }
        /// <summary>
        /// 电话是否验证
        /// </summary>
        [Column("mobile_active")]
        public int MobileActive
        {
            get { return _mobile_active; }
            set { _mobile_active = value; }
        }
        /// <summary>
        /// 密码过期时长【15天】
        /// </summary>
        [Column("pass_etime")]
        public int PassEtime
        {
            get { return _pass_etime; }
            set { _pass_etime = value; }
        }
        /// <summary>
        /// 创建时间,Unix时间戳/毫秒
        /// </summary>
        [Column("create_time")]
        public int CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; }
        }
        /// <summary>
        /// 登录账号
        /// </summary>
        [Column("login_id")]
        public string LoginID
        {
            get { return _login_id; }
            set { _login_id = value; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [Column("real_name")]
        public string RealName
        {
            get { return _real_name; }
            set { _real_name = value; }
        }
        /// <summary>
        /// 密码密钥
        /// </summary>
        [Column("pass_salt")]
        public string PassSalt
        {
            get { return _pass_salt; }
            set { _pass_salt = value; }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        [Column("pass_login")]
        public string PassLogin
        {
            get { return _pass_login; }
            set { _pass_login = value; }
        }
        /// <summary>
        /// 授权密码
        /// </summary>
        [Column("pass_auth")]
        public string PassAuth
        {
            get { return _pass_auth; }
            set { _pass_auth = value; }
        }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        [Column("email")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Column("mobile")]
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
    }
}
