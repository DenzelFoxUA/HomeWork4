using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HomeWork4
{
    public static class Task3
    {
        public static void Run()
        {
            var resultSam = false;

            string name1 = "Sam Mitchell";
            ExpiringDate expDate1 = ExpiringDate.ExpiringDateBuild(11,2035);

            byte[] cardNum1 = new byte[CreditCard.CARD_NUMBER_DIGITS_COUNT]
            {
                5,7,4,9,
                1,1,2,2,
                4,8,0,3,
                1,7,4,8 
            };


            var _creditCard1 = CreditCard.CreditCardBuild(name1,cardNum1, expDate1,Currency.UAH);
            MyPrinter.Print<CreditCard>(_creditCard1, "-------------------------------\n");

            /////////////////////////////////////////////////////////////////////////
            
            string name2 = "Rose Mitchell";
            ExpiringDate expDate2 = ExpiringDate.ExpiringDateBuild(7, 2030);

            byte[] cardNum2 = new byte[CreditCard.CARD_NUMBER_DIGITS_COUNT]
            {
                5,7,4,9,
                1,2,2,4,
                8,0,6,4,
                1,8,9,8
            };

            var _creditCard2 = CreditCard.CreditCardBuild(name2, cardNum2, expDate2, Currency.UAH);
            MyPrinter.Print<CreditCard>(_creditCard2, "-------------------------------\n");

            //////////////////////////////////////////////////////////////////////////////

            decimal ballanceIncome = 10000M,
                    transfer = 4000M;

            resultSam = _creditCard1 + ballanceIncome;
            Console.WriteLine($"New ballance income {ballanceIncome} {_creditCard1.Currency}\n" +
                $"Account: {_creditCard1.NameOnTheCard}. Status: {resultSam}");

            MyPrinter.Print<CreditCard>(_creditCard1, "-------------------------------\n");

            resultSam = _creditCard1 - transfer;
            var resultRose = _creditCard2 + transfer;

            Console.WriteLine($"Sending {transfer} {_creditCard1.Currency}\n" +
                $"Account: {_creditCard1.NameOnTheCard}. Status: {resultSam}");

            Console.WriteLine($"Recieving {transfer} {_creditCard1.Currency}\n" +
                $"Account: {_creditCard2.NameOnTheCard}. Status: {resultRose}");
            Console.ReadLine();
            Console.Clear();

            MyPrinter.Print<CreditCard>(_creditCard1, "-------------------------------\n");
            MyPrinter.Print<CreditCard>(_creditCard2, "-------------------------------\n");

            //////////////////////////////////////////////////////////////////////////////

            Console.WriteLine($"Is {_creditCard1.NameOnTheCard} ballance bigger than {_creditCard2.NameOnTheCard} " +
                $"= {_creditCard1>_creditCard2}");
            Console.ReadLine();

            Console.WriteLine($"Is {_creditCard1.NameOnTheCard} CVV equal to {_creditCard2.NameOnTheCard} " +
                $"= {_creditCard1 == _creditCard2}");
            Console.ReadLine();
        }

    }


    


    
}
