using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MiniProject4
{
    //ObjectPlus jest to klasa zarządzająca ekstensją
    [Serializable]
    public class ObjectPlus
    {
        //Kontener przechowujący ekstensjem
        public static Dictionary<Type, IList> Extensions
        {
            get;
            private set;
        } = new Dictionary<Type, IList>(); 
        private static string FileName
        {
            get { return Environment.CurrentDirectory + "\\object.bin"; }
            set { }
        }

        //W konstruktorze bezparametrowym wywoływana jest metoda dodająca obiekt do ekstensji 
        public ObjectPlus()
        {
            AddToExtension();
        }

        //Dodaje obiekt do esktensji
        private void AddToExtension() 
        {
            //Sprawdza czy w słowniku ekstensji, do tego typu już jest przypisany kontener zawierający estensję.
            //Tworzy nowy kontener jeżeli takiego nie było i dodaje ten obiekt do ekstensji
            IList temp;
            if (!Extensions.TryGetValue(this.GetType(), out temp))
                Extensions.Add(this.GetType(), new List<object> { this });
            else
                temp.Add(this);
        }

        //Zapewnia trwałość ekstensji
        public static void SaveExtensions()
        {
            //Towrzy obiekt formatujący grafy obiektów do serializacji oraz strumień do pliku
            IFormatter formatter = new BinaryFormatter();
            Stream output = new FileStream(FileName, FileMode.Create, FileAccess.Write);

            //Ponieważ nie jest możliwa serializacja typów, tworzony jest nowy słownik.
            //Klucze zamieniane są na obieklty klasy string, zawierające ich nazwę.
            Dictionary<string, IList> temp = new Dictionary<string, IList>();
            foreach(Type t in Extensions.Keys)
            {
                temp.Add(t.FullName, Extensions.GetValueOrDefault(t));
            }

            //Graf jest zapisywany do pliku i strumień jest zamykany.
            formatter.Serialize(output, temp);
            output.Close();
        }

        //Odczytuje ekstensję z pliku.
        public static void ReadExtensions() 
        {
            //Towrzy obiekt formatujący grafy obiektów do deserializacji oraz strumień z pliku
            IFormatter formatter = new BinaryFormatter();
            Stream input = new FileStream(FileName, FileMode.Open, FileAccess.Read);

            //Ze strumienia wczytywane są ekstensje do tymczasowego słownika 
            Dictionary<string, IList> temp = (Dictionary<string, IList>)formatter.Deserialize(input);

            //Tworzony jest nowy kontener przechowujący ekstensje 
            Extensions = new Dictionary<Type, IList>();

            //Ponieważ klucze ekstensji zostały skonwertowane na obiekty klasy string, należy je przekonwertować spowrotem do klasy 'Type'
            foreach (string t in temp.Keys)
            {
                Extensions.Add(Type.GetType(t), temp[t]);
            }
        }

        //Wypisuje wybraną ekstensję w terminalu
        public static void ShowExtension(Type key) 
        {
            //Jeżeli ekstensja dla danego typu istnieje wypisywana jest on w terminalu
            IList temp;
            if (Extensions.TryGetValue(key, out temp))
                foreach (object o in temp) Console.WriteLine(o + "_" + o.GetHashCode().ToString());
            else
                Console.WriteLine(String.Format("No object with type: '{0}' created.", key));
        }

        //Przeciążenie metody ShowExtension(Type key), która nie przyjmuje żadnego paramteru i 'drukuje' ekstensje wszystkich klas dziedziczących po ObjectPlus
        public static void ShowExtension() 
        {
            foreach (Type key in Extensions.Keys) ShowExtension(key);
        }
    }
}
