using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Net.Mime;

namespace AgainArt.Models
{
    [Table("TbArtWork")]
    public class ArtWork
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }


        [Required]
        public string FileURL { get; set; }

        [Required]
        public string ThumbNailURL { get; set; }

        [Required]
        public string OriginalName { get; set; }

        [Required]
        public string GeneratedName { get; set; }

        [Required]
        public string Description { get; set; }

        public ContentType ContentType { get; set; }

        public int ContentLength { get; set; }

        public byte[] ImageData { get; set; }

        [ForeignKey("Artista")]
        public int IdArtista { get; set; }
        public virtual Artist Artista { get; set; }

    }
}