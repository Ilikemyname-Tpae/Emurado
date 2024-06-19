using System.ComponentModel.DataAnnotations;

namespace HaloOnline.Server.Core.Repository.Model
{

    public class ItemOffer
    {
        [Key]
        public string ItemId { get; set; }
        public int Price { get; set; }
    }
}