using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer
{
    public class ValuesController : Controller
    {
        private readonly MyConfiguration _myConfiguration;

        public ValuesController(IOptions<MyConfiguration> myConfiguration)
        {
            _myConfiguration = myConfiguration.Value;
        }
    }
}
