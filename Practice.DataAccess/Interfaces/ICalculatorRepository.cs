using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.DataAccess.Interfaces
{
    public interface ICalculatorRepository
    {
        void InsertLogInDb(int a, int b, string operation, int result);
    }
}
