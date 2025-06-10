using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem.Models
{
    internal class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string PassAdd { get; set; }
        public string Role { get; set; }
        
    }
}
