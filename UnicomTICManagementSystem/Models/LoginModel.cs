using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Enums;

namespace UnicomTICManagementSystem.Models
{
    public class LoginModel
    {
        public int UserId { get; set; }
        public UserRole UserRole { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
    }
}
