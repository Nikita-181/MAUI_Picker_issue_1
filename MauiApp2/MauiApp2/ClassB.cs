using System;
using System.Collections.Generic;
using System.Text;

namespace MauiApp2
{
    public class ClassB
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool isSelected { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
