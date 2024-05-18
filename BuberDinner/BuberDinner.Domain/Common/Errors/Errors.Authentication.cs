using ErrorOr;

namespace BuberDinner.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredantials => Error.Validation(
                code: "Auth.InvalidCred",
                description: "Invalid Credantials");
        }
    }
}
