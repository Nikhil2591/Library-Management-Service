using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LibraryData.Models
{
    public class VideoGames : LibraryAsset
    {
        [Required]
        public string Developer { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Platform { get; set; }

    }
}
