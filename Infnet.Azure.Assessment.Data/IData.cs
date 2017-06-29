using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Azure.Assessment.Data
{
    public interface IData<T>
    {
        List<T> GetAll();

        T Get(int id);

        bool Update(int id, T entry);

        bool Delete(int id);

        bool Insert(T entry);
    }
}
