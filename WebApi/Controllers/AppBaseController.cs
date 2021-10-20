using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApi.Controllers
{
    public class AppBaseController : Controller
    {
        protected IServiceProvider _serviceProvider;
        public AppBaseController(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

       

    }
}
