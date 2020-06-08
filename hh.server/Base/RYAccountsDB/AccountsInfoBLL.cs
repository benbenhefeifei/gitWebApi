/***********************************************
* 版权声明：2020-2020 
* 编写作者：CTO => 吴文吉
* 功能描述： - 业务逻辑服务（可扩展）
* 创建时间：2020-06-08 13:44:52
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:52 == wuwenji == 创建 ==  - 业务逻辑服务
* *********************************************/

using System;
using System.Collections.Generic;
using com.xbao.db.server;

namespace hh.server.RYAccountsDB
{
    /// <summary>
    /// AccountsInfo ---  - 业务逻辑服务（分部类-主类）
    /// </summary>
    public partial class AccountsInfoBLL : GenericService<model.RYAccountsDB.AccountsInfo>, IService<model.RYAccountsDB.AccountsInfo>
    {
        /// <summary>
        /// 初始化 AccountsInfo ---  业务逻辑服务
        /// </summary>
        public AccountsInfoBLL() : base(new hh.storage.RYAccountsDB.AccountsInfoDAL())
        { 
            //base.Storage.DbTable.Name = "AccountsInfo";
            //base.Storage.DbTable.PKey = "UserID";
            //base.Storage.DbTable.AutoNumber = true;
            //base.Storage.DbTable.Fields = "[GameID],[ProtectID],[PasswordID],[SpreaderID],[Accounts],[NickName],[RegAccounts],[UnderWrite],[PassPortID],[Compellation],[LogonPass],[InsurePass],[DynamicPass],[DynamicPassTime],[FaceID],[CustomID],[Present],[UserMedal],[Experience],[GrowLevelID],[LoveLiness],[UserRight],[MasterRight],[ServiceRight],[MasterOrder],[MemberOrder],[MemberOverDate],[MemberSwitchDate],[CustomFaceVer],[Gender],[Nullity],[NullityOverDate],[StunDown],[MoorMachine],[IsAndroid],[WebLogonTimes],[GameLogonTimes],[PlayTimeCount],[OnLineTimeCount],[LastLogonIP],[LastLogonDate],[LastLogonMobile],[LastLogonMachine],[RegisterIP],[RegisterDate],[RegisterMobile],[RegisterMachine],[RegisterOrigin],[PlatformID],[UserUin],[RankID],[AgentID],[ParentID],[UserType],[Advertiser],[LastLogonIPAddress],[AdvertPlat]".Split(',').ToList();
        }
        
        #region 使用单例设计模式 获取服务对象
        static AccountsInfoBLL _Instance = null;
        static readonly object _lock = new object();
        public static AccountsInfoBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new AccountsInfoBLL();
                        }
                    }
                }
                return _Instance;
            }
        }
        #endregion
    }
}
