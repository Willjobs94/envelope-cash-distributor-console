using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EasyConsole;
using EnvelopeDistributorConsole.Pages;

namespace EnvelopeDistributorConsole
{
    class EnvelelopeDistributor : Program
    {
        public EnvelelopeDistributor() :
            base("Envelelope Distributor", breadcrumbHeader: true)
        {
            AddPage(new MainPage(this));
            AddPage(new CreateEnvelopePage(this));
            AddPage(new ViewEnvelopePage(this));
            AddPage(new BillDistributionPage(this));

            SetPage<MainPage>();
        }

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Welcome to Evelope Distributor App");
        //    Console.ReadKey();

        //    var amountToSplit = RequestDecimal("Write the amount you want to split");
        //    var remaining = amountToSplit;

        //    var menu = new EasyConsole.Menu()
        //        .Add("Create Envelope", () => Console.WriteLine("foo selected"))
        //        .Add("bar", () => Console.WriteLine("bar selected"));
        //    menu.Display();

        //    var lines = _billDistribution.Select(kvp => kvp.Key + ": " + kvp.Value.ToString());
        //    Console.WriteLine(string.Join(Environment.NewLine, lines));
        //    Console.WriteLine($"Unchanable: {remaining}");
        //    Console.ReadKey();
        //}

        private List<BillItem> GetBillDistrubution(decimal remaining)
        {

            var billItemDistribution = new List<BillItem>();

            while (remaining >= BillConstant.Fifty)
            {
                if (remaining >= BillConstant.TwoThousand)
                {
                    CreateOrUpdateItemBill(billItemDistribution, "TwoThousand", 2000, ref remaining);
                    continue;
                }

                if (remaining >= BillConstant.OneThousand)
                {
                    CreateOrUpdateItemBill(billItemDistribution, "OneThounsand", 1000, ref remaining);
                    continue;
                }

                if (remaining >= BillConstant.FiveHundred)
                {
                    CreateOrUpdateItemBill(billItemDistribution, "FiveHundred", 500, ref remaining);

                    continue;
                }

                if (remaining >= BillConstant.TwoHundred)
                {
                    CreateOrUpdateItemBill(billItemDistribution, "TwoHundred", 200, ref remaining);
                    continue;
                }

                if (remaining >= BillConstant.OneHundred)
                {
                    CreateOrUpdateItemBill(billItemDistribution, "OneHundred", 100, ref remaining);
                    continue;
                }

                if (remaining >= BillConstant.Fifty)
                {
                    CreateOrUpdateItemBill(billItemDistribution, "Fifty", 50, ref remaining);
                }
            }

            return billItemDistribution;
        }

        private static readonly Dictionary<string, int> _billDistribution = new Dictionary<string, int>();

        private void CreateOrUpdateItemBill(List<BillItem> items, string name, decimal billValue, ref decimal remaining)
        {
            var item = items.FirstOrDefault(x => x.Name == name);
            if (item != null)
            {
                item.Amount++;
            }
            else
            {
                items.Add(new BillItem { Amount = 1, Name = name, Value = billValue });
            }

            remaining -= BillConstant.TwoThousand;
        }

        private static decimal RequestDecimal(string message)
        {
            decimal result;
            do
            {
                Console.WriteLine(message);
            }
            while (!decimal.TryParse(Console.ReadLine(), out result));
            return result;
        }


    }
}
