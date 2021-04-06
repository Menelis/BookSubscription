using Common.Extensions;
using Core.Dto;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infastructure.Auth
{
    /// <summary>
    /// IJwtFactory implementer to generate token
    /// </summary>
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly IUserRepository _userRepository;
        public JwtFactory(IOptions<JwtIssuerOptions> options,
            IUserRepository userRepository)
        {
            _jwtOptions = options.Value;
            _userRepository = userRepository;
            ThrowIfInvalidOptions(_jwtOptions);
        }
        public async Task<Token> GenerateEncodedToken(string id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null) throw new Exception($"No user found with : {id}");
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("FullName", $"{user.FirstName} {user.LastName}")
            };

            //Generate the JWT security token and encode it
            var jwt = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                claims,
                _jwtOptions.NotBefore,
                _jwtOptions.Expiration,
                GetSigningCredentials());

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new Token(id, encodedJwt, (int)_jwtOptions.ValidFor.TotalSeconds);
        }
        private SigningCredentials GetSigningCredentials() => new SigningCredentials(CustomLinqExtensions.GetSymmetricSecurityKey(_jwtOptions.SecretKey), SecurityAlgorithms.HmacSha256);
        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero) throw new ArgumentException("Must be a non-zero TimeSpace", nameof(JwtIssuerOptions.ValidFor));

            //if (options.SigningCredentials == null) throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));

            //if (options.JtiGenerator == null) throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));


        }
    }
}
