using UserCloneApp.Domain.Models.ConstantModels;

namespace UserCloneApp.Domain.Constants
{
    public static class ResponseConstant
    {
        #region Successful messages
        public static readonly ResponseConstantModel CreatingProcessSuccessful = new("14001", "Successfully created!");

        public static readonly ResponseConstantModel UpdatingProcessSuccessful = new("14002", "Successfully updated!");

        public static readonly ResponseConstantModel DeletingProcessSuccessful = new("14003", "Successfully deleted!");

        public static readonly ResponseConstantModel LoginSucceed = new("14004", "Login successful!");

        public static readonly ResponseConstantModel EmailSendingSuccessful = new("14005", "An e-mail has been sent to the entered mail address!");

        public static readonly ResponseConstantModel AccountVerified = new("14006", "Succesfully verified!");
        #endregion

        #region Fail messages
        public static readonly ResponseConstantModel CreatingProcessUnsuccessful = new("04001", "Failed to create! Please try again.");

        public static readonly ResponseConstantModel UpdatingProcessUnsuccessful = new("04002", "Failed to update! Please try again.");

        public static readonly ResponseConstantModel DeletingProcessUnsuccessful = new("04003", "Failed to delete! Please try again.");

        public static readonly ResponseConstantModel CreatingProcessExistUserWithSameEmail = new("04004", "Failed to create because there is a user of the same email address!");

        public static readonly ResponseConstantModel EmailPasswordError = new("04005", "Email or password incorrect!");

        public static readonly ResponseConstantModel CurrentPasswordError = new("04006", "The current password is incorrect!");

        public static readonly ResponseConstantModel NotRegisteredUser = new("04007", "There is no user belonging to this mail address!");

        public static readonly ResponseConstantModel AccountNotVerified = new("04008", "Your account appears to be unverified. Please verify your account using the link in the e-mail sent to you!");
        #endregion
    }
}
