using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace BlogProjectExam.Models.Entity
{
    [Table("Articles")]
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string ArticlePicture { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        //Nav Props.
        public virtual User Author { get; set; }
    }
}
