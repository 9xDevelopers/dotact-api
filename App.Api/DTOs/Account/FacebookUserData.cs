using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.DTOs.Account
{
    public class FacebookUserData
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Picture Picture { get; set; }
    }

    public class Picture
    {
        public Data Data { get; set; }
    }
    public class Data
    {
        public string Url { get; set; }
    }
}
