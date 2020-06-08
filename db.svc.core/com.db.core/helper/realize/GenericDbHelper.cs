/***********************************************
 * 版权声明：2017-2020 
 * 编写作者：吴文吉
 * 功能描述：数据库读写操作接口通用实现
 * 创建时间：2017年12月19日 16点26分
 * 更新历史：日期 - 姓名 - 功能（日期倒序）
 * GOTO：2018年6月22日 15点11分 == wuwenji == 创建 == 
 * *********************************************/

using System;
namespace com.xbao.db.core
{
    public class GenericDbHelper : IDbHelper
    {
        public GenericDbHelper(string dbName)
        {
            this._dbName = dbName;
        }

        private string _dbName = string.Empty;

        private static readonly object _ReaderLock = new object();
        private static readonly object _WriterLock = new object();

        private IWriter _Writer = null;
        private IReader _Reader = null;

        #region 实现接口 IDBHelper
        /// <summary>
        /// 数据库 写 操作Command命令对象
        /// </summary>
        public IWriter Writer
        {
            get
            {
                if (_Writer == null)
                {
                    lock (_WriterLock)
                    {
                        if (_Writer == null)
                        {
                            _Writer = new GenericWriter(this._dbName);
                        }
                    }
                }
                return _Writer;
            }
        }
        /// <summary>
        /// 数据库 读 操作Command命令对象
        /// </summary>
        public IReader Reader
        {
            get
            {
                if (_Reader == null)
                {
                    lock (_ReaderLock)
                    {
                        if (_Reader == null)
                        {
                            _Reader = new GenericReader(this._dbName);
                        }
                    }
                }
                return _Reader;
            }
        }
        #endregion

        public void Dispose()
        {
            if (Reader != null)
            {
                Reader.Dispose();
            }

            if (Writer != null)
            {
                Writer.Dispose();
            }
        }
    }
}
