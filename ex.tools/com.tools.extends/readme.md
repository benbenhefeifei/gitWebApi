# 对象属性扩展

-1.支持Redis缓存
-2.支持Memcached缓存
-3.支持memory内存缓存
-4.接口命名空间 System

> 使用案例
```C#
"2020-02-02".ToDateTime();
string value = entity.GetValueByProp(key);
entity.SetValueByProp(key, value);
(new { name:"test" }).ToJsonString();
```
