using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.xbManage
{
    /// <summary>
    /// AuthRoleInfo ---- 授权角色信息
    /// </summary>
    [Serializable]
    [Table("tb_auth_roles")]
    public partial class AuthRoleInfo
    {
        public AuthRoleInfo()
        {
        }

        #region private --- 内部参数
        /// <summary>
        /// 主键
        /// </summary>
        private long _id = 0;
        /// <summary>
        /// 角色名称
        /// </summary>
        private string _name = "";
        /// <summary>
        /// 角色分组
        /// </summary>
        private string _group = "";
        /// <summary>
        /// 角色描述
        /// </summary>
        private string _remark = "";
        /// <summary>
        /// 角色状态
        /// </summary>
        private int _state = 1;
        /// <summary>
        /// 角色所属
        /// </summary>
        private long _agent_id = 0;
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
        /// 获取或设置 角色名称
        /// </summary>
        [Column("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 获取或设置 角色分组
        /// </summary>
        [Column("group")]
        public string Group
        {
            get { return _group; }
            set { _group = value; }
        }
        /// <summary>
        /// 获取或设置 角色描述
        /// </summary>
        [Column("remark")]
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// 获取或设置 角色状态
        /// </summary>
        [Column("state")]
        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// 获取或设置 角色所属
        /// </summary>
        [Column("agent_id")]
        public long AgentID
        {
            get { return _agent_id; }
            set { _agent_id = value; }
        }

    }
}
