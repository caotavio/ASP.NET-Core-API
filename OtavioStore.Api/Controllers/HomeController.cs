using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OtavioStore.Domain.StoreContext.Entities;

namespace OtavioStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public List<Customer> Get()
        {
            return null;
        }
    }
}