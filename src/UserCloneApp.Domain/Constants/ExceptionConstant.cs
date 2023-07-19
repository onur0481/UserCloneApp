using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCloneApp.Domain.Models.ConstantModels;

namespace UserCloneApp.Domain.Constants
{
    public static class ExceptionConstant
    {
        public static readonly ExceptionConstantModel ServerSideError = new("24001","An error has occurred with the server!");

        public static readonly ExceptionConstantModel TokenError = new("24002", "Please login, then try again!");
    }
}
