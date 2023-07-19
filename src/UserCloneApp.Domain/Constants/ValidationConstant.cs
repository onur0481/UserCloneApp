using UserCloneApp.Domain.Models.ConstantModels;

namespace UserCloneApp.Domain.Constants
{
    public static class ValidationConstants
    {
        public static readonly ValidationConstantModel NameFieldNotNullNotEmpty = new("34001", "The name field must not be left blank!");

        public static readonly ValidationConstantModel NameFieldOnlyLetters = new("34002", "The name field must contain only letters or spaces!");

        public static readonly ValidationConstantModel NameFieldMinimumLength = new("34003", "The name field must have at least 3 characters!");

        public static readonly ValidationConstantModel NameFieldMaximumLength = new("34004", "The name field must have a maximum of 50 characters!");

        public static readonly ValidationConstantModel SurnameFieldNotNullNotEmpty = new("34005", "The surname field must not be left blank!");

        public static readonly ValidationConstantModel SurnamFieldOnlyLetters = new("34006", "The surname field must contain only letters or spaces!");

        public static readonly ValidationConstantModel SurnamFieldMinimumLength = new("34007", "The surname field must have at least 3 characters!");

        public static readonly ValidationConstantModel SurnamFieldMaximumLength = new("34008", "The surname field must have a maximum of 50 characters!");

        public static readonly ValidationConstantModel EmailFieldNotNullNotEmpty = new("34009", "The email field must not be left blank!");

        public static readonly ValidationConstantModel EmailFieldFormat = new("34010", "Email field must be in the correct format! (e.g. xyz@domain.com)");

        public static readonly ValidationConstantModel PasswordFieldNotNullNotEmpty = new("34011", "The password field must not be left blank!");

        public static readonly ValidationConstantModel PasswordFieldMinimumLength = new("34012", "The password field must have at least 8 characters!");

        public static readonly ValidationConstantModel CurrentPasswordFieldNotNullNotEmpty = new("34013", "The current password field must not be left blank!");

        public static readonly ValidationConstantModel CurrentPasswordFieldMinimumLength = new("34014", "The current password field must have at least 8 characters!");

        public static readonly ValidationConstantModel NewPasswordFieldNotNullNotEmpty = new("34015", "The new password field must not be left blank!");

        public static readonly ValidationConstantModel NewPasswordFieldMinimumLength = new("34016", "The new password field must have at least 8 characters!");
    }
}
