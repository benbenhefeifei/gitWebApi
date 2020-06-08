using System;

namespace com.xbao.tools.cache
{
    /// <summary>
    /// CacheFactory --- 缓存 工厂
    /// ，Redis 缓存
    /// ，Memcached 缓存
    /// ，Memory 缓存
    /// </summary>
    public class CacheFactory
    {
        #region 使用单例设计模式 获取Redi缓存
        static IRedisCache _Redis = null;
        static readonly object _redisLock = new object();
        /// <summary>
        /// Redis缓存机制
        /// </summary>
        public static IRedisCache Redis
        {
            get
            {
                if (_Redis == null)
                {
                    lock (_redisLock)
                    {
                        if (_Redis == null)
                        {
                            _Redis = new RedisCache();
                        }
                    }
                }
                return _Redis;
            }
        }
        #endregion

        #region 使用单例设计模式 获取 Memcached 缓存
        static dock.ICacheMem _Memcache = null;
        static readonly object _memcacheLock = new object();
        /// <summary>
        /// Memcached 内存集缓存机制
        /// </summary>
        public static dock.ICacheMem Memcached
        {
            get
            {
                if (_Memcache == null)
                {
                    lock (_memcacheLock)
                    {
                        if (_Memcache == null)
                        {
                            _Memcache = new dock.MemcachedItem();
                        }
                    }
                }
                return _Memcache;
            }
        }
        #endregion

        #region 使用单例设计模式 获取 Memory 缓存
        static dock.ICacheMem _Memory = null;
        static readonly object _memoryLock = new object();
        /// <summary>
        /// 服务器内存集缓存机制
        /// </summary>
        public static dock.ICacheMem Memory
        {
            get
            {
                if (_Memory == null)
                {
                    lock (_memoryLock)
                    {
                        if (_Memory == null)
                        {
                            _Memory = new dock.MemoryItem();
                        }
                    }
                }
                return _Memory;
            }
        }
        #endregion

    }

    /// <summary>
    /// Redis 缓存接口
    /// </summary>
    public interface IRedisCache
    {
        public dock.ICacheItem Item { get; set; }

        public dock.ICacheList List { get; set; }

        public dock.ICacheHash Hash { get; set; }
    }
    /// <summary>
    /// Redis 缓存
    /// </summary>
    internal class RedisCache : IRedisCache
    {
        internal RedisCache()
        {
            this.Item = new dock.RedisItem();

            this.List = new dock.RedisList();

            this.Hash = new dock.RedisHash();
        }

        public dock.ICacheItem Item { get; set; }
        public dock.ICacheList List { get; set; }
        public dock.ICacheHash Hash { get; set; }
    }
}
