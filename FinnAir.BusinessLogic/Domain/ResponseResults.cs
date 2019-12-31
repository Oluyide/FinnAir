using System;
using System.Collections.Generic;
using System.Text;

namespace FinnAir.BusinessLogic.Domain
{
   public class ResponseResults: AuthenticationResult
    {
        public bool Failure { get; set; }
    }
}
