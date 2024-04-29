using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace csharp_lista_indirizzi
{
    public class Indirizzo
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        private string street;
        public string Street
            {
                get { return street; }
                set
                {
                    if (value.Length < 10)
                    {
                        throw new ArgumentException("Lo street deve avere almeno 10 caratteri.");
                    }
                    street = value;
                }
            }
        public string City { get; set; }

        private string province;
        public string Province { get { return province; } set 
            {
                if(value.Length != 2)
                {
                    throw new ArgumentException("La provincia deve essere di 2 caratteri");
                }
                province = value;
            } 
        }
        public int ZIP { get; set; }
   

        public Indirizzo(string name, string surname, string street, string city, string province, int zip) 
        {
            this.Name = name;
            this.Surname = surname;
            this.Street = street;
            this.City = city;
            this.Province = province;
            this.ZIP = zip;
        }
        public override string ToString()
        {
            return $"{this.Name}, {this.Surname},{this.Street},{this.City},{this.Province},{this.ZIP}";
        }
    }
}
