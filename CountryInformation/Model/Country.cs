using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryInfo.Model
{
    
    public class Country
    {
        /// <summary>
        /// Nazwa
        /// </summary>
      
        public string Name { get; set; }
        /// <summary>
        /// Stolica
        /// </summary>
        public string Capital { get; set; }
        /// <summary>
        /// Ilość mieszkańców
        /// </summary>
        public int NumberOfCitizens { get; set; }
    }
}
