using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Common.Extensions
{
    public static class CustomLinqExtensions
    {
        /// <summary>
        /// Returns true if value is not null or empty or white space else false
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmptyOrWhiteSpace(this string value) => string.IsNullOrEmpty(value?.Trim());
        /// <summary>
        /// Generate Secret Key
        /// </summary>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        public static SymmetricSecurityKey GetSymmetricSecurityKey(string secretKey) => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
    }
}
