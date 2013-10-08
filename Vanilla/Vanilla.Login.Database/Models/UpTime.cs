using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Login.Database.Models
{

	    [Table("uptime", Schema="realmd")]

    public class UpTime
    {
 
        [Column("realmid")] 
		        public long RealmID { get; set; }
 
        [Column("starttime")] 
		        public decimal StartTime { get; set; }
 
        [Column("startstring")] 
		        public string StartString { get; set; }
 
        [Column("uptime")] 
		        public decimal UpTime1 { get; set; }
 
        [Column("maxplayers")] 
		        public int MaxPlayers { get; set; }
    }
}