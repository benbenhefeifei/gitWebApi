using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.xbManage
{
    /// <summary>
    /// AuthResourceInfo ---- 授权资源信息
    /// </summary>
    [Serializable]
    [Table("tb_auth_resource")]
    public partial class AuthResourceInfo
    {
        public AuthResourceInfo()
        {
        }

        #region private --- 内部参数
        /// <summary>
        /// 主键
        /// </summary>
        private long _id = 0;
        /// <summary>
        /// 上级ID
        /// </summary>
        private long _pid = 0;
        /// <summary>
        /// 是否导航
        /// </summary>
        private int _nav = 0;
        /// <summary>
        /// 资源CODE
        /// </summary>
        private string _code = "";
        /// <summary>
        /// 资源名称
        /// </summary>
        private string _name = "";
        /// <summary>
        /// 资源图标
        /// </summary>
        private string _icon = "";
        /// <summary>
        /// 资源请求地址
        /// </summary>
        private string _link = "";
        /// <summary>
        /// 资源请求参数
        /// </summary>
        private string _args = "";
        /// <summary>
        /// 权限功能【all,config,delete,audit,push,edit,look】
        /// </summary>
        private string _funcs = "";
        /// <summary>
        /// 资源状态，1正常｜0无效
        /// </summary>
        private int _state = 0;
        /// <summary>
        /// 资源排序
        /// </summary>
        private int _scort = 0;
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
        /// 获取或设置 上级ID
        /// </summary>
        [Column("pid")]
        public long PID
        {
            get { return _pid; }
            set { _pid = value; }
        }
        /// <summary>
        /// 获取或设置 是否导航
        /// </summary>
        [Column("nav")]
        public int Nav
        {
            get { return _nav; }
            set { _nav = value; }
        }
        /// <summary>
        /// 获取或设置 资源状态，1正常｜0无效
        /// </summary>
        [Column("state")]
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// 获取或设置 排序
        /// </summary>
        [Column("scort")]
        public int Scort
        {
            get { return _scort; }
            set { _scort = value; }
        }
        /// <summary>
        /// 获取或设置 资源CODE
        /// </summary>
        [Column("code")]
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        /// <summary>
        /// 获取或设置 资源名称
        /// </summary>
        [Column("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 获取或设置 资源图标
        /// </summary>
        [Column("icon")]
        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
        /// <summary>
        /// 获取或设置 资源请求地址
        /// </summary>
        [Column("link")]
        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }
        /// <summary>
        /// 获取或设置 资源请求参数
        /// </summary>
        [Column("args")]
        public string Args
        {
            get { return _args; }
            set { _args = value; }
        }
        /// <summary>
        /// 获取或设置 权限功能【all,config,delete,audit,push,edit,look】
        /// </summary>
        [Column("funcs")]
        public string Funcs
        {
            get { return _funcs; }
            set { _funcs = value; }
        }
    }
}
