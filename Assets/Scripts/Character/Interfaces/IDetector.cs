using System;

namespace Character.Interfaces
{
    public interface IDetector
    {
        event Action OnCollided;
    }
}
