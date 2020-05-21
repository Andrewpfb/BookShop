using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    /// <summary>
    /// Class for Book object.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Book's ID. Is required.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Book's name. Is required, length it not more than 100 characters.
        /// </summary>
        [Required, MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Book's description. Is required, length it not more than 300 characters.
        /// </summary>
        [Required, MaxLength(300)]
        public string Description { get; set; }
    }
}
