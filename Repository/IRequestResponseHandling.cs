using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAPIHost.Models;

namespace SampleAPIHost.Repository
{
    public interface IRequestResponseHandling
    {
        public RequestResponse GetSampleRequestResponse();
    }
}
