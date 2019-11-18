using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDemo.Models.ui.locations
{
    public class Group
    {
        public List<Combination> Combinations { set; get; } = new List<Combination>();
        public string Name { set; get; } = string.Empty;
    }
}