using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace hh.model.xbManage
{
    /// <summary>
    /// SystemLogInfo ---- 系统日志信息
    /// </summary>
    [Serializable]
    [Table("tb_log_operate")]
    public partial class SystemLogInfo
    {
        public SystemLogInfo()
        {
        }

        #region private --- 内部参数
        /// <summary>
        /// 主键
        /// </summary>
        private long _id = 0;
        /// <summary>
        /// 操作控制器
        /// </summary>
        private string _control = "";
        /// <summary>
        /// 操作方法
        /// </summary>
        private string _action = "";
        /// <summary>
        /// 操作参数
        /// </summary>
        private string _params = "";
        /// <summary>
        /// 操作IP
        /// </summary>
        private string _userip = "";
        /// <summary>
        /// 操作设备
        /// </summary>
        private string _device = "";
        /// <summary>
        /// 操作说明
        /// </summary>
        private string _remark = "";
        /// <summary>
        /// 操作用户ID
        /// </summary>
        private long _user_id = 0;
        /// <summary>
        /// 操作用户名称
        /// </summary>
        private string _user_name = "";
        /// <summary>
        /// 操作授权令牌
        /// </summary>
        private string _user_token = "";
        /// <summary>
        /// 操作时间
        /// </summary>
        private long _create_time = 0;
        #endregion

        /// <summary>
        /// 获取或设置 主键
        /// </summary>
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get { return _id; } set { _id = value; } }
        /// <summary>
        /// 获取或设置 操作控制器
        /// </summary>
        [Column("control")]
        public string Control
        {
            get { return _control; }
            set { _control = value; }
        }
        /// <summary>
        /// 获取或设置 操作方法
        /// </summary>
        [Column("action")]
        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }
        /// <summary>
        /// 获取或设置 操作参数
        /// </summary>
        [Column("params")]
        public string Params
        {
            get { return _params; }
            set { _params = value; }
        }
        /// <summary>
        /// 获取或设置 操作IP
        /// </summary>
        [Column("userip")]
        public string UserIP
        {
            get { return _userip; }
            set { _userip = value; }
        }
        /// <summary>
        /// 获取或设置 操作设备
        /// </summary>
        [Column("device")]
        public string Device
        {
            get { return _device; }
            set { _device = value; }
        }
        /// <summary>
        /// 获取或设置 操作说明
        /// </summary>
        [Column("remark")]
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// 获取或设置 操作用户ID
        /// </summary>
        [Column("user_id")]
        public long UserID
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        /// <summary>
        /// 获取或设置 操作用户名称
        /// </summary>
        [Column("user_name")]
        public string UserName
        {
            get { return _user_name; }
            set { _user_name = value; }
        }
        /// <summary>
        /// 获取或设置 操作授权令牌
        /// </summary>
        [Column("user_token")]
        public string UserToken
        {
            get { return _user_token; }
            set { _user_token = value; }
        }
        /// <summary>
        /// 获取或设置 操作时间
        /// </summary>
        [Column("create_time")]
        public long CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; }
        }

    }
}
