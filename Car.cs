using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Car_Race_Threads //Elin Linderholm SUT22
{
    public class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int distancetoRace =0;

        public Car(string _name, int _speed)
        {
            Name = _name;   
            Speed = _speed;
        }
        public static void RaceCars(Car car, List<Car> listofCars)
        {
            
            Console.WriteLine("The {0} starts to race!", car.Name);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(car.Name);
                Thread.Sleep(TimeSpan.FromSeconds(5));  // händelse ska inträffa vid särskilt intervall
                CarTrouble(car);                        //metod för händelser
                car.distancetoRace += 1;                
            }
            

            listofCars.Add(car);  // när en bil är i mål läggs den till i listan
            
            Console.WriteLine("{0} has finished!", car.Name);
        }
        public static void CarTrouble(Car car)
        {                       
                Random random = new Random();

                int n = random.Next(1, 51);
                //int s = random.Next(1, 25);
                //int p = random.Next(1, 11);
                //int q = random.Next(1, 6);

                if (n == 1)
                {
                    Console.WriteLine("Oops,{0} needs to refuel! 30 s delay!", car.Name);
                    Thread.Sleep(3000);
                }
                if (n <= 2)
                {
                    Console.WriteLine("Squuech,{0} seems to be in need of new tires! 20 s delay", car.Name);
                    Thread.Sleep(2000);
                }
                if (n <= 5)
                {
                    Console.WriteLine("Holy ***, {0} just smashed a bird on the windshield...10 s delay", car.Name);
                    Thread.Sleep(1000);
                }
                if (n <= 10)
                {
                    car.Speed = car.Speed - 1;
                    Console.WriteLine("Oh, {0} seems to be having some trouble with the engine, speed must be down to {1} km/h", car.Name, car.Speed);
                    Thread.Sleep(10);
                }        
        }        
    }  
}
