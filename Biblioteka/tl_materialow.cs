﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public class tl_materialow
    {
        public int id { get; set; }
        public string nazwa { get; set; }
        public double wartosc { get; set; }

        public string material
        {
            get
            {
                return $"{id} {nazwa} {wartosc}";
            }
        }

    }
}