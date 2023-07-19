using UserCloneApp.Domain.Models.ConstantModels;

namespace UserCloneApp.Domain.Exceptions
{
    public class ClientSideException : BaseException
    {
        public ClientSideException(ExceptionConstantModel exceptionConstantModel) : base(exceptionConstantModel)
        {
        }
    }
}
