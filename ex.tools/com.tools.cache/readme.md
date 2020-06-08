# 缓存机制

-1.支持Redis缓存
-2.支持Memcached缓存
-3.支持memory内存缓存
-4.接口命名空间 com.xbao.tools.cache

### Help 缓存辅助工具

Help/CacheExtention 缓存相关自定义扩展，如Key前缀扩展  
Help/RedisHelper Redis缓存客户端初始化  
Help/MemcachedHelper Memcached缓存客户端初始化  

### Dock 缓存接口及具体功能实现

Dock/ICacheMem 内存缓存及Memcached缓存功能接口     
Dock/ICacheItem Redis单项数据缓存接口   
Dock/ICacheList Redis集合数据缓存接口   
Dock/ICacheHash Redis哈希数据缓存接口   
Dock/ralise/RedisItem Redis单项数据缓存接口实现   
Dock/ralise/RedisList Redis集合数据缓存接口实现   
Dock/ralise/RedisHash Redis哈希数据缓存接口实现   
Dock/ralise/MemoryItem 内存缓存功能实现     
Dock/ralise/MemcachedItem Memcached缓存功能实现   

### 缓存工厂

*输出以下三个缓存机制 ，Redis 缓存，Memcached 缓存，Memory 缓存*

> 使用案例
```C#
com.xbao.tools.cache.CacheFactory.Redis.Item.Set(key, value);
com.xbao.tools.cache.CacheFactory.Redis.List.Add(key, value);
com.xbao.tools.cache.CacheFactory.Redis.Hash.Set(hashId, key, value);
com.xbao.tools.cache.CacheFactory.Memory.Set(key, value);
com.xbao.tools.cache.CacheFactory.Memcached.Set(key, value);
```
> 需在终端项目 web.config 或 app.config 下的 appSettings 中增加如下配置
```html
<add name="Redis:Server.Cache" value="127.0.0.1:6379@password" />
<add name="Memcached:Server.Cache" value="127.0.0.1:11211/user@password" />
```
