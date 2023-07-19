using UserCloneApp.Domain.Models.ConstantModels;

namespace UserCloneApp.Domain.Exceptions
{
    public class ServerSideException : BaseException
    {
        public ServerSideException(ExceptionConstantModel exceptionConstantModel) : base(exceptionConstantModel)
        {
        }
    }
}
