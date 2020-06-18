using System;
using System.Collections.Generic;
using System.Text;

namespace TryLock.Interfaces
{
    public enum TurnDirection
    {
        Forward,
        Backward
    }
    public interface IDigitalLock
    {
        public int GetCipherLength();
        public bool Turn(TurnDirection direction, int circleIndex, int step);
        public string ReadAll();
        public char Read(int circleIndex);
        public bool Lock(bool garbleAfterLock);
        public bool IsLocked();
        public bool Reset();
    }
}
