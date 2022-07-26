using System;

namespace OEFC_Manager
{
    class Payment
    {
        public string id { get; set; }
        public DateTime creationTime { get; set; }
        public DateTime receivedTime { get; set; }
        public string reason { get; set; }
        public string code { get; set; }
        public string amount { get; set; }
        public string paymentMethod { get; set; }
        public string customer { get; set; }
        public string customerId { get; set; }
        public string gatewayName { get; set; }
        public string transactionId { get; set; }

    }
}
