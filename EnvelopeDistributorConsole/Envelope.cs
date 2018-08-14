using System;
using System.Collections;
using System.Collections.Generic;

namespace EnvelopeDistributorConsole
{
    public class Envelope
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public List<BillItem> BillDistribution { get; set; } = new List<BillItem>();

        public  decimal GetTotalDistributionAmount()
        {
            var total = 0m;

            foreach (var billItem in BillDistribution)
            {
                total += billItem.Amount * billItem.Value;
            }

            return total;
        }
    }
}