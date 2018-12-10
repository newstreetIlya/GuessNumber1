using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessNumber.Models
{
    public class CheckNumberModel
    {
        public int Id { get; set; }
        public int? Value { get; set; }
        public char? Status { get; set; }
    }
}