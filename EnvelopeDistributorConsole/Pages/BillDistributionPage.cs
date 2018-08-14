using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;
using EasyConsole;

namespace EnvelopeDistributorConsole.Pages
{
    public class BillDistributionPage : Page

    {
        public BillDistributionPage(Program program) : base("Bill Distribution", program)
        {

        }

        public override void Display()
        {
            base.Display();

            var income = (decimal)Input.ReadInt("Insert income to distribute: ", 0, 10000);

            var envelopes = Runner.Context.Envelopes;

            //var amountSum = 0m;

            if (envelopes != null && envelopes.Any())
            {

                foreach (var envelope in envelopes)
                {
                    var envelopeValue = envelope.Amount;
                    GetBillDistrubution(ref envelopeValue, envelope);
                    income -= envelope.GetTotalDistributionAmount();
                }

                var filledEnvelopes = envelopes
                    .Where(x => x.BillDistribution.Any())
                    .Select(x => new EnvelopeDetail
                    {
                        Amount = x.Amount,
                        Name = x.Name,
                        InlineBillDistribution = string.Join("|", x.BillDistribution.Select(y => $"{y.Amount}X{y.Value}({y.Name})"))
                    });

                Output.WriteLine("========= Envelopes ===========");

                ConsoleTable
                    .From<EnvelopeDetail>(filledEnvelopes)
                    .Write(Format.Alternative);

                var billItems = envelopes.Where(x => x.BillDistribution.Any()).SelectMany(y => y.BillDistribution);

                


                
                 //var table = new ConsoleTable(" ", " ", "Total");
                //table.AddRow("", "", t);
                //table.Write(Format.Alternative);
                //ConsoleTable.From(t).Columns(new []).Write(Format.Alternative);

                //ConsoleTable.From(new string[]{"", "", filledEnvelopes.})
                //ConsoleTable.From()
                Output.WriteLine("Unplaced: " + income);
                //var lines = filledEnvelopes.Select(kvp => kvp.Name + ": " + kvp.Amount.ToString());
                //Output.WriteLine(string.Join(Environment.NewLine, lines));
            }

            //amountSum = envelopes.Sum(x => x.Amount);
            //    var lines = _billDistribution.Select(kvp => kvp.Key + ": " + kvp.Value.ToString());
            //    Console.WriteLine(string.Join(Environment.NewLine, lines));
            //    Console.WriteLine($"Unchanable: {remaining}");
        }

        private void GetBillDistrubution(ref decimal remaining, Envelope envelope)
        {
            var envelopeBillItems = envelope.BillDistribution;
            while (remaining >= BillConstant.Fifty)
            {
                if (remaining >= BillConstant.TwoThousand)
                {
                    CreateOrUpdateItemBill(envelopeBillItems, "TwoThousand", 2000, ref remaining);
                    continue;
                }

                if (remaining >= BillConstant.OneThousand)
                {
                    CreateOrUpdateItemBill(envelopeBillItems, "OneThounsand", 1000, ref remaining);
                    continue;
                }

                if (remaining >= BillConstant.FiveHundred)
                {
                    CreateOrUpdateItemBill(envelopeBillItems, "FiveHundred", 500, ref remaining);

                    continue;
                }

                if (remaining >= BillConstant.TwoHundred)
                {
                    CreateOrUpdateItemBill(envelopeBillItems, "TwoHundred", 200, ref remaining);
                    continue;
                }

                if (remaining >= BillConstant.OneHundred)
                {
                    CreateOrUpdateItemBill(envelopeBillItems, "OneHundred", 100, ref remaining);
                    continue;
                }

                if (remaining >= BillConstant.Fifty)
                {
                    CreateOrUpdateItemBill(envelopeBillItems, "Fifty", 50, ref remaining);
                }
            }
        }

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
    }
}