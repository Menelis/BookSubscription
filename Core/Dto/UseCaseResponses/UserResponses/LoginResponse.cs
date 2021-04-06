using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Dto.UseCaseResponses.UserResponses
{
    public class LoginResponse : UseCaseResponseMessage
    {
        public Token Token { get; }
        public IEnumerable<Error> Errors { get; }
        public LoginResponse(IEnumerable<Error> errors,bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }
        public LoginResponse(Token token,bool success = false, string message = null) : base(success, message)
        {
            Token = token;
        }
    }
}
