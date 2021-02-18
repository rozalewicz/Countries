using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryInfo.Model;
using CountryInfo.Services.Intrefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        protected ICountryManage<Country> _service;
        private readonly ILogger<Country> _logger;

        public CountryController(ILogger<Country> logger, ICountryManage<Country> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("get-countries")]
        public async Task<List<Country>> GetCountries()
        {
            return await _service.ReadCountry();  
        }

        [HttpPost("create")]
        public async Task<bool> Create([FromBody] Country value)
        {
            return await _service.SaveCountry(value  );
        }
    }
}
