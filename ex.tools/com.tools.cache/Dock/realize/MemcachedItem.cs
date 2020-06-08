using System;
using System.Collections.Generic;

namespace com.xbao.tools.cache.dock
{
    /// <summary>
    /// 
    /// </summary>
    internal class MemcachedItem : help.MemcachedHelper, ICacheMem, IDisposable
    {
        public MemcachedItem() : base()
        {
        }

        public bool Contains(string key)
        {
            return this.MemcachedKeys(null).Contains(key);
        }

        public string Get(string key)
        {
            return string.Empty; // base.Core.Get<string>(key.Prefix());
        }

        public T Get<T>(string key) where T : class
        {
            return default(T); // base.Core.Get<T>(key.Prefix());
        }

        public void Remove(params string[] keys)
        {
            foreach (string key in keys)
            {
                //if (base.Core.Remove(key.Prefix()))
                //{
                //    this.MemcachedKeys(key, false);
                //}
            }
        }

        public void RemoveAll()
        {
            //base.Core.FlushAll();
            //base.Core.Remove("memcache_allkeys");
        }

        public bool Set(string key, string value)
        {
            return this.Set(key, value, 120);
        }

        public bool Set(string key, string value, int minute)
        {
            return this.Set(key, value, DateTime.Now + TimeSpan.FromMinutes(minute));
        }

        public bool Set(string key, string value, DateTime expiresAt)
        {
            this.MemcachedKeys(key, true);
            return false; // this.Core.Store(StoreMode.Set, key.Prefix(), value, expiresAt);
        }

        public bool Set<T>(string key, T value) where T : class
        {
            return this.Set(key, value, 120);
        }

        public bool Set<T>(string key, T value, int minute) where T : class
        {
            return this.Set(key, value, DateTime.Now + TimeSpan.FromMinutes(minute));
        }

        public bool Set<T>(string key, T value, DateTime expiresAt) where T : class
        {
            this.MemcachedKeys(key, true);
            return false; // this.Core.Store(StoreMode.Set, key.Prefix(), value, expiresAt);
        }

        private List<string> MemcachedKeys(string key, bool isadd = true)
        {
            List<string> values = new List<string>(); // base.Core.Get<List<string>>("memcache_allkeys");
            if (values == null) { values = new List<string>(); }
            if (!string.IsNullOrEmpty(key))
            {
                if (isadd) { values.Add(key); } else { values.Remove(key); }
                DateTime expireAt = DateTime.Now + TimeSpan.FromMinutes(60 * 24 * 7);
                // this.Core.Store(StoreMode.Set, "memcache_allkeys", values, expireAt);
            }
            return values;
        }
    }
}
