﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAPIHost.Models;

namespace SampleAPIHost.Repository
{
    public class RequestResponseHandling : IRequestResponseHandling
    {
        public RequestResponse GetSampleRequestResponse()
        {
            Models.RequestResponse sendResponse = new RequestResponse();
            sendResponse.LayerMembers= new string[]{"value","value"};
            sendResponse.Layer = "value";
            return sendResponse;
        }
    }
}
