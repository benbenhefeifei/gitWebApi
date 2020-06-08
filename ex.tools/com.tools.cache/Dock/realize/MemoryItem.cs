using System;
using System.Runtime.Caching;

namespace com.xbao.tools.cache.dock
{
    /// <summary>
    /// 
    /// </summary>
    internal class MemoryItem : ICacheMem , IDisposable
    {
        private ObjectCache Cache = null;

        public MemoryItem()
        {
            this.Cache = MemoryCache.Default;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool Contains(string key)
        {
            return this.Cache.Contains(key);
        }

        public string Get(string key)
        {
            CacheItem item = this.Cache.GetCacheItem(key);
            return (item.Value ?? "").ToString();
        }

        public T Get<T>(string key) where T : class
        {
            CacheItem item = this.Cache.GetCacheItem(key);
            if (item.Value != null) { return (T)item.Value; }
            return default(T);
        }

        public void Remove(params string[] keys)
        {
            foreach (var key in keys) { this.Cache.Remove(key); }
        }

        public void RemoveAll()
        {
            foreach (var item in this.Cache)
            {
                this.Cache.Remove(item.Key);
            }
        }

        public bool Set(string key, string value)
        {
            return Set<string>(key, value);
        }

        public bool Set(string key, string value, int minute)
        {
            return Set<string>(key, value, minute);
        }

        public bool Set(string key, string value, DateTime expiresAt)
        {
            return Set<string>(key, value, expiresAt);
        }

        public bool Set<T>(string key, T value) where T : class
        {
            return Set(key, value, 120);
        }

        public bool Set<T>(string key, T value, int minute) where T : class
        {
            return Set(key, value, DateTime.Now + TimeSpan.FromMinutes(minute));
        }

        public bool Set<T>(string key, T value, DateTime expiresAt) where T : class
        {
            CacheItemPolicy policy = new CacheItemPolicy() { AbsoluteExpiration = expiresAt };
            this.Cache.Add(new CacheItem(key, value), policy);
            return true;
        }
    }
}
