using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp
{
    public class Song
    {
        public int SongID { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; } // giây
        public string FilePath { get; set; }
        public string Lyrics { get; set; }
        public int ReleaseYear { get; set; }
    }
}
