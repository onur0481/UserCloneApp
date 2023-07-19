using UserCloneApp.Domain.Models.ConstantModels;

namespace UserCloneApp.Domain.Exceptions
{
    public class BaseException : Exception
    {
        public string Code { get; set; }

        public BaseException(ExceptionConstantModel exceptionConstantModel) : base(exceptionConstantModel.Message)
        {
            Code = exceptionConstantModel.Code;
        }
    }
}
