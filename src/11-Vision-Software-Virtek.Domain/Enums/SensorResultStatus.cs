
namespace _11_Vision_System_Virtek.Domain.Enums
{
    public enum SensorResultStatus
    {
        None,
        Pass, // Unconditional Pass.
        Warn, // Success, but with a warning condition.
        Fail // Failure condition.
    }
}