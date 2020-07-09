using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Library.Contracts
{
    public interface IConfigId
    {
        Task<string> GetNewConfigId();
    }
}
