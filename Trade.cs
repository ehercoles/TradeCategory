using System;
using System.Collections.Generic;
using System.Text;

namespace TradeCategory
{
    class Trade : ITrade
    {
        public double Value { get; set; }

        public string ClientSector { get; set; }

        public DateTime NextPaymentDate { get; set; }

        public bool IsPoliticallyExposed { get; set; }
        public enum Category { EXPIRED, HIGHRISK, MEDIUMRISK, PEP }
        public Category _Category { get; set; }
    }
}
