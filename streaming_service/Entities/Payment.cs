using System;
using System.Collections.Generic;

namespace streaming_service.Entities
{
    public partial class Payment
    {
        public uint PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public double TotalAmount { get; set; }
        public uint TransactionId { get; set; }
        public string PaymentStatus { get; set; } = null!;
        public uint UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
