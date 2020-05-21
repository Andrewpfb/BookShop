using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Service.Interfaces
{
    public interface ICommonService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Add(T addingObject);
        void Delete(int id);
        void Update(T updatingObject);
    }
}
