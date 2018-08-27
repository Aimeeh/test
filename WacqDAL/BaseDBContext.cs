using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WacqDAL
{
    using System.Data.Entity;
    /// <summary>
    /// 自定义的EF上下文类
    /// 注意：此类中没有相关表的DbSet<T> 对象
    /// </summary>
    public class BaseDBContext:DbContext
    {
        public BaseDBContext()
            : base("name=RWEntities")
        {

        }
    }
}
