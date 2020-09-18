using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sharp {
    class Program {
        static List<int> nominals = new List<int>();
        static List<List<int>> answer = new List<List<int>>();

        static void Main(string[] args) {
            Console.WriteLine("Read bill: ");

            int bill;
            string input = Console.ReadLine();
            if (!Int32.TryParse(input, out bill))
            {
                Console.WriteLine("Incorrect input.");
                Environment.Exit(1);
            }

            Console.WriteLine("Read nominals in ATM (0 is the end of input): ");
            while(true) {
                int currBill;
                input = Console.ReadLine();
                if (!Int32.TryParse(input, out currBill))
                 {
                    Console.WriteLine("Incorrect input.");
                    Environment.Exit(1);
                 }

                if (currBill == 0) {
                    break;
                } else {
                    nominals.Add(currBill);
                }
            }

            exchangeWays(bill, 0, new List<int>());

            Console.WriteLine("Answer:\n");
            foreach (var w in answer) {
                foreach (var n in w) {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
            } 
        }

        static void exchangeWays(int currBill, int currPos, List<int> currAns) {
            if (currBill == 0) {
                answer.Add(currAns);
                return;
            } else if (currBill < 0) {
                return;
            } else {
                if (currPos >= nominals.Count) {
                    return;
                } else {
                    for (int cnt = 0; cnt <= currBill / nominals[currPos]; cnt++) {
                        List<int> newAns = new List<int> (currAns);
                        newAns.AddRange(Enumerable.Repeat(nominals[currPos], cnt).ToList());

                        exchangeWays(currBill - cnt * nominals[currPos]
                                   , currPos + 1
                                   , newAns);
                    }
                }
            }
        }
    }
}