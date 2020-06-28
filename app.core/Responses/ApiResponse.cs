using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Responses
{
    public class ApiResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
    public class ApiLoginResponse : ApiResponse
    {
        public string accessToken { get; set; }
    }
}
