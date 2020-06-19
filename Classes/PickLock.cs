using TryLock.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TryLock.Classes
{
    class PickLock : IPickLock
    {
        public string Unlock(IDigitalLock digitalLock)
        {
            string _lock = String.Empty;

            int characterCount = 0;
            char temp = digitalLock.Read(0);
            digitalLock.Turn(TurnDirection.Forward, 0, 1);
            characterCount++;
            while (temp != digitalLock.Read(0))
            {
                digitalLock.Turn(TurnDirection.Forward, 0, 1);
                characterCount++;
            }
            for (int i = 0; i < Math.Pow(characterCount, digitalLock.GetCipherLength()); i++)
            {
                string tryValue = Complete(i, digitalLock.GetCipherLength());
                digitalLock.Reset();
                for (int j = digitalLock.GetCipherLength() - 1; j >= 0; j--)
                {
                    digitalLock.Turn(TurnDirection.Forward, j, tryValue[j] - '0');
                }
                if (!digitalLock.IsLocked())
                {
                    _lock = digitalLock.ReadAll();
                }
            }

            return _lock;
        }

        private string Complete(int number, int size)
        {
            string temp = String.Empty;
            string numberStr = number.ToString();
            for (int i = numberStr.Length; i < size; i++)
            {
                temp += "0";
            }

            return temp + numberStr;

        }
    }
}
