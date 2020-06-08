using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.xbManage
{
    /// <summary>
    /// AuthConfigInfo ---- 授权权限配置信息
    /// </summary>
    [Serializable]
    [Table("tb_auth_config")]
    public partial class AuthConfigInfo
    {
        public AuthConfigInfo()
        {
        }

        #region private --- 内部参数
        /// <summary>
        /// 主键
        /// </summary>
        private long _id = 0;
        /// <summary>
        /// 菜单资源ResID，参考表:tb_auth_resource.id
        /// </summary>
        private long _res_id = 0;
        /// <summary>
        /// 配置所属Role|User|Agent
        /// </summary>
        private long _ext_id = 0;
        /// <summary>
        /// 菜单资源ResID，参考表:tb_auth_resource.id
        /// </summary>
        private int _type = 0;
        /// <summary>
        /// 权限【all,config,delete,audit,push,edit,look】
        /// </summary>
        private string _funcs = "";
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
        /// 获取或设置 菜单资源ResID，参考表:tb_auth_resource.id
        /// </summary>
        [Column("res_id")]
        public long ResID
        {
            get { return _res_id; }
            set { _res_id = value; }
        }
        /// <summary>
        /// 获取或设置 配置所属Role|User|Agent
        /// </summary>
        [Column("ext_id")]
        public long ExtID
        {
            get { return _ext_id; }
            set { _ext_id = value; }
        }
        /// <summary>
        /// 获取或设置 菜单资源ResID，参考表:tb_auth_resource.id
        /// </summary>
        [Column("type")]
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// 获取或设置 权限【all,config,delete,audit,push,edit,look】
        /// </summary>
        [Column("funcs")]
        public string Funcs
        {
            get { return _funcs; }
            set { _funcs = value; }
        }
    }
}
