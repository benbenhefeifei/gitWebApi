/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述： - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:50
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:50 == wuwenji == 创建 ==  - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// AccountsTask ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("AccountsTask")]
    public partial class AccountsTask // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _id;
        /// <summary>
        /// 用户标识
        /// </summary>
        private int _userid = 0;
        /// <summary>
        /// 任务标识
        /// </summary>
        private int _taskid = 0;
        /// <summary>
        /// 
        /// </summary>
        private int _kindid = 0;
        /// <summary>
        /// 任务类型 1：总赢局，2：总局数，4：首胜，8：比赛任务
        /// </summary>
        private int _tasktype = 0;
        /// <summary>
        /// 任务目标:满足局数等
        /// </summary>
        private int _taskobject = 0;
        /// <summary>
        /// 任务进度
        /// </summary>
        private int _progress = 0;
        /// <summary>
        /// 限制时长 秒
        /// </summary>
        private int _timelimit = 0;
        /// <summary>
        /// 任务状态 (0 为未完成  1为成功   2为失败  3未已领奖)
        /// </summary>
        private byte _taskstatus = 0;
        /// <summary>
        /// 
        /// </summary>
        private DateTime _inputdate = DateTime.Now;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Key][Column("ID")]
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        
        /// <summary>
        /// 获取或设置 用户标识
        /// </summary>
        [Column("UserID")]
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        
        /// <summary>
        /// 获取或设置 任务标识
        /// </summary>
        [Column("TaskID")]
        public int TaskID
        {
            set { _taskid = value; }
            get { return _taskid; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("KindID")]
        public int KindID
        {
            set { _kindid = value; }
            get { return _kindid; }
        }
        
        /// <summary>
        /// 获取或设置 任务类型 1：总赢局，2：总局数，4：首胜，8：比赛任务
        /// </summary>
        [Column("TaskType")]
        public int TaskType
        {
            set { _tasktype = value; }
            get { return _tasktype; }
        }
        
        /// <summary>
        /// 获取或设置 任务目标:满足局数等
        /// </summary>
        [Column("TaskObject")]
        public int TaskObject
        {
            set { _taskobject = value; }
            get { return _taskobject; }
        }
        
        /// <summary>
        /// 获取或设置 任务进度
        /// </summary>
        [Column("Progress")]
        public int Progress
        {
            set { _progress = value; }
            get { return _progress; }
        }
        
        /// <summary>
        /// 获取或设置 限制时长 秒
        /// </summary>
        [Column("TimeLimit")]
        public int TimeLimit
        {
            set { _timelimit = value; }
            get { return _timelimit; }
        }
        
        /// <summary>
        /// 获取或设置 任务状态 (0 为未完成  1为成功   2为失败  3未已领奖)
        /// </summary>
        [Column("TaskStatus")]
        public byte TaskStatus
        {
            set { _taskstatus = value; }
            get { return _taskstatus; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("InputDate")]
        public DateTime InputDate
        {
            set { _inputdate = value; }
            get { return _inputdate; }
        }
        #endregion
    }
}
