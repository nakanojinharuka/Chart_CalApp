using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class DataCache
    {
        public static Hashtable Chart_table { get; set; } = new(15);
        public DataCache(Hashtable chart_table)
        {
            Chart_table = chart_table;
        }
    }
}
