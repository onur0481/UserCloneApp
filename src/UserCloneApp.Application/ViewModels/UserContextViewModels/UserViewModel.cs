using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserCloneApp.Application.ViewModels.UserContextViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public UserViewModel(string id, DateTime createdDate, string name, string surname, string email) : base(id,createdDate)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
