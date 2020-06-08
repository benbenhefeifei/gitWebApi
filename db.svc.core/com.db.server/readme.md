# 数据业务逻辑处理层

-1.使用 接口+通用实现 处理基本操作
-2.接口继承 com.db.storage（可以跳过）
-3.接口命名空间 com.xbao.db.server

### model 接口使用基础数据模型（可公共调用）

model/BasePage 数据分页查询，继承与 BaseQuery     
model/BaseQuery 数据基础查询  

### 业务处理服务（公共调用）

com.xbao.db.server.IService 业务基础操作功能接口 
com.xbao.db.server.GenericService 业务基础操作功能接口实现，依赖【数据仓储】接口    

### 数据仓储服务
> 接口案例
```C#
public interface IService<T> : System.IDisposable where T : class
{
    ... 此处省略函数方法.
}
```
> 接口实现案例
```C#
using com.xbao.db.storeage;
public class GenericService<T> : IService<T> where T : class
{
    /// <summary>
    /// 数据仓储对象（读写）
    /// </summary>
    public IRepository<T> Storage { get; private set; }    
    /// <summary>
    /// 初始化服务，并设置依赖仓储
    /// </summary>
    /// <param name="name">数据表名</param>
    public GenericService(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            this.Storage = new GenericRepository<T>(name);
        }
    }
    /// <summary>
    /// 初始化服务，并设置依赖仓储
    /// </summary>
    /// <param name="storeage">数据表对应仓储实现</param>
    public GenericService(GenericRepository<T> storage)
    {
        if (storage != null) { this.Storage = storage; }
    }

    ... 此处省略接口函数方法实现.
}
```

### 服务调用案例 
```C#
using com.xbao.db.server;
using com.xbao.db.storage;
public class TestBLL : GenericService<TestInfo>, IService<TestInfo>
{
    /// <summary>
    /// 初始化 依赖仓储
    /// </summary>
    public TestBLL() : base(new test.TestDAL())
    {
        // 也可以直接使用 TestBLL() : base("test")
        // 然后此函数 必须实现 以下处理
        // base.Storage.DbTable.Name = "";
        // base.Storage.DbTable.PKey = "";
        // base.Storage.DbTable.AutoNumber = true;
        // base.Storage.DbTable.Fields = "".Split(',').ToList();
    }

    #region 使用单例设计模式 获取服务对象
    static TestBLL _Instance = null;
    static readonly object _lock = new object();
    public static TestBLL Instance
    {
        get
        {
            if (_Instance == null)
            {
                lock (_lock)
                {
                    if (_Instance == null)
                    {
                        _Instance = new TestBLL();
                    }
                }
            }
            return _Instance;
        }
    }
    #endregion
}
```