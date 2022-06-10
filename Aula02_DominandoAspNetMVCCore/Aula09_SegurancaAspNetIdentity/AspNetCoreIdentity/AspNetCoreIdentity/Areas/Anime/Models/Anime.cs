using Microsoft.EntityFrameworkCore;

namespace AspNetCoreIdentity.Areas.Anime.Models
{
    [Keyless]
    public class Animes
    { 
        public Guid userID { get; set; }

        public Season SeasonID { get; set; }

        public string Title { get; set; }

        public string Subtype { get; set; }

        public DateTime release_Date { get; set; }

        public string Description { get; set; }

        public int Total_episodes { get; set; }

        public string Status { get; set; }

        public string OfficialThumb { get; set; }

        public string Studio { get; set; }

        public string Kitsu_link { get; set; }

        public DateTime Create_at { get; set; }

        public DateTime Update_at { get; set; }
    }
}
