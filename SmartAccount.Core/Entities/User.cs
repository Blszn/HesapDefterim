namespace SmartAccount.Core.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string Role { get; set; } = "Admin"; // Admin or Partner
        public string SecurityQuestion { get; set; } = string.Empty;
        public string SecurityAnswerHash { get; set; } = string.Empty;
        public int FailedLoginAttempts { get; set; } = 0;
        public System.DateTime? LockoutEnd { get; set; }
    }
}
