namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static List<Indirizzo> indirizzo = new List<Indirizzo>();
        static string path = "C:\\Users\\User\\Desktop\\ENRICO\\1 GITHUB\\C#\\csharp-lista-indirizzi\\csharp-lista-indirizzi\\addresses.csv";

        static void Main(string[] args)
        {
            GetFile(path);
            foreach(var item in indirizzo)
            {
              
                Console.WriteLine(item.ToString());
                Console.WriteLine();
            }
           
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
                catch (Exception e) 
                {
                    Console.WriteLine($"Errore alla riga {i}: {e.Message}");
                }
            }
            stream.Close();
            return indirizzo;
        }
    }
}
