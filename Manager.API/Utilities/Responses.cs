using Manager.API.ViewModels;
using System.Collections.Generic;

namespace Manager.API.Utilities
{
    public static class Responses
    {
        public static ResultViewModel ApplicationErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "A error ocurred in the application, please try again.",
                Success = false,
                Data = null
            };

            
        }

        public static ResultViewModel DomainErrorMessage(string message)
        {
            return new ResultViewModel
            {
                Message = message,
                Success = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModel
            {
                Message = message,
                Success = false,
                Data = errors
            };
        }

        public static ResultViewModel UnauthorizedErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "Login or password are incorrect!",
                Success = false,
                Data = null
            };
        }
    }
}
