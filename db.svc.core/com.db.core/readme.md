# 数据库操作底层

-1.使用 Dapper 底层作为数据库操作引擎，
-2.使用 外部 config 文件处理 数据库连接字符串
-3.使用读写分离的Command处理数据业务
-4.接口命名空间 com.xbao.db.core

### model 接口使用基础数据模型（可公共调用）

model/DbEnum 数据库操作枚举    
model/DbTable 数据仓储使用的表模型    
model/MyParameter 数据操作参数模型  
model/DbConfig 数据库链接串数据模型(Xml序列号使用)     

### tools 数据库服务扩展组件（内部调用）

tools/Logger 数据库操作日志    
tools/QQTools 数据库链接串加密解密    
tools/ConfigManager 数据库链接串配置管理，支持外部config配置     

### context 数据服务请求上下文（内部调用）

context/GenericDbContext 数据库操作上下文通用服务实现（仅提供数据库上下午链接）    

### command 数据库操作命令执行（公共调用）

command/IWriter 数据写业务接口，    
command/IReader 数据读业务接口，    
command/realize/GenericWriter 数据写入功能实现（继承GenericDbContext数据库上下文，依赖接口IWriter），   
command/realize/GenericReader 数据读取功能实现（继承GenericDbContext数据库上下文，依赖接口IReader）。   

### helper 数据库操作服务（公共调用）

helper/IDbHelper 数据库操作接口，依赖与【数据库操作命令执行】接口   
helper/realize/GenericDbHelper 数据库读写接口实现（依赖接口IDbHelper）     

需在终端项目 web.config 或 app.config
> 下的ConnectionStrings 中增加如下配置
```html
<add name="ConnectionString_DbName_Reader" value="DataSource=app.db" />
<add name="ConnectionString_DbName_Writer" value="DataSource=app.db" />
```
> 或下的 appSettings 中增加如下配置
```html
<add name="MyDb.Config.Path" value="AppStartup/App_Data/mydb.config" />
```