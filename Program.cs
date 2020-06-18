using TryLock.Classes;
using TryLock.Interfaces;
using System;

namespace TryLock
{
    class Program
    {
        static void Main(string[] args)
        {
            DigitalLock _lock = new DigitalLock(5); //chipperLength
            PickLock pickLock = new PickLock();
            Console.WriteLine("Bulunan Şifre : " + pickLock.Unlock(_lock));


            Console.ReadKey();
        }
    }
}