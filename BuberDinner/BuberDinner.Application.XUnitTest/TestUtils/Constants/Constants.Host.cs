using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Application.XUnitTest.TestUtils.Constants
{
    public static partial class Constants
    {
        public static class Host
        {
            public static readonly HostId Id = HostId.CreateUnique();
        }
    }
}
