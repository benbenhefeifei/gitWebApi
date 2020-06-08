using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.xbManage
{
    /// <summary>
    /// AuthTokenInfo ---- 授权令牌信息
    /// </summary>
    [Serializable]
    [Table("tb_access_token")]
    public partial class AuthTokenInfo
    {
        public AuthTokenInfo()
        {
        }

        #region private --- 内部参数
        /// <summary>
        /// 主键
        /// </summary>
        private long _id = 0;
        /// <summary>
        /// 授权令牌
        /// </summary>
        private string _token = "";
        /// <summary>
        /// 刷新令牌
        /// </summary>
        private string _refresh = "";
        /// <summary>
        /// 所属平台
        /// </summary>
        private string _plat = "";
        /// <summary>
        /// 设备类型
        /// </summary>
        private string _type = "";
        /// <summary>
        /// 设备标识
        /// </summary>
        private string _duid = "";
        /// <summary>
        /// 设备IP
        /// </summary>
        private string _usip = "";
        /// <summary>
        /// 所属用户
        /// </summary>
        private long _user_id = 1;
        /// <summary>
        /// 过期时间
        /// </summary>
        private long _expire_time = 0;
        /// <summary>
        /// 创建时间
        /// </summary>
        private long _create_time = 0;
        /// <summary>
        /// 令牌状态
        /// </summary>
        private int _state = 1;
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
        /// 获取或设置 授权令牌
        /// </summary>
        [Column("token")]
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        /// <summary>
        /// 获取或设置 刷新令牌
        /// </summary>
        [Column("refresh")]
        public string Refresh
        {
            get { return _refresh; }
            set { _refresh = value; }
        }
        /// <summary>
        /// 获取或设置 设备类型
        /// </summary>
        [Column("type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// 获取或设置 所属平台
        /// </summary>
        [Column("plat")]
        public string Plat
        {
            get { return _plat; }
            set { _plat = value; }
        }
        /// <summary>
        /// 获取或设置 设备标识
        /// </summary>
        [Column("duid")]
        public string DeviceID
        {
            get { return _duid; }
            set { _duid = value; }
        }
        /// <summary>
        /// 获取或设置 设备IP
        /// </summary>
        [Column("usip")]
        public string UserIP
        {
            get { return _usip; }
            set { _usip = value; }
        }
        /// <summary>
        /// 获取或设置 所属用户
        /// </summary>
        [Column("user_id")]
        public long UserID
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        /// <summary>
        /// 获取或设置 过期时间
        /// </summary>
        [Column("expire_time")]
        public long ExpireTime
        {
            get { return _expire_time; }
            set { _expire_time = value; }
        }
        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        [Column("create_time")]
        public long CreateTime
        {
            get { return _create_time; }
            set { _create_time = value; }
        }
        /// <summary>
        /// 获取或设置 令牌状态
        /// </summary>
        [Column("state")]
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }

    }
}
