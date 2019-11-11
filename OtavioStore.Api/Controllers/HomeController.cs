using System;
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

        [HttpGet]
        [Route("error")]
        public string Error()
        {
            throw new Exception("Algum erro ocorreu");
            return "erro";
        }
    }
}