
using System;

namespace MiniProject2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Address add1 = new Address("Liliowa", "25A", "Warszawa", "Polska", "05-666");
            Address add2 = new Address("Tulipanowa", "2", "9", "Olsztyn", "Polska", "21-370");

            Shipment ship1 = new Shipment { PickupAddress = add1, SenderAddress = add2 }; //Asocjacja binarna skierowana, Obiekt klasy shipment jest powiązany z 2 obiektamy klasy address, który występuje w dwóch różnych rolach
            
            
        }
    }
}
