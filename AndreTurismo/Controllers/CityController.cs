using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreTurismo.Models;
using AndreTurismo.Services;

namespace AndreTurismo.Controllers
{
    public class CityController
    {
        public bool InsertCity(City city)
        {
            return new CityService().InsertCity(city);
        }

        public List<City> SelectListCity()
        {
            return new CityService().GetCityList();
        }

        public bool UpdateCity(City city)
        {
            return new CityService().UpdateCity(city);
        }

        public bool DeleteCity(City city) 
        { 
            return new CityService().DeleteCity(city);
        }
    }

    
}
