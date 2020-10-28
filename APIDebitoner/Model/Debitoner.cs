using System;
using WpfApp1.Model;

namespace APIDebitoner
{
    public class Debitoner
    {
        public int DebitonerID { get; set; }
        public string DebitonerName { get; set; }
        public Varer[] Varer { get; set; }

        public OrderLinjer[] OrderLinjer { get; set; }
    }
}
