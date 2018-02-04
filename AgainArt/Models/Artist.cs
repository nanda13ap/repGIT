using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgainArt.Models
{
    [Table("TbArtist")]
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id
        {
            get;
            set;
        }

        [Required]
        [StringLength(100)]
        public string Name
        {
            get;
            set;

        }

        [StringLength(100)]
        public string LastName
        {
            get;
            set;

        }

        [NotMapped]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", Name, LastName);
            }
        }


        [Required]
        [StringLength(10000, MinimumLength = 3, ErrorMessage = "Your message can be from 5 to 10000 characters.")]
        public string About
        {
            get;
            set;

        }

        [Required, EmailAddress]
        public string Email
        {
            get;
            set;

        }

        public string TelephoneNumber
        {
            get;
            set;

        }

        public Artist()
        {

        }
    }
}
