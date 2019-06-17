using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

//23.8976,12.3218 25.7639,11.9463 24.8293,12.2134
namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "note.txt"; 
            Console.WriteLine("Введите данные:\n");
            string line = Console.ReadLine();
            Console.WriteLine("Запись в файл....\n");
            line = line.Replace(' ', ',');//заменяем все пробелы на запятые
            Console.WriteLine("* {0}", line);//выводим новую строку
            File.WriteAllText(path, line);

            //Считываем из файла введенную строку
            var coord = File.ReadAllText(path);

            Console.WriteLine("Форматирование данных...\n");
            string[] coord_sys = coord.Split(',');//разбиваем строку по запятым
            for (int i = 0; i < coord_sys.Length; i++)//вывод получившегося массива
            {
                Console.WriteLine("\n {0}:  {1}", i, coord_sys[i]);

            }
            //Применение культуры
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };

            double[] Mas_Coord = new double[coord_sys.Length];//создаю числовой массив для последующего преобразования

            for (int i = 0; i < coord_sys.Length; i += 2)//преобразую элемент массива строковых данных в числовой и заполняю соответствующее место в массиве чисел
            {
                Mas_Coord[i] = double.Parse(coord_sys[i], CultureInfo.GetCultureInfo("en-US"));
                Mas_Coord[i + 1] = double.Parse(coord_sys[i + 1], CultureInfo.GetCultureInfo("en-US"));
                Console.WriteLine($"X:  {Mas_Coord[i].ToString(CultureInfo.GetCultureInfo("ru-RU"))}\t Y:  {Mas_Coord[i + 1].ToString(CultureInfo.GetCultureInfo("ru-RU"))}\n");
            }
            
           Console.ReadKey();
        }
    }
}
