using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Models;

namespace ApiDemo.Library.Contracts
{
    public interface ITestProductLib
    {
        Task<IList<TestProduct>> GetTestProduct();

    }
}
