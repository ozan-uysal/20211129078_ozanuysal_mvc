using Microsoft.AspNetCore.Identity;

namespace Mvc_20211129078_ozanUysal.Localisation
{
    public class ErrorDescription : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new() { Code = "DuplicateUserName", Description = $"{userName}, Username is registered!" };
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new() { Code = "DuplicateEmail", Description = $"{email}, Email address is registered!" };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new() { Code = "PasswordRequiresNonAlphanumeric", Description = "Password must contain at least one non-alphanumeric character!" };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new() { Code = "PasswordRequiresDigit", Description = "Password must consist of at least one number (0-9)!" };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new() { Code = "PasswordTooShort", Description = $"Password must be at least {length} characters!" };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new() { Code = "PasswordRequiresLower", Description = $"Password must contain at least one lowercase letter ('a'-'z')!" };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new() { Code = "PasswordRequiresUpper", Description = $"Password must contain at least one uppercase letter ('A'-'Z')!" };
        }

    }
}
