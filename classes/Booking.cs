namespace OEFC_Manager.Classes
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
