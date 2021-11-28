using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using D6UWHX_HFT_2021221.Logic;
using D6UWHX_HFT_2021221.Models;

namespace  D6UWHX_HFT_2021221.Controllers
{
    public class StatController : Controller
    {
        
        readonly IAlbumLogic a1;
        public StatController(IAlbumLogic a1)
        {
            this.a1 = a1;
        }

        // GET: stat/avgprice
        [HttpGet]
        public double AVGPrice()
        {
            return a1.AVGPrice();
        }

        // GET: stat/avgpricebybrands
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands()
        {
            return a1.AVGPriceByBrands();
        }
    }
}