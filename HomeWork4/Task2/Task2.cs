using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    public static class Task2
    {
        public static void Run()
        {
            int populationOfKyiv = 2966000,
                populationOfLondon = 8799728,
                swingPopulationValue = 100250;
            var result = 0;

            var _Kyiv = new City("Kyiv", populationOfKyiv, Countries.Ukraine);
            var _London = new City("London", populationOfLondon, Countries.United_Kingdom);
            var likeKyiv = new City("LikeKyiv", populationOfKyiv, Countries.Ukraine);
            MyPrinter.Print( _Kyiv, "Before using overloaded operators" );

            try
            {
                result = _Kyiv + swingPopulationValue;
            }
            catch (Exception ex)
            {
                MyPrinter.PrintExceptionsMessages( ex );
            }
            MyPrinter.Print(_Kyiv, $"Using + operator to increase population up by {swingPopulationValue}");

            try
            {
                result = _Kyiv - swingPopulationValue;
            }
            catch (Exception ex)
            {
                MyPrinter.PrintExceptionsMessages(ex);
            }
            MyPrinter.Print(_Kyiv, $"Using - operator to decrease population population down by {swingPopulationValue}");

            Console.WriteLine($"Is {_Kyiv.Name}({_Kyiv.Population}) have bigger number of population \n" +
                $"than {_London.Name}({_London.Population}) = {_Kyiv > _London}");

            Console.ReadLine();

            Console.WriteLine($"Is {_Kyiv.Name}({_Kyiv.Population}) equal num of people " +
                $"with {likeKyiv.Name}({likeKyiv.Population}) = {_Kyiv == likeKyiv}");

            Console.ReadLine();


            //null test

            City buffer = null;
            result = buffer + swingPopulationValue;
            
            Console.WriteLine($"{buffer > _London}");

        }

    }

}
