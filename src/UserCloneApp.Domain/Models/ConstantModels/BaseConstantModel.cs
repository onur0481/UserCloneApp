using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCloneApp.Domain.Models.ConstantModels
{
    public abstract class BaseConstantModel
    {
        public string Code { get; set; }

        public string Message { get; set; }

        protected BaseConstantModel(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
