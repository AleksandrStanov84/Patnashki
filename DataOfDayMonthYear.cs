//CopyRight by Aleksandr A. Stanov
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Реализовать класс Date, включающий следующие члены: 
//свойства Day, Month, Year, Day_Of_Week (ENUM);
//конструктор без параметров(инициализирует параметрами :  1/1/0001);
//конструктор с параметрами(день, месяц, год);
//перегрузить оператор «-», возвращающий разницу между двумя датами в днях ;
//перегрузить оператор «+», изменяющий даты на заданное количество дней;
//переопределенный метод ToString();
//перегрузить операторы «++», «--», «>», «<», «==», «!=».

//!!! В реализации НЕ использовать тип DateTime !!!

namespace DataOfDayMonthYear
{
    public enum DayOfWeek { Monday, Tuesday, Wednsday, Thursday, Friday, Suterday, Sunday }

    class Data
    {
        private int day;
        private int month;
        private int year;

        public Data()
        {
            day = 1;
            month = 1;
            year = 0001;
        }

        public Data(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public override string ToString()
        {
            return $"D: {day}/ M: {month}/ Y: {year}";
        }

        public DayOfWeek PrintDayOfWeek(int day, int month, int year)
        {
            DayOfWeek a;
            int a1 = (14 - month) / 12;
            year = year - a1;
            month = month + 12 * a1;
            a = (DayOfWeek)((day + 4 + year / 4 - year / 100 + year / 400 + (31 * month) / 12) % 7);

            Console.WriteLine(a);
            return a;
        }

        public int GetDays(int day, int month, int year)
        {
            int sumDay;
            year = 365 * year;
            month = 31 * day;
            return sumDay = year + month + day;
        }

        public static Data operator -(Data a, Data b)
        {
            Data result = new Data(a.day - b.day, a.month - b.month, a.year - b.year);
            return result;
        }
        public static Data operator +(Data a, Data b)
        {
            Data result = new Data(a.day + b.day, a.month + b.month, a.year + b.year);
            return result;
        }

        public static Data operator ++(Data value)
        {
            value.day++;
            return value;
        }

        public static Data operator --(Data value)
        {
            value.day--;
            return value;
        }

        public static bool operator ==(Data a, Data b)
        {
            if (a.day == b.day && a.month == b.month && a.year == b.year)
                return true;
            return false;
        }

        public static bool operator !=(Data a, Data b)
        {
            if (a.day != b.day && a.month != b.month && a.year != b.year)
                return true;
            return false;
        }

        public static bool operator >(Data a, Data b)
        {
            if (a.day != b.day && a.month != b.month && a.year != b.year)
                return true;
            return false;
        }

        public static bool operator <(Data a, Data b)
        {
            if (a.day != b.day && a.month != b.month && a.year != b.year)
                return true;
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data(12, 24, 2012);
            Console.WriteLine(data);

            Data d = new Data(6, 3, 12);
            Console.WriteLine(d.GetDays(3, 10, 2012));

            Data d2 = new Data();
            d2 = data - d;
            Console.WriteLine(d2);
            d2++;
            Console.WriteLine(d2);

            Data d3 = new Data(16, 6, 1984);

            Console.WriteLine(d3.PrintDayOfWeek(16, 6, 1984));

            Console.WriteLine(d3);        
        }
    }
}

