﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("Channel")]
    public class Channel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Type { get; set; }

        public string Name { get; set; }

        public int Version { get; set; }

        public virtual ICollection<ChannelMessage> Messages { get; set; }

        public virtual ICollection<ChannelUser> Users { get; set; }
    }
}
