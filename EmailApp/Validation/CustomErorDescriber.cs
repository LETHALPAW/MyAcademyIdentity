using Microsoft.AspNetCore.Identity;

namespace EmailApp.Validation
{
	public class CustomErorDescriber:IdentityErrorDescriber
	{
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresDigit",
				Description = $"Parola en az 1 rakam içermeli  olmalıdır."
			};

		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresLower",
				Description = $"Parola en az 1 küçük harf içermeli  olmalıdır."
			};
		}
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError
			{
				Code = "PasswordTooShort",
				Description = $"Parola en az {length} karakterden oluşmalıdır."
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = $"Parola en az 1 alfanümerik olmayan karakter içermeli  olmalıdır."
			};
		}
		public override IdentityError DuplicateEmail(string email)
		{
			return new IdentityError
			{
				Code = "DuplicateEmail",
				Description = $"{email} adresi zaten kayıtlıdır."
			};
		}


	}
}
