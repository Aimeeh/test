using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WacqIBLL
{
    public interface IBaseBLL<T> where T:class
    {
        List<T> Query(Expression<Func<T, bool>> where);
    }
}
