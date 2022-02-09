using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Address
    {
        public int Id { get; set; }
        public string? Village { get; set; }
        public List<TalukaDetails> Taluka { get; set; }
        public List<DivisionDetails> City { get; set; }
        public List<StateDetails> State { get; set; }
        public List<CountryDetails> Country { get; set; }
        public string? Zip { get; set; }
    }
}
