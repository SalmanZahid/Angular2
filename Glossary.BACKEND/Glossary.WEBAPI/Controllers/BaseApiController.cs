using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Glossary.WEBAPI.Controllers
{
    public enum ResponseStatusCode
    {
        ERROR = 0,
        SUCCESS = 1
    }

    public class BaseApiController : ApiController
    {
        public BaseApiController()
        {

        }
    }
}
