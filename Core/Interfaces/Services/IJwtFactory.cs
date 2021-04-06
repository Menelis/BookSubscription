using Core.Dto;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    /// <summary>
    /// Service for Generating Jwt Token
    /// </summary>
    public interface IJwtFactory
    {
        Task<Token> GenerateEncodedToken(string id);
    }
}
