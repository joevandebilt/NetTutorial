using System;
using System.Collections.Generic;
using System.Text;

namespace NetTutorial.Generics.Types.DB
{
    public interface IRepository<T>
    {
        int Insert(T newRecord);
        int Update(T existingRecord);
        bool Delete(T recordToDelete);
    }
}
