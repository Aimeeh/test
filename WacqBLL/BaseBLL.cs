using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WacqDalFactory;
using WacqIBLL;
using WacqIDAL;

namespace WacqBLL
{
    public class BaseBLL<T> : IBaseBLL<T> where T : class
    {
        IBaseDal<T> dal = Factory<T>.CreatBasedalInstance();
        public List<T> Query(Expression<Func<T, bool>> where)
        {
            return dal.Query(where);
        }
    }
}
