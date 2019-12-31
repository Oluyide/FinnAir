using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinnAir.Api.Contracts
{
    public class FailResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
