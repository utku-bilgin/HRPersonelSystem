namespace HRPersonnelSystem.UI.Models.Auth
{
    public class PasswordResetViewModel
    {
        public string Email { get; set; }
        public string PreviousPassword { get; set; }
        public string NewPassword { get; set; }

        public string ConfirmNewPassword { get; set;}
    }
}
