namespace csharp_lista_indirizzi
{
    internal class Program
    {
        public static List<Indirizzo> indirizzo = new List<Indirizzo>();
        public static string path = "C:\\Users\\User\\Desktop\\ENRICO\\1 GITHUB\\C#\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\addresses.csv";
        public static string pathCopy = "C:\\Users\\User\\Desktop\\ENRICO\\1 GITHUB\\C#\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\addresses2.csv";

        static void Main(string[] args)
        {
            GetFile(path);
            foreach(var item in indirizzo)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine();
            }
            CopyFile(indirizzo, pathCopy);
           
        }

        public static List<Indirizzo> GetFile(string path)
        {
            var stream = File.OpenText(path);
            int i = 0;
            while(stream.EndOfStream == false)
            {
                var linea = stream.ReadLine();
                i++;
                if(i <= 1) continue;
                try 
                {
                    var result = linea.Split(",");
                    string name = result[0];
                    string surname = result[1];
                    string street = result[2];
                    string city = result[3];
                    string province = result[4];
                    int zip = int.Parse(result[5]);

                    Indirizzo Indirizzo1 = new Indirizzo(name, surname, street, city, province, zip);
                    indirizzo.Add(Indirizzo1);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Errore alla riga {i}: Formato errato");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"Errore alla riga {i}: Fuori Range");

                }
                catch (Exception e) 
                {
                    Console.WriteLine($"Errore alla riga {i}: {e.Message}");
                }
            }
            stream.Close();
            return indirizzo;
        }
        public static void CopyFile(List<Indirizzo> indirizzo, string path)
        {
            try 
            {
                StreamWriter stream = File.CreateText(path);
                foreach (var item in indirizzo)
                {
                    stream.WriteLine(item);
                }
                Console.WriteLine("Copia andata a buon fine");
                stream.Close();
            }
            catch 
            {
                Console.WriteLine("Copia non andata a buon fine");
            }
            
        }
    }
}
