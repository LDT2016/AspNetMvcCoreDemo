using System.Threading.Tasks;

namespace ApiDemo.Services.Interface
{
    public interface IConfigIdService
    {
        Task<string> GetNewConfigId();
    }
}
