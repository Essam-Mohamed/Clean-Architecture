using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infrastructure.Services
{
    public class DateTimerPrvder : IDateTimerProvider
    {
        public DateTime UTCNow => DateTime.UtcNow;
    }
}
