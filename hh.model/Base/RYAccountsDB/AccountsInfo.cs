/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述： - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:49
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:49 == wuwenji == 创建 ==  - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// AccountsInfo ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("AccountsInfo")]
    public partial class AccountsInfo // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 用户标识
        /// </summary>
        private int _userid;
        /// <summary>
        /// 游戏标识
        /// </summary>
        private int _gameid = 0;
        /// <summary>
        /// 密保标识
        /// </summary>
        private int _protectid = 0;
        /// <summary>
        /// 口令索引
        /// </summary>
        private int _passwordid = 0;
        /// <summary>
        /// 推广员标识
        /// </summary>
        private int _spreaderid = 0;
        /// <summary>
        /// 用户帐号
        /// </summary>
        private string _accounts = "";
        /// <summary>
        /// 用户昵称
        /// </summary>
        private string _nickname = "";
        /// <summary>
        /// 注册帐号
        /// </summary>
        private string _regaccounts = "";
        /// <summary>
        /// 个性签名
        /// </summary>
        private string _underwrite = "";
        /// <summary>
        /// 身份证号
        /// </summary>
        private string _passportid = "n";
        /// <summary>
        /// 真实名字
        /// </summary>
        private string _compellation = "n";
        /// <summary>
        /// 登录密码
        /// </summary>
        private string _logonpass = "";
        /// <summary>
        /// 安全密码
        /// </summary>
        private string _insurepass = "n";
        /// <summary>
        /// 动态密码
        /// </summary>
        private string _dynamicpass = "";
        /// <summary>
        /// 动态密码更新时间
        /// </summary>
        private DateTime _dynamicpasstime = DateTime.Now;
        /// <summary>
        /// 头像标识
        /// </summary>
        private short _faceid = 0;
        /// <summary>
        /// 自定标识
        /// </summary>
        private int _customid = 0;
        /// <summary>
        /// 赠送礼物
        /// </summary>
        private int _present = 0;
        /// <summary>
        /// 用户奖牌
        /// </summary>
        private int _usermedal = 0;
        /// <summary>
        /// 经验数值
        /// </summary>
        private int _experience = 0;
        /// <summary>
        /// 
        /// </summary>
        private int _growlevelid = 1;
        /// <summary>
        /// 用户魅力
        /// </summary>
        private int _loveliness = 0;
        /// <summary>
        /// 用户权限
        /// </summary>
        private int _userright = 0;
        /// <summary>
        /// 管理权限
        /// </summary>
        private int _masterright = 0;
        /// <summary>
        /// 服务权限
        /// </summary>
        private int _serviceright = 0;
        /// <summary>
        /// 管理等级
        /// </summary>
        private byte _masterorder = 0;
        /// <summary>
        /// 会员等级
        /// </summary>
        private byte _memberorder = 0;
        /// <summary>
        /// 过期日期
        /// </summary>
        private DateTime _memberoverdate = Convert.ToDateTime("1980-1-1");
        /// <summary>
        /// 切换时间
        /// </summary>
        private DateTime _memberswitchdate = Convert.ToDateTime("1980-1-1");
        /// <summary>
        /// 头像版本
        /// </summary>
        private byte _customfacever = 0;
        /// <summary>
        /// 用户性别
        /// </summary>
        private byte _gender = 0;
        /// <summary>
        /// 禁止服务
        /// </summary>
        private byte _nullity = 0;
        /// <summary>
        /// 禁止时间
        /// </summary>
        private DateTime _nullityoverdate = Convert.ToDateTime("1900-01-01");
        /// <summary>
        /// 关闭标志
        /// </summary>
        private byte _stundown = 0;
        /// <summary>
        /// 固定机器
        /// </summary>
        private byte _moormachine = 0;
        /// <summary>
        /// 是否机器人
        /// </summary>
        private byte _isandroid = 0;
        /// <summary>
        /// 登录次数
        /// </summary>
        private int _weblogontimes = 0;
        /// <summary>
        /// 登录次数
        /// </summary>
        private int _gamelogontimes = 0;
        /// <summary>
        /// 游戏时间
        /// </summary>
        private int _playtimecount = 0;
        /// <summary>
        /// 在线时间
        /// </summary>
        private int _onlinetimecount = 0;
        /// <summary>
        /// 登录地址
        /// </summary>
        private string _lastlogonip = "";
        /// <summary>
        /// 登录时间
        /// </summary>
        private DateTime _lastlogondate = DateTime.Now;
        /// <summary>
        /// 登录手机
        /// </summary>
        private string _lastlogonmobile = "n";
        /// <summary>
        /// 登录机器
        /// </summary>
        private string _lastlogonmachine = "------------";
        /// <summary>
        /// 注册地址
        /// </summary>
        private string _registerip = "";
        /// <summary>
        /// 注册时间
        /// </summary>
        private DateTime _registerdate = DateTime.Now;
        /// <summary>
        /// 注册手机
        /// </summary>
        private string _registermobile = "n";
        /// <summary>
        /// 注册机器
        /// </summary>
        private string _registermachine = "n------------";
        /// <summary>
        /// PC       0x00     ,
        //ANDROID  0x10(cocos 0x11,u3d 0x12)     ,
        //ITOUCH   0x20     ,
        //IPHONE   0x30(cocos 0x31,u3d 0x32)     ,
        //IPAD     0x40(cocos 0x41,u3d 0x42)     ,
        //WEB      0x50     
        /// </summary>
        private byte? _registerorigin = 0;
        /// <summary>
        /// =2 表示是游客
        /// </summary>
        private short _platformid = 0;
        /// <summary>
        /// 
        /// </summary>
        private string _useruin = "n";
        /// <summary>
        /// 
        /// </summary>
        private int? _rankid = 0;
        /// <summary>
        /// 
        /// </summary>
        private int _agentid = 0;
        /// <summary>
        /// T_Acc_Agent.AgentID 677这套代理
        /// </summary>
        private int _parentid = 0;
        /// <summary>
        /// 变色用
        /// </summary>
        private byte _usertype = 0;
        /// <summary>
        /// 试玩任务ID
        /// </summary>
        private string _advertiser = "";
        /// <summary>
        /// 
        /// </summary>
        private string _lastlogonipaddress = "";
        /// <summary>
        /// 试玩平台名
        /// </summary>
        private string _advertplat = "";
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 用户标识
        /// </summary>
        [Key][Column("UserID")]
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        
        /// <summary>
        /// 获取或设置 游戏标识
        /// </summary>
        [Column("GameID")]
        public int GameID
        {
            set { _gameid = value; }
            get { return _gameid; }
        }
        
        /// <summary>
        /// 获取或设置 密保标识
        /// </summary>
        [Column("ProtectID")]
        public int ProtectID
        {
            set { _protectid = value; }
            get { return _protectid; }
        }
        
        /// <summary>
        /// 获取或设置 口令索引
        /// </summary>
        [Column("PasswordID")]
        public int PasswordID
        {
            set { _passwordid = value; }
            get { return _passwordid; }
        }
        
        /// <summary>
        /// 获取或设置 推广员标识
        /// </summary>
        [Column("SpreaderID")]
        public int SpreaderID
        {
            set { _spreaderid = value; }
            get { return _spreaderid; }
        }
        
        /// <summary>
        /// 获取或设置 用户帐号
        /// </summary>
        [Column("Accounts")]
        public string Accounts
        {
            set { _accounts = value; }
            get { return _accounts; }
        }
        
        /// <summary>
        /// 获取或设置 用户昵称
        /// </summary>
        [Column("NickName")]
        public string NickName
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        
        /// <summary>
        /// 获取或设置 注册帐号
        /// </summary>
        [Column("RegAccounts")]
        public string RegAccounts
        {
            set { _regaccounts = value; }
            get { return _regaccounts; }
        }
        
        /// <summary>
        /// 获取或设置 个性签名
        /// </summary>
        [Column("UnderWrite")]
        public string UnderWrite
        {
            set { _underwrite = value; }
            get { return _underwrite; }
        }
        
        /// <summary>
        /// 获取或设置 身份证号
        /// </summary>
        [Column("PassPortID")]
        public string PassPortID
        {
            set { _passportid = value; }
            get { return _passportid; }
        }
        
        /// <summary>
        /// 获取或设置 真实名字
        /// </summary>
        [Column("Compellation")]
        public string Compellation
        {
            set { _compellation = value; }
            get { return _compellation; }
        }
        
        /// <summary>
        /// 获取或设置 登录密码
        /// </summary>
        [Column("LogonPass")]
        public string LogonPass
        {
            set { _logonpass = value; }
            get { return _logonpass; }
        }
        
        /// <summary>
        /// 获取或设置 安全密码
        /// </summary>
        [Column("InsurePass")]
        public string InsurePass
        {
            set { _insurepass = value; }
            get { return _insurepass; }
        }
        
        /// <summary>
        /// 获取或设置 动态密码
        /// </summary>
        [Column("DynamicPass")]
        public string DynamicPass
        {
            set { _dynamicpass = value; }
            get { return _dynamicpass; }
        }
        
        /// <summary>
        /// 获取或设置 动态密码更新时间
        /// </summary>
        [Column("DynamicPassTime")]
        public DateTime DynamicPassTime
        {
            set { _dynamicpasstime = value; }
            get { return _dynamicpasstime; }
        }
        
        /// <summary>
        /// 获取或设置 头像标识
        /// </summary>
        [Column("FaceID")]
        public short FaceID
        {
            set { _faceid = value; }
            get { return _faceid; }
        }
        
        /// <summary>
        /// 获取或设置 自定标识
        /// </summary>
        [Column("CustomID")]
        public int CustomID
        {
            set { _customid = value; }
            get { return _customid; }
        }
        
        /// <summary>
        /// 获取或设置 赠送礼物
        /// </summary>
        [Column("Present")]
        public int Present
        {
            set { _present = value; }
            get { return _present; }
        }
        
        /// <summary>
        /// 获取或设置 用户奖牌
        /// </summary>
        [Column("UserMedal")]
        public int UserMedal
        {
            set { _usermedal = value; }
            get { return _usermedal; }
        }
        
        /// <summary>
        /// 获取或设置 经验数值
        /// </summary>
        [Column("Experience")]
        public int Experience
        {
            set { _experience = value; }
            get { return _experience; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("GrowLevelID")]
        public int GrowLevelID
        {
            set { _growlevelid = value; }
            get { return _growlevelid; }
        }
        
        /// <summary>
        /// 获取或设置 用户魅力
        /// </summary>
        [Column("LoveLiness")]
        public int LoveLiness
        {
            set { _loveliness = value; }
            get { return _loveliness; }
        }
        
        /// <summary>
        /// 获取或设置 用户权限
        /// </summary>
        [Column("UserRight")]
        public int UserRight
        {
            set { _userright = value; }
            get { return _userright; }
        }
        
        /// <summary>
        /// 获取或设置 管理权限
        /// </summary>
        [Column("MasterRight")]
        public int MasterRight
        {
            set { _masterright = value; }
            get { return _masterright; }
        }
        
        /// <summary>
        /// 获取或设置 服务权限
        /// </summary>
        [Column("ServiceRight")]
        public int ServiceRight
        {
            set { _serviceright = value; }
            get { return _serviceright; }
        }
        
        /// <summary>
        /// 获取或设置 管理等级
        /// </summary>
        [Column("MasterOrder")]
        public byte MasterOrder
        {
            set { _masterorder = value; }
            get { return _masterorder; }
        }
        
        /// <summary>
        /// 获取或设置 会员等级
        /// </summary>
        [Column("MemberOrder")]
        public byte MemberOrder
        {
            set { _memberorder = value; }
            get { return _memberorder; }
        }
        
        /// <summary>
        /// 获取或设置 过期日期
        /// </summary>
        [Column("MemberOverDate")]
        public DateTime MemberOverDate
        {
            set { _memberoverdate = value; }
            get { return _memberoverdate; }
        }
        
        /// <summary>
        /// 获取或设置 切换时间
        /// </summary>
        [Column("MemberSwitchDate")]
        public DateTime MemberSwitchDate
        {
            set { _memberswitchdate = value; }
            get { return _memberswitchdate; }
        }
        
        /// <summary>
        /// 获取或设置 头像版本
        /// </summary>
        [Column("CustomFaceVer")]
        public byte CustomFaceVer
        {
            set { _customfacever = value; }
            get { return _customfacever; }
        }
        
        /// <summary>
        /// 获取或设置 用户性别
        /// </summary>
        [Column("Gender")]
        public byte Gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        
        /// <summary>
        /// 获取或设置 禁止服务
        /// </summary>
        [Column("Nullity")]
        public byte Nullity
        {
            set { _nullity = value; }
            get { return _nullity; }
        }
        
        /// <summary>
        /// 获取或设置 禁止时间
        /// </summary>
        [Column("NullityOverDate")]
        public DateTime NullityOverDate
        {
            set { _nullityoverdate = value; }
            get { return _nullityoverdate; }
        }
        
        /// <summary>
        /// 获取或设置 关闭标志
        /// </summary>
        [Column("StunDown")]
        public byte StunDown
        {
            set { _stundown = value; }
            get { return _stundown; }
        }
        
        /// <summary>
        /// 获取或设置 固定机器
        /// </summary>
        [Column("MoorMachine")]
        public byte MoorMachine
        {
            set { _moormachine = value; }
            get { return _moormachine; }
        }
        
        /// <summary>
        /// 获取或设置 是否机器人
        /// </summary>
        [Column("IsAndroid")]
        public byte IsAndroid
        {
            set { _isandroid = value; }
            get { return _isandroid; }
        }
        
        /// <summary>
        /// 获取或设置 登录次数
        /// </summary>
        [Column("WebLogonTimes")]
        public int WebLogonTimes
        {
            set { _weblogontimes = value; }
            get { return _weblogontimes; }
        }
        
        /// <summary>
        /// 获取或设置 登录次数
        /// </summary>
        [Column("GameLogonTimes")]
        public int GameLogonTimes
        {
            set { _gamelogontimes = value; }
            get { return _gamelogontimes; }
        }
        
        /// <summary>
        /// 获取或设置 游戏时间
        /// </summary>
        [Column("PlayTimeCount")]
        public int PlayTimeCount
        {
            set { _playtimecount = value; }
            get { return _playtimecount; }
        }
        
        /// <summary>
        /// 获取或设置 在线时间
        /// </summary>
        [Column("OnLineTimeCount")]
        public int OnLineTimeCount
        {
            set { _onlinetimecount = value; }
            get { return _onlinetimecount; }
        }
        
        /// <summary>
        /// 获取或设置 登录地址
        /// </summary>
        [Column("LastLogonIP")]
        public string LastLogonIP
        {
            set { _lastlogonip = value; }
            get { return _lastlogonip; }
        }
        
        /// <summary>
        /// 获取或设置 登录时间
        /// </summary>
        [Column("LastLogonDate")]
        public DateTime LastLogonDate
        {
            set { _lastlogondate = value; }
            get { return _lastlogondate; }
        }
        
        /// <summary>
        /// 获取或设置 登录手机
        /// </summary>
        [Column("LastLogonMobile")]
        public string LastLogonMobile
        {
            set { _lastlogonmobile = value; }
            get { return _lastlogonmobile; }
        }
        
        /// <summary>
        /// 获取或设置 登录机器
        /// </summary>
        [Column("LastLogonMachine")]
        public string LastLogonMachine
        {
            set { _lastlogonmachine = value; }
            get { return _lastlogonmachine; }
        }
        
        /// <summary>
        /// 获取或设置 注册地址
        /// </summary>
        [Column("RegisterIP")]
        public string RegisterIP
        {
            set { _registerip = value; }
            get { return _registerip; }
        }
        
        /// <summary>
        /// 获取或设置 注册时间
        /// </summary>
        [Column("RegisterDate")]
        public DateTime RegisterDate
        {
            set { _registerdate = value; }
            get { return _registerdate; }
        }
        
        /// <summary>
        /// 获取或设置 注册手机
        /// </summary>
        [Column("RegisterMobile")]
        public string RegisterMobile
        {
            set { _registermobile = value; }
            get { return _registermobile; }
        }
        
        /// <summary>
        /// 获取或设置 注册机器
        /// </summary>
        [Column("RegisterMachine")]
        public string RegisterMachine
        {
            set { _registermachine = value; }
            get { return _registermachine; }
        }
        
        /// <summary>
        /// 获取或设置 PC       0x00     ,
        //ANDROID  0x10(cocos 0x11,u3d 0x12)     ,
        //ITOUCH   0x20     ,
        //IPHONE   0x30(cocos 0x31,u3d 0x32)     ,
        //IPAD     0x40(cocos 0x41,u3d 0x42)     ,
        //WEB      0x50     
        /// </summary>
        [Column("RegisterOrigin")]
        public byte? RegisterOrigin
        {
            set { _registerorigin = value; }
            get { return _registerorigin; }
        }
        
        /// <summary>
        /// 获取或设置 =2 表示是游客
        /// </summary>
        [Column("PlatformID")]
        public short PlatformID
        {
            set { _platformid = value; }
            get { return _platformid; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("UserUin")]
        public string UserUin
        {
            set { _useruin = value; }
            get { return _useruin; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("RankID")]
        public int? RankID
        {
            set { _rankid = value; }
            get { return _rankid; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("AgentID")]
        public int AgentID
        {
            set { _agentid = value; }
            get { return _agentid; }
        }
        
        /// <summary>
        /// 获取或设置 T_Acc_Agent.AgentID 677这套代理
        /// </summary>
        [Column("ParentID")]
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        
        /// <summary>
        /// 获取或设置 变色用
        /// </summary>
        [Column("UserType")]
        public byte UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        
        /// <summary>
        /// 获取或设置 试玩任务ID
        /// </summary>
        [Column("Advertiser")]
        public string Advertiser
        {
            set { _advertiser = value; }
            get { return _advertiser; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("LastLogonIPAddress")]
        public string LastLogonIPAddress
        {
            set { _lastlogonipaddress = value; }
            get { return _lastlogonipaddress; }
        }
        
        /// <summary>
        /// 获取或设置 试玩平台名
        /// </summary>
        [Column("AdvertPlat")]
        public string AdvertPlat
        {
            set { _advertplat = value; }
            get { return _advertplat; }
        }
        #endregion
    }
}
