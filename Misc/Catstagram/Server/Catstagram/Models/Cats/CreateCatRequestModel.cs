namespace Catstagram.Models.Cats
{
    using static Data.Validation.Cat;
    using System.ComponentModel.DataAnnotations;
    public class CreateCatRequestModel
    {
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
