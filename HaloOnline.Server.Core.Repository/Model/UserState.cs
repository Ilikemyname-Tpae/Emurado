using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("UserStates")]
    public class UserState
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string StateName { get; set; }
        public int StateType { get; set; }
        public int OwnType { get; set; }
        public int Value { get; set; }
    
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
