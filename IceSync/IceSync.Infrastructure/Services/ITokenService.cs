using System.Threading.Tasks;

namespace IceSync.Infrastructure.Services
{
    public interface ITokenService
    {
        bool TokenIsValid(string token);

        Task<string> GetToken();
    }
}
