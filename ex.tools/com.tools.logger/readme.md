# 日志工具

-1.支持log4net日志
-2.支持file自定义日志
-3.接口命名空间 com.xbao.tools.logger

### 日志工厂

*输出以下三个缓存机制 ，Redis 缓存，Memcached 缓存，Memory 缓存*

> 使用案例
```C#
com.xbao.tools.logger.LogFactory.log4net.info("");
com.xbao.tools.logger.LogFactory.log4bao.info("");
```
> 需在终端项目 web.config 或 app.config 下的 appSettings 中增加如下配置
```html
<add name="Log:Custom.Config" value="Switch=|Level=info|Path=|Content=%d [%t] %-5p %c ：%m %n" />
<add name="Log:Log4net.Config" value="Switch=|Name=|Path=" />
```
