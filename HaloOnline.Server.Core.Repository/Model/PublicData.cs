using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("PublicData")]
    public class PublicData
    {
        [Key]
        public int UserId { get; set; }
        public string armor_loadouts { get; set; }
        public string customizations { get; set; }
        public string weapon_loadouts { get; set; }
        public string preferences { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}