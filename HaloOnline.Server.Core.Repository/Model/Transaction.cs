using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnline.Server.Core.Repository.Model
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public int UserId { get; set; }
        public string OfferId { get; set; }
        public int InitialValue { get; set; }
        public int ResultingValue { get; set; }
        public int DeltaValue { get; set; }
        public int OperationType { get; set; }
        public string SessionId { get; set; }
        public string ReferenceId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }


    [Table("TransactionHistory")]

    public class TransactionHistory
    {
        [Key]
        public int UserId { get; set; }
        public string StateName { get; set; }
        public int StateType { get; set; }
        public int OwnType { get; set; }
        public int OperationType { get; set; }
        public int InitialValue { get; set; }
        public int ResultingValue { get; set; }
        public int DeltaValue { get; set; }
        public int DescId { get; set; }
        public string SessionId { get; set; }
        public string ReferenceId { get; set; }
        public string OfferId { get; set; }
        public long TimeStamp { get; set; }
        public string ExtendedInfoKey { get; set; }
        public string ExtendedInfoValue { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}