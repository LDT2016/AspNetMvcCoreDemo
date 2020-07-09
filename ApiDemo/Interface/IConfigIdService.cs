using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Interface
{
    public interface IConfigIdService
    {
        Task<string> GetNewConfigId();
    }
}
