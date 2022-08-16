using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{

    //Bu sınıf içerisinde metodların imzaları generic olarak atıldı ve concrete alanında kullanılmak üzere hazırlandı.
    public interface IEntityRepository<T>
    {
        List<T> List();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(Expression<Func<T,bool>>filter);

        List<T> List(Expression<Func<T, bool>> filter);


    }
}
