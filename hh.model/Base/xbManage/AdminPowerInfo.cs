using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.xbManage
{
    /// <summary>
    /// AdminPowerInfo ---- 管理员权限配置信息
    /// </summary>
    [Serializable]
    [Table("tb_admin_power")]
    public partial class AdminPowerInfo
    {
        public AdminPowerInfo()
        {
        }

        #region private --- 内部参数
        /// <summary>
        /// 主键自增，参考表:tb_admin_account.id
        /// </summary>
        private long _admin_id = 0;
        /// <summary>
        /// 所属AgentID，0为系统默认用户，参考表:tb_agent_cominfo.id
        /// </summary>
        private long _agent_id = 0;
        /// <summary>
        /// 所属RoleID，0未分配权限，参考表:tb_auth_roles.id
        /// </summary>
        private string _role_ids = "";
        /// <summary>
        /// 角色组【root,admin,sales,agent,service】
        /// </summary>
        private string _role_group = "";
        /// <summary>
        /// 渠道权限组,AgentID集合
        /// </summary>
        private string _agent_group = "";
        /// <summary>
        /// 所属渠道推广码
        /// </summary>
        private string _agent_spread = "";
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
        /// 所属AgentID，0为系统默认用户，参考表:tb_agent_cominfo.id
        /// </summary>
        [Column("agent_id")]
        public long AgentID
        {
            get { return _agent_id; }
            set { _agent_id = value; }
        }
        /// <summary>
        /// 所属RoleID，0未分配权限，参考表:tb_auth_roles.id
        /// </summary>
        [Column("role_ids")]
        public string RoleIds
        {
            get { return _role_ids; }
            set { _role_ids = value; }
        }
        /// <summary>
        /// 角色组【root,admin,sales,agent,service】
        /// </summary>
        [Column("role_group")]
        public string RoleGroup
        {
            get { return _role_group; }
            set { _role_group = value; }
        }
        /// <summary>
        /// 渠道权限组,AgentID集合
        /// </summary>
        [Column("agent_group")]
        public string AgentGroup
        {
            get { return _agent_group; }
            set { _agent_group = value; }
        }
        /// <summary>
        /// 所属渠道推广码
        /// </summary>
        [Column("agent_spread")]
        public string AgentSpread
        {
            get { return _agent_spread; }
            set { _agent_spread = value; }
        }
    }
}
