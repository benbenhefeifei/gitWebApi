using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.xbManage
{
    /// <summary>
    /// AdminLoginLogInfo ---- 管理员登录日志信息
    /// </summary>
    [Serializable]
    [Table("tb_log_login")]
    public partial class AdminLoginLogInfo
    {
        public AdminLoginLogInfo()
        {
        }

        #region private --- 内部参数
        /// <summary>
        /// 主键
        /// </summary>
        private long _id = 0;
        /// <summary>
        /// 用户ID
        /// </summary>
        private long _user_id = 0;
        /// <summary>
        /// 用户类型（0管理账户,1普通用户,2代理渠道,3VIP商户）
        /// </summary>
        private int _user_type = 0;
        /// <summary>
        /// 登录时间,Unix时间戳/毫秒
        /// </summary>
        private long _login_time = 0;
        /// <summary>
        /// 登出时间,Unix时间戳/毫秒
        /// </summary>
        private long _logout_time = 0;
        /// <summary>
        /// 登录IP
        /// </summary>
        private string _login_ip = "";
        /// <summary>
        /// 登录设备
        /// </summary>
        private string _login_device = "";
        /// <summary>
        /// 用户账号
        /// </summary>
        private string _user_name = "";
        /// <summary>
        /// 用户授权令牌
        /// </summary>
        private string _user_token = "";
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
        /// 获取或设置 用户ID
        /// </summary>
        [Column("user_id")]
        public long UserID
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        /// <summary>
        /// 获取或设置 用户类型（0管理账户,1普通用户,2代理渠道,3VIP商户）
        /// </summary>
        [Column("user_type")]
        public int UserType
        {
            get { return _user_type; }
            set { _user_type = value; }
        }
        /// <summary>
        /// 获取或设置 登录时间,Unix时间戳/毫秒
        /// </summary>
        [Column("login_time")]
        public long LoginTime
        {
            get { return _login_time; }
            set { _login_time = value; }
        }
        /// <summary>
        /// 获取或设置 登出时间,Unix时间戳/毫秒
        /// </summary>
        [Column("logout_time")]
        public long LogoutTime
        {
            get { return _logout_time; }
            set { _logout_time = value; }
        }
        /// <summary>
        /// 获取或设置 登录IP
        /// </summary>
        [Column("login_ip")]
        public string LoginIP
        {
            get { return _login_ip; }
            set { _login_ip = value; }
        }
        /// <summary>
        /// 获取或设置 登录设备
        /// </summary>
        [Column("login_device")]
        public string LoginDevice
        {
            get { return _login_device; }
            set { _login_device = value; }
        }
        /// <summary>
        /// 获取或设置 用户账号
        /// </summary>
        [Column("user_name")]
        public string UserName
        {
            get { return _user_name; }
            set { _user_name = value; }
        }
        /// <summary>
        /// 获取或设置 用户授权令牌
        /// </summary>
        [Column("user_token")]
        public string UserToken
        {
            get { return _user_token; }
            set { _user_token = value; }
        }
    }
}
