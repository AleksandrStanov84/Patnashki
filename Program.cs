using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Написать класс Money, предназначенный для хранения денежной суммы(в гривнах (int) и копейках(int)).
//Для класса реализовать:
//•	перегрузку операторов + (сложение денежных сумм ) +
//•	 - (вычитание сумм)                               +
//•	 / (деление суммы на целое число)                 +
//•	 * (умножение суммы на целое число)               +
//•	 ++ (сумма увеличивается на 1 копейку)            +
//•	 -- (сумма уменьшается на 1 копейку)              +
//•	 <, >                                             +
//•	 ==, !=                                           +
//Программа должна с помощью меню продемонстрировать все возможности класса Money.

namespace Money
{
    class Money
    {
        private int grv;
        private int kop;

        public Money() { }

        public Money(int _grv, int _kop)
        {
            this.grv = _grv;
            this.kop = _kop;

            if(kop >= 99)
            {
                grv += 1;
                kop -= 100; 
            }
        }

        public override string ToString()
        {
            return $"grv= {grv}; kop= {kop}";
        }

        public static Money operator ++(Money value)
        {
            value.kop++;
            return value;
        }

        public static Money operator --(Money value)
        {
            value.kop--;
            return value;
        }

        public static Money operator +(Money a, Money b)
        {
            Money result = new Money(a.grv + b.grv, a.kop + b.kop);
            return result;
        }

        public static Money operator +(Money a, int b)
        {
            Money result = new Money(a.grv + b, a.kop + b);
            return result;
        }

        public static Money operator -(Money a, Money b)
        {
            Money result = new Money(a.grv - b.grv, a.kop - b.kop);
            return result;
        }

        public static Money operator -(Money a, int b)
        {
            Money result = new Money(a.grv - b, a.kop - b);
            return result;
        }

        public static Money operator *(Money a, Money b)
        {
            Money result = new Money(a.grv * b.grv, a.kop * b.kop);
            return result;
        }

        public static Money operator *(Money a, int b)
        {
            Money result = new Money(a.grv * b, a.kop * b);
            return result;
        }

        public static Money operator /(Money a, Money b)
        {
            Money result = new Money(a.grv / b.grv, a.kop / b.kop);
            return result;
        }

        public static Money operator /(Money a, int b)
        {
            Money result = new Money(a.grv / b, a.kop / b);
            return result;
        }

        public static bool operator ==(Money a, Money b)
        {
            if (a.grv == b.grv && a.kop == b.kop)
                return true;
            return false;
        }

        public static bool operator !=(Money a, Money b)
        {
            if (a.grv != b.grv && a.kop != b.kop)
                return true;
            return false;
        }

        public static bool operator >(Money a, Money b)
        {
            if (a.grv > b.grv && a.kop > b.kop)
                return true;
            return false;
        }

        public static bool operator <(Money a, Money b)
        {
            if (a.grv < b.grv && a.kop < b.kop)
                return true;
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {            
            Money money = new Money(12, 50);
            Money money1 = new Money(1, 1);
            Money money2 = money + money1;
            money++;

            Console.WriteLine(money2);

            if (money > money1)
            {
                Console.WriteLine("Больше money");
            }
            else
            {
                Console.WriteLine("Больше money1");
            }

            money = money1 + 100;
            money1 = money1 + 99;
            money1 += money2;

            Console.WriteLine("money " + money);
            Console.WriteLine("money1 " + money1);
            Console.WriteLine("money2 " + money2);

            Money money3 = new Money(110, 99);
            money3--;
            money3++;
            money3++;
            Console.WriteLine("money3 " + money3);
        }
    }
}
