using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem.Models
{
    internal class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
       
    }
}
