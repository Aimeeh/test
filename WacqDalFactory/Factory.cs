using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WacqDalFactory
{
    using System.Reflection;
    using WacqDAL;
    using WacqIDAL;
    public class Factory<T> where T:class
    {
        /// <summary>
        /// 创建Basedal泛型类的对象，以IBaseDal泛型接口返回
        /// </summary>
        /// <returns></returns>
        public static IBaseDal<T> CreatBasedalInstance()
        {
            //缺点：如果直接使用new BaseDal<T>();会导致数据工厂紧依赖与数据库访问层
            //return new BaseDal<T>();
            //解决方案：使用反射动态创建BaseDal<T>泛型类的对象实例

            //1.0确定当前T的Type类型
            Type[] ttype = new Type[] {typeof(T) };
            //2.0获取当前程序集
            //2.0.1获取数据库访问层程序集的名称
            string assName = "WacqDAL";
            //2.0.2根据程序集名称将其加载到Assembly对象中
            Assembly ass = Assembly.Load(assName);
            //2.0.3获取泛型类BaseDal<T>的封闭类型的type
            Type basedalType = ass.GetType(assName+".BaseDal`1");
            //2.0.4调用MakeGenericType方法将当前BaseDal<T>的类型占位符的具体type类型加入到basedal的type类型
            basedalType = basedalType.MakeGenericType(ttype);
            //3.0通过反射的方式创建BaseDal`1类的对象实例
            object obj = Activator.CreateInstance(basedalType);
            return obj as IBaseDal<T>;
        }
    }
}
