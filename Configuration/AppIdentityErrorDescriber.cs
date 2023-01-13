using Microsoft.AspNetCore.Identity;

namespace InfoSoftAdmin.Configuration;

public class AppIdentityErrorDescriber: IdentityErrorDescriber
{
    public override IdentityError PasswordRequiresNonAlphanumeric()
    {
        return new IdentityError
        {
            Code = nameof(PasswordRequiresNonAlphanumeric),
            Description = "A senha deve conter pelo menos um caractere especial."
        };
    }

    public override IdentityError PasswordRequiresDigit()
    {
        return new IdentityError
        {
            Code = nameof(PasswordRequiresDigit),
            Description = "A senha deve conter pelo menos um caractere numérico."
        };
    }

    public override IdentityError PasswordRequiresLower()
    {
        return new IdentityError
        {
            Code = nameof(PasswordRequiresLower),
            Description = "A senha deve conter pelo menos um caractere [a-z]."
        };
    }
    
    public override IdentityError PasswordRequiresUpper()
    {
        return new IdentityError
        {
            Code = nameof(PasswordRequiresUpper),
            Description = "A senha deve conter pelo menos um caractere [A-Z]."
        };
    }
}