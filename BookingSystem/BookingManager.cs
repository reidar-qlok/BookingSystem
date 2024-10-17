namespace BookingSystem
{
    public class BookingManager
    {
        private List<Booking> bookings;
        private readonly object lockObject = new object();
        public BookingManager()
        {
            bookings = new List<Booking>();
        }

        //Lägga tille en bokning trådsäkert
        public void AddBooking(string customerName)
        {
            lock (lockObject)
            {
                bookings.Add(new Booking(customerName));
                Console.WriteLine($"{customerName} har gjort en bokning");
            }
        }
        public void PrintBookings()
        {
            Console.WriteLine("Här har du alla bokningar");
            foreach (var booking in bookings)
            {
                Console.WriteLine(booking);
            }
        }
    }
}
