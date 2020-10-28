using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
   public class Debitorer
    {
        public int DebitonerID { get; set; }
        public string DebitonerName { get; set; }
        public Varer[] Varer { get; set; }

        public OrderLinjer[] OrderLinjer { get; set; }
    }
}
