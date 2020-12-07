using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parser
{
    public class Seller
    {
        public string Name { get; set; }
        public string Link { get; set; }

        public Seller()
        {
        }
    }
}
