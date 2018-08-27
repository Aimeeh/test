using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WacqIDAL
{
    public interface IBaseDal<T> where T:class
    {
        List<T> Query(Expression<Func<T, bool>> where);
    }
}
