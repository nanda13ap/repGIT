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
        public string About
        {
            get;
            set;

        }

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
