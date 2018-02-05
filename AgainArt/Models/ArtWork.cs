using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Net.Mime;
using System.ComponentModel;
using static AgainArt.Models.Util;

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
        [DataType(DataType.MultilineText)]
        [StringLength(10000, MinimumLength = 3, ErrorMessage = "Your message can be from 5 to 10000 characters.")]
        public string Description { get; set; }

        public string ContentType { get; set; }

        public int ContentLength { get; set; }

        public byte[] ImageData { get; set; }



        public int PaintingType { get; set; }

        [NotMapped]
        public string PaintingTypeDescription
        {
            get
            {
                return ((EnumPaintingType)(PaintingType)).GetDescription();
            }
        }

        [NotMapped]
        public EnumPaintingType PaintingEnum
        {
            get; set;
        }


        [ForeignKey("Artista")]
        public int IdArtista { get; set; }
        public virtual Artist Artista { get; set; }

    }
}

