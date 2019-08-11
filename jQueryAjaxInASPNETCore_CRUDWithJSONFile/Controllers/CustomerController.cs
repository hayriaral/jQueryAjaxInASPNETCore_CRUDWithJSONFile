using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using jQueryAjaxInASPNETCore_CRUDWithJSONFile.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace jQueryAjaxInASPNETCore_CRUDWithJSONFile.Controllers
{
    public class CustomerController : Controller
    {
        public string GetJsonFile(string dataSource) {
            WebClient wc = new WebClient { Encoding = Encoding.UTF8 };
            string json = wc.DownloadString(dataSource);
            return json;
        }
        public IActionResult ListCustomer()
        {
            string json = GetJsonFile("https://raw.githubusercontent.com/hayricaral/jQueryAjaxInASPNETCore_CRUDWithJSONFile/master/Customers.json");
            CustomerList CurrentCustomerList = new CustomerList();
            CurrentCustomerList.customerlist = JsonConvert.DeserializeObject<List<Customers>>(json);

            return View(CurrentCustomerList.customerlist);
        }
    }
}