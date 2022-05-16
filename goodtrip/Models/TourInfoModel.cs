using goodtrip.Storage.Entity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace goodtrip.Models
{
    public class TourInfoModel
    {
        public Tour Tour { get; set; }
        public string TourId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string CommentName { get; set; }
        [Required(ErrorMessage = "Text of comment is required")]
        public string CommentText { get; set; }
    }
}
