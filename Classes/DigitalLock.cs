using TryLock.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TryLock.Classes
{
    public class DigitalLock : IDigitalLock
    {
        private char[] characters = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private int chipperLength;
        private int[] chipper;
        private string _lock;
        public DigitalLock(int chipperLength)
        {
            this.chipperLength = chipperLength;
            chipper = new int[chipperLength];
            _lock = GetRandomLock();
            Console.WriteLine("Oluşturulan Şifre : " + _lock);
            Reset();

        }
        private string GetRandomLock()
        {
            string temp = String.Empty;
            Random rnd = new Random();
            for (int i = 0; i < chipperLength; i++)
            {
                temp += characters[rnd.Next(10)];
            }
            return temp;

        }
        public int GetCipherLength()
        {
            return chipperLength;
        }

        public bool IsLocked()
        {
            return !ReadAll().Equals(_lock);
        }

        public bool Lock(bool garbleAfterLock)
        {
            Random rnd = new Random();

            if (!IsLocked())
            {
                for (int i = 0; i < chipperLength; i++)
                {
                    chipper[i] = rnd.Next(10);
                }
            }
            if (garbleAfterLock)
            {
                for (int i = 0; i < chipperLength; i++)
                {
                    chipper[i] = rnd.Next(10);
                }
            }

            return true;
        }

        public char Read(int circleIndex)
        {
            if (circleIndex < chipperLength && circleIndex >= 0)
            {
                return characters[chipper[circleIndex]];
            }
            else
            {
                return ' ';
            }
        }

        public string ReadAll()
        {
            string temp = String.Empty;
            for (int i = 0; i < chipperLength; i++)
            {
                temp += characters[chipper[i]];
            }
            return temp;
        }

        public bool Reset()
        {
            for (int i = 0; i < chipperLength; i++)
            {
                chipper[i] = 0;
            }
            return true;
        }

        public bool Turn(TurnDirection direction, int circleIndex, int step)
        {
            if (direction == TurnDirection.Forward)
            {
                for (int i = 0; i < step; i++)
                {
                    if (chipper[circleIndex] == 9)
                    {
                        chipper[circleIndex] = 0;
                    }
                    else
                    {
                        chipper[circleIndex]++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < step; i++)
                {
                    if (chipper[circleIndex] == 0)
                    {
                        chipper[circleIndex] = 9;
                    }
                    else
                    {
                        chipper[circleIndex]--;
                    }
                }
            }
            return true;
        }
    }
}
