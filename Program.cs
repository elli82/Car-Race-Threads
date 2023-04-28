using Car_Race_Threads;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    
    public static void Main(string[] args)
    {
        Car car1 = new Car("Toyota", 120);
        Car car2 = new Car("Ford", 120);
        Car car3 = new Car("Kia", 120);              

        List<Car> listofCars = new List<Car>();

        Console.WriteLine("The race is about to start!");
        Console.WriteLine("For status of the race, press any key at any time");

        Thread cc1 = new Thread(() => { Car.RaceCars(car1,listofCars); });  
        Thread cc2 = new Thread(() => { Car.RaceCars(car2, listofCars); });
        Thread cc3 = new Thread(() => { Car.RaceCars(car3, listofCars); });

        Thread cc4 = new Thread(() => { CheckStatus(car1, car2, car3); });

        cc1.Start();
        cc2.Start();
        cc3.Start();
        cc4.Start();
        

        cc1.Join();
        cc2.Join();
        cc3.Join();

        Console.WriteLine("The race is finished!!");

        if (listofCars.Count > 0)       // den bil som ligger först i listan skrivs ut som vinnare
        {
            Console.WriteLine("The winner is: {0}! Congratulations!", listofCars[0].Name);
        }
      
    }

    public static void CheckStatus(Car car1, Car car2, Car car3)  
    {
        while (car1.distancetoRace !=10)
        {

            Console.ReadKey();  //tar vilken knapptryckning som helst

            Console.WriteLine("{0}: Distance: {1} km Speed:{2}", car1.Name, car1.distancetoRace, car1.Speed);
            Console.WriteLine("{0}: Distance: {1} km Speed:{2}", car2.Name, car2.distancetoRace, car2.Speed);
            Console.WriteLine("{0}: Distance: {1} km Speed:{2}", car3.Name, car3.distancetoRace, car3.Speed);
        }
        
    }
}