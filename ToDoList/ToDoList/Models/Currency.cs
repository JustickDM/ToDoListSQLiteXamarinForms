using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Models
{
    public class Currency
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public decimal Ask { get; set; }
        public decimal Bid { get; set; }
    }
}
