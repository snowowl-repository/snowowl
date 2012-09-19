using System;
using System.ComponentModel.DataAnnotations;

namespace SnowOwl.Models
{
    public class AskForAQuoteModel
    {
        [Required]
        public String Name { get; set; }

        [Required]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "Not valid email")]
        public String Email { get; set; }

        [Required]
        public String Message { get; set; }
    }
}