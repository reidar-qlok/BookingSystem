namespace BookingSystem
{
    public class Program
    {
        static BookingManager bookingManager = new BookingManager();
        static void Main(string[] args)
        {
            Console.WriteLine("Bokningarna börjar nu");
            // Skapar några trådar som bokar tider
            Thread thread1 = new Thread(() => MakeBooking("Tobias"));
            Thread thread2 = new Thread(() => MakeBooking("Anna"));
            Thread thread3 = new Thread(() => MakeBooking("Egon"));
            Thread thread4 = new Thread(() => MakeBooking("Mathilde"));
            Thread thread5 = new Thread(() => MakeBooking("Lydia"));

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            thread5.Join();


            // Visa alla bokningar
            bookingManager.PrintBookings();
            Console.WriteLine("Bokningarna är klara och vi avslutar");
        }
        static void MakeBooking(string customerName)
        {
            Console.WriteLine($"{customerName} gör en bokning");
            Thread.Sleep(new Random().Next(1000, 5000));
            bookingManager.AddBooking(customerName);
        }
    }
}
