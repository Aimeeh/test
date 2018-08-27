using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WacqDAL
{
    using WacqIDAL;
    /// <summary>
    /// 定义统一的BaseDal泛型类，实现数据库中所有表的统一的增、删、查、改功能
    /// </summary>
    /// <typeparam name="T">T:类型只能传入的是EF实体模板中生成的实体类名称</typeparam>
    public class BaseDal<T>:IBaseDal<T> where T:class
    {
        /// <summary>
        /// 1.0实例化EF上下文容器对象
        /// </summary>
        BaseDBContext db = new BaseDBContext();

        DbSet<T> _dbset;

        public BaseDal()
        {
            _dbset = db.Set<T>();
        }

        public List<T> Query(Expression<Func<T,bool>> where)
        {
            return _dbset.Where(where).ToList();
        }
    }
}
