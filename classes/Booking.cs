using OEFC_Manager.classes;
using System;

namespace OEFC_Manager
{
    public class Booking
    {
        public Participants participants { get; set; }
        public Customer customer { get; set; }
        public string productId { get; set; }
        public string giftVoucherCodeInput { get; set; }
        public BookingOption[] options { get; set; }
        public string eventId { get; set; }

    }
}
