namespace Domain.Authentication.DTOs
{
    public class AccountDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AccountDTO(string email, string paswword)
        {
            this.Email = email;
            this.Password = paswword;
        }
    }
}
