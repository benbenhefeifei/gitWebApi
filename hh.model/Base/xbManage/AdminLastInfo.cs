using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.xbManage
{
    /// <summary>
    /// AdminLastInfo ---- 管理员最后操作信息
    /// </summary>
    [Serializable]
    [Table("tb_admin_extends")]
    public partial class AdminLastInfo
    {
        public AdminLastInfo()
        {
        }

        #region private --- 内部参数
        /// <summary>
        /// 主键自增，参考表:tb_admin_account.id
        /// </summary>
        private long _admin_id = 0;
        /// <summary>
        /// 在线【0离线，1在线，2锁屏】
        /// </summary>
        private int _online = 0;
        /// <summary>
        /// 在线时长/秒
        /// </summary>
        private long _log_time = 0;
        /// <summary>
        /// 登录次数
        /// </summary>
        private long _log_count = 0;
        /// <summary>
        /// 最后登录时间,Unix时间戳/毫秒
        /// </summary>
        private long _login_time = 0;
        /// <summary>
        /// 最后修改密码时间,Unix时间戳/毫秒
        /// </summary>
        private long _edit_pass_time = 0;
        /// <summary>
        /// 密码错误次数【3次锁定账号30分钟，>5次冻结账号】
        /// </summary>
        private int _pass_error_num = 0;
        /// <summary>
        /// 操作控制器
        /// </summary>
        private string _band_ip = "";
        /// <summary>
        /// 操作控制器
        /// </summary>
        private string _login_ip = "";
        /// <summary>
        /// 操作控制器
        /// </summary>
        private string _login_device = "";
        /// <summary>
        /// 操作控制器
        /// </summary>
        private string _login_token = "";
        #endregion

        /// <summary>
        /// 获取或设置 主键
        /// </summary>
        [Key]
        [Column("admin_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AdminID
        {
            get { return _admin_id; }
            set { _admin_id = value; }
        }
        /// <summary>
        /// 获取或设置 在线【0离线，1在线，2锁屏】
        /// </summary>
        [Column("online")]
        public int Online
        {
            get { return _online; }
            set { _online = value; }
        }
        /// <summary>
        /// 获取或设置 在线时长/秒
        /// </summary>
        [Column("log_time")]
        public long LogTime
        {
            get { return _log_time; }
            set { _log_time = value; }
        }
        /// <summary>
        /// 获取或设置 登录次数
        /// </summary>
        [Column("log_count")]
        public long LogCount
        {
            get { return _log_count; }
            set { _log_count = value; }
        }
        /// <summary>
        /// 获取或设置 最后登录时间,Unix时间戳/毫秒
        /// </summary>
        [Column("login_time")]
        public long LoginTime
        {
            get { return _login_time; }
            set { _login_time = value; }
        }
        /// <summary>
        /// 获取或设置 最后修改密码时间,Unix时间戳/毫秒
        /// </summary>
        [Column("edit_pass_time")]
        public long EditPassTime
        {
            get { return _edit_pass_time; }
            set { _edit_pass_time = value; }
        }
        /// <summary>
        /// 获取或设置 密码错误次数【3次锁定账号30分钟，>5次冻结账号】
        /// </summary>
        [Column("pass_error_num")]
        public int PassErrorNum
        {
            get { return _pass_error_num; }
            set { _pass_error_num = value; }
        }
        /// <summary>
        /// 获取或设置 绑定IP
        /// </summary>
        [Column("band_ip")]
        public string BandIP
        {
            get { return _band_ip; }
            set { _band_ip = value; }
        }
        /// <summary>
        /// 获取或设置 最后登录IP
        /// </summary>
        [Column("login_ip")]
        public string LoginIP
        {
            get { return _login_ip; }
            set { _login_ip = value; }
        }
        /// <summary>
        /// 获取或设置 最后登录设备
        /// </summary>
        [Column("login_device")]
        public string LoginDevice
        {
            get { return _login_device; }
            set { _login_device = value; }
        }
        /// <summary>
        /// 获取或设置 最后授权令牌
        /// </summary>
        [Column("login_token")]
        public string LoginToken
        {
            get { return _login_token; }
            set { _login_token = value; }
        }
    }
}
