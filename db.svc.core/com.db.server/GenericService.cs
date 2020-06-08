using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using com.xbao.tools.logger;

namespace com.xbao.db.server
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericService<T> : IService<T> where T : class
    {
        /// <summary>
        /// 数据仓储对象（读写）
        /// </summary>
        public storage.IRepository<T> Storage { get; private set; }
        /// <summary>
        /// 初始化服务，并设置依赖仓储
        /// </summary>
        /// <param name="name">数据表名</param>
        public GenericService(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                this.Storage = new storage.GenericRepository<T>(name);
            }
        }
        /// <summary>
        /// 初始化服务，并设置依赖仓储
        /// </summary>
        /// <param name="storeage">数据表对应仓储实现</param>
        public GenericService(storage.GenericRepository<T> storage)
        {
            if (storage != null) { this.Storage = storage; }
        }

        public virtual T Insert(T t)
        {
            if (this.Storage == null) { LogFactory.log4bao.Error("GenericService.Insert Database.Storage is null"); }
            else if (t == null) { LogFactory.log4bao.Error("GenericService.Insert params t is null"); }
            else
            {
                long id = this.Storage.Insert(t);
                if (id > 0)
                {
                    t.GetType().GetProperty(this.Storage.DbTable.PKey).SetValue(t, id);
                }
            }
            return t;
        }

        public virtual T Update(T t)
        {
            if (this.Storage == null) { LogFactory.log4bao.Error("GenericService.Update Database.Storage is null"); }
            else if (t == null) { LogFactory.log4bao.Error("GenericService.Update params t is null"); }
            else
            {
                t = this.Storage.Update(t);
            }
            return t;
        }

        public virtual bool Update(object id, string key, object value)
        {
            if (this.Storage == null) { LogFactory.log4bao.Error("GenericService.Update Database.Storage is null"); }
            else if (id == null) { LogFactory.log4bao.Error("GenericService.Update params [id] is null"); }
            else if (value == null) { LogFactory.log4bao.Error("GenericService.Update params [id] is null"); }
            else if (string.IsNullOrEmpty(key)) { LogFactory.log4bao.Error("GenericService.Update params [key or value] is null"); }
            else
            {
                IDictionary<string, object> wheres = new Dictionary<string, object>();
                wheres.Add(this.Storage.DbTable.PKey, id);

                IDictionary<string, object> columns = new Dictionary<string, object>();
                columns.Add(key, value);
                return this.Storage.Updates(columns, wheres);
            }
            return false;
        }

        public virtual bool Update(object fields, object wheres)
        {
            if (this.Storage == null) { LogFactory.log4bao.Error("GenericService.Update Database.Storage is null"); }
            else if (fields == null) { LogFactory.log4bao.Error("GenericService.Update params [fields] is null"); }
            else if (wheres == null) { LogFactory.log4bao.Error("GenericService.Update params [wheres] is null"); }
            else
            {
                IDictionary<string, object> columns = JsonConvert.DeserializeObject<IDictionary<string, object>>(JsonConvert.SerializeObject(fields));

                IDictionary<string, object> wqpargs = JsonConvert.DeserializeObject<IDictionary<string, object>>(JsonConvert.SerializeObject(wheres));

                return this.Storage.Updates(columns, wqpargs);
            }
            return false;
        }

        public virtual bool Remove(long id)
        {
            if (this.Storage == null) { LogFactory.log4bao.Error("GenericService.Remove Database.Storage is null"); }
            else if (id <= 0) { LogFactory.log4bao.Error("GenericService.Remove params [id] is null"); }
            else
            {
                IDictionary<string, object> wheres = new Dictionary<string, object>();
                wheres.Add(this.Storage.DbTable.PKey, id);

                return this.Storage.Remove(wheres);
            }
            return false;
        }

        public virtual bool Remove(object wheres)
        {
            if (this.Storage == null) { LogFactory.log4bao.Error("GenericService.Remove Database.Storage is null"); }
            else if (wheres == null) { LogFactory.log4bao.Error("GenericService.Remove params [wheres] is null"); }
            else
            {
                IDictionary<string, object> wqpargs = JsonConvert.DeserializeObject<IDictionary<string, object>>(JsonConvert.SerializeObject(wheres));

                return this.Storage.Remove(wqpargs);
            }
            return false;
        }

        public virtual bool Contains(object wheres)
        {
            if (this.Storage == null) { LogFactory.log4bao.Error("GenericService.Contains Database.Storage is null"); }
            else if (wheres == null) { LogFactory.log4bao.Error("GenericService.Contains params [wheres] is null"); }
            else
            {
                IDictionary<string, object> wqpargs = JsonConvert.DeserializeObject<IDictionary<string, object>>(JsonConvert.SerializeObject(wheres));

                return this.Storage.Count(wqpargs) > 0;
            }
            return false;
        }

        public virtual T Find(long id)
        {
            if (this.Storage == null) { LogFactory.log4bao.Error("GenericService.Find Database.Storage is null"); }
            else if (id <= 0) { LogFactory.log4bao.Error("GenericService.Find params [id] is null"); }
            else
            {
                IDictionary<string, object> wheres = new Dictionary<string, object>();
                wheres.Add(this.Storage.DbTable.PKey, id);

                return this.Storage.Find(wheres);
            }
            return default(T);
        }

        public virtual T Find(object wheres)
        {
            if (this.Storage == null) { LogFactory.log4bao.Error("GenericService.Find Database.Storage is null"); }
            else if (wheres == null) { LogFactory.log4bao.Error("GenericService.Find params [wheres] is null"); }
            else
            {
                IDictionary<string, object> wqpargs = JsonConvert.DeserializeObject<IDictionary<string, object>>(JsonConvert.SerializeObject(wheres));

                return this.Storage.Find(wqpargs);
            }
            return default(T);
        }

        public virtual IEnumerable<T> Filter(object wheres = null, string orderby = "", int page = 1, int limit = 20)
        {
            if (this.Storage == null)
            {
                LogFactory.log4bao.Error("GenericService.Find Database.Storage is null");
                return new List<T>();
            }

            IDictionary<string, object> wqpargs = new Dictionary<string, object>();
            if (wheres != null)
            {
                wqpargs = JsonConvert.DeserializeObject<IDictionary<string, object>>(JsonConvert.SerializeObject(wheres));
            }

            return this.Storage.Filter(wqpargs, "*", orderby, page, limit);
        }


        public void Dispose()
        {
            this.Storage.Dispose();
        }
    }
}
