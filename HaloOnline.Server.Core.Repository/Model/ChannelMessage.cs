﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("ChannelMessage")]
    public class ChannelMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ChannelId { get; set; }

        [ForeignKey("ChannelId")]
        public virtual Channel Channel { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public string Text { get; set; }

        public DateTime Timestamp { get; set; }

        public int Version { get; set; }
        public string ChannelName { get; set; }
    }
}