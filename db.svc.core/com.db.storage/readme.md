# 数据库操作底层

-1.使用 接口+通用实现 处理基本操作
-2.接口继承 com.db.storage
-4.接口命名空间 com.xbao.db.storeage

### 数据仓储服务（公共调用）

com.xbao.db.storeage.IRepository 数据库表基础操作接口，依赖与【数据库操作辅助】接口  
com.xbao.db.storeage.GenericRepository 数据库表基础操作接口实现（依赖接口IRepository）    

### 数据库操作服务     
> 接口应用
```C#
public interface IRepository<T> : IDbHelper, System.IDisposable where T : class
{
    ... 此处省略函数方法.
}
```
> 接口实现应用
```C#
public class GenericRepository<T> : GenericDbHelper, IRepository<T> where T : class
{
    /// <summary>
    /// 数据表信息
    /// </summary>
    public core.GenericDbTable DbTable { get; set; }
    /// <summary>
    /// 初始化数据仓储
    /// </summary>
    /// <param name="dbName">数据库名称</param>
    public GenericRepository(string dbName) : base(dbname)
    {
        this.DbTable = new core.GenericDbTable();
        this.DbTable.EType = core.EDbType.MYSQL;
    }

    ... 此处省略函数方法.
}
```

### 仓储调用案例
```C#
public class TestDAL : GenericRepository<TestInfo>, IRepository<TestInfo>
{
    /// <summary>
    /// 初始化 数据表信息
    /// </summary>
    public TestDAL() : base("test")
    {
        base.DbTable.Name = "";
        base.DbTable.PKey = "";
        base.DbTable.AutoNumber = true;
        base.DbTable.Fields = "".Split(',').ToList();
    }    
}
```