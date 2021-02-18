using CountryInfo.Model;
using CountryInfo.Services.Intrefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace CountryInfo.Services
{
    public class CountryManageService : ICountryManage<Country>
    {

        //TODO do przeniesienia do appsetting.json
        private string xmlFilePath = "Countries.xml";
        public async Task<List<Country>> ReadCountry()
        {

            var countrys = await GetCountryAsync();
            return countrys;
        }

        private Task<List<Country>> GetCountryAsync()
        {
            try
            {
                XDocument doc = XDocument.Load(xmlFilePath);
                var countries = doc.Elements("Countries").Elements("Country")
                .Select(
                x => new Country
                {
                    Name = (string)x.Element("Name").Value,
                    Capital = (string)x.Element("Capital").Value,
                    NumberOfCitizens = (int)x.Element("NumberOfCitizens")
                });
                return Task.Run(() => countries.ToList());
            }
            catch (Exception ex)
            {
                //logowanie exception do np logForNet
                return null;
            }
        }

        public Task<bool> SaveCountry(Country country)
        {
           return Task.Run(() =>
            {
                try
                {
                    XDocument doc = XDocument.Load(xmlFilePath);
                    XElement c = doc.Element("Countries");
                    c.Add(new XElement("Country",
                                new XElement("Name", country.Name),
                               new XElement("Capital", country.Capital),
                               new XElement("NumberOfCitizens", country.NumberOfCitizens)));
                    doc.Save(xmlFilePath);
                    return true;
                }
                catch (Exception ex)
                {
                    //logowanie exception do np logForNet
                    return false;
                }
            });
        }
    }
}
