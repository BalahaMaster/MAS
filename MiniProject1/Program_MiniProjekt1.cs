using System;
using System.Collections.Generic;

namespace MiniProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            Address add1 = new Address("Liliowa", "25A", "Warszawa", "Polska", "05-666");
            Address add2 = new Address("Tulipanowa", "2", "9", "Olsztyn", "Polska", "21-370"); //Wywołanie konstruktora przyjmującego atrybut opcjonalny
            Console.WriteLine("add2 flat number: " + add2.FlatNumber); //Wypisanie atrybutu opcjonalnego klasy 'Address'.

            Consignment c1 = new Consignment(23.5);
            Consignment c2 = new Consignment(13.8);
            Package p1 = new Package(11.0, 12.3, 10.0, 13.8); //p1 i c2 mają dokładnie taką samą wagę = 13.8

            Shipment s = new Shipment(add1, add2, new List<Consignment> { c1 });
            s.Consignments.Add(p1); //Dodanie kolejnej wartości do atrybutu powtarzalnego.

            Console.WriteLine("Price for consignment = {0}", c1.Price); 
            s.Consignments.Remove(p1);
            s.Consignments.Add(c2);
            Console.WriteLine("Price for package = {0}", p1.Price); // Wywołanie przesłoniętego atrybutu
            Console.WriteLine("Show sender address:\n{0}", s.SenderAddress.FullAddress); //Wypisanie atrybutu pochodnego klasy 'Address' dla atrybutu złożonego klasy 'Shipment'.

            Console.WriteLine("Weight of all consignments {0}", Consignment.GetAllWeightsSum()); //Wywołanie metody klasowej.
            



            Console.WriteLine("Saving Extensions");
            ObjectPlus.SaveExtensions(); //Zapisanie ekstensji do pliku - trwałość ekstensji.
            Address add3 = new Address("Kopernika", "36", "Warszawa", "Polska", "00-328"); //Stworzenie nowego adreu, który nie został zapisany.

            Console.WriteLine("Show all extensions");
            ObjectPlus.ShowExtension(); //Wypisanie wszystkich esktensji - widać 3 adresy.

            ObjectPlus.ReadExtensions(); //Wczytanie ostatnio zapisanej ekstensji.

            Console.WriteLine("Show all extensions");
            ObjectPlus.ShowExtension(); //Wypisanie wszystkich ekstensji po wczytaniu jej z pliu - widać 2 adresy.

            Console.WriteLine("Show Shipment extensions");
            ObjectPlus.ShowExtension(typeof(Shipment)); //Przeciążenie metody ShowExtension() z klasy Object plus

            Consignment.PriceModifier = 1.7; //Zmiana wartości atrybutu klasowego 


            
        }
    }
}
