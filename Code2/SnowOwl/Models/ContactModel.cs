using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SnowOwl.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(128)]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(128)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string Message { get; set; }

        public HttpPostedFileBase Attachment { get; set; }

        public string CompanyName { get; set; }

        public string PhoneNumber { get; set; }
    }
}