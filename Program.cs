using System;
using System.Collections.Generic;
using System.IO;

namespace TradeCategory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Trade> trades = new List<Trade>();
            List<string> inputFileContent = new List<string>();

            #region Read input file

            foreach (string line in File.ReadAllLines("input.txt"))
            {
                inputFileContent.Add(line);
            }

            #endregion

            #region Process input file content

            DateTime referenceDate = DateTime.Parse(inputFileContent[0]);
            DateTime referenceDateAux = referenceDate.AddDays(-30);

            for (int i = 2; i < inputFileContent.Count; i++)
            {
                Trade trade = new Trade();

                string[] line = inputFileContent[i].Split(" ");
                trade.Value = double.Parse(line[0]);
                trade.ClientSector = line[1];
                trade.NextPaymentDate = DateTime.Parse(line[2]);

                if (trade.NextPaymentDate < referenceDateAux)
                {
                    trade._Category = Trade.Category.EXPIRED;
                }
                else
                {
                    if (trade.Value > 1000000)
                    {
                        if (trade.ClientSector.Equals("Private"))
                        {
                            trade._Category = Trade.Category.HIGHRISK;
                        }
                        else if (trade.ClientSector.Equals("Public"))
                        {
                            trade._Category = Trade.Category.MEDIUMRISK;
                        }
                    }
                }

                trades.Add(trade);
            }

            #endregion

            #region Write output

            foreach (Trade trade in trades)
            {
                Console.WriteLine(trade._Category);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            #endregion
        }
    }
}
