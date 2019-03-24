using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Web_API_2.Models
{
    public class LogIn
    {
        [Required, EmailAddress]
        public string UserName { get; set; }
        [Required, MinLength(6)]
        public string Password { get; set; }
    }
}