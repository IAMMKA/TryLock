using System;
using System.Collections.Generic;
using System.Text;

namespace TryLock.Interfaces
{
    public interface IPickLock
    {
        public string Unlock(IDigitalLock digitalLock);
    }
}
