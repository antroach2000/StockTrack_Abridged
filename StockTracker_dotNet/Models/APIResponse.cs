using System;
using System.Linq;

namespace StockTrade.API.Models
{
    public class APIResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public int HttpStatusCode { get; set; }
    }
}