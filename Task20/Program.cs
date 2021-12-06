using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task20
{
    /*В приложении объявить тип делегата, который ссылается на метод. Требования к сигнатуре метода следующие:
     * - метод получает входным параметром переменную типа double;
     * - метод возвращает значение типа double, которое является результатом вычисления.
     * Реализовать вызов методов с помощью делегата, которые получают радиус R и вычисляют:
     * - длину окружности по формуле D = 2 * π* R;
     * - площадь круга по формуле S = π* R²;
     * - объем шара. Формула V = 4/3 * π * R³.
     * Методы должны быть объявлены как статические.*/
    class Program
    {
        delegate double CalcSphere(double R);
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите радиус R = ");
                double R = Convert.ToDouble(Console.ReadLine());
                CalcSphere result = new CalcSphere(GetLength);
                if (result != null)
                {
                    if (R > 0)
                    {
                        double D = result.Invoke(R);
                        Console.Write($"\nДлина окружности D = \t{D:f3}");
                        result = new CalcSphere(GetArea);
                        double S = result(R);
                        Console.Write($"\nПлощадь круга S = \t{S:f3}");
                        result = new CalcSphere(GetSphere);
                        double V = result(R);
                        Console.Write($"\nОбъём сферы V = \t{V:f3}");
                    }
                    else
                    {
                        Console.WriteLine("Радиус не может быть отрицательным!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }
            Console.ReadKey();
        }
        private static double GetLength(double R)
        {
            double D = 2 * Math.PI * R;
            return D;
        }
        private static double GetArea(double R)
        {
            double S = Math.PI * Math.Pow(R, 2);
            return S;
        }
        private static double GetSphere(double R)
        {
            double V = (4 * Math.PI * Math.Pow(R, 3)) / 3;
            return V;
        }
    }
}
