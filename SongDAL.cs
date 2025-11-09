using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp
{
    public class SongDAL
    {
        // 🔒 Chuỗi kết nối đến SQL Server
        // 💡 Đảm bảo bạn đã tạo CSDL tên là "MusicPlayerDB"
        private string connectionString = @"Server=.\SQLEXPRESS;Database=MusicPlayerDB;Trusted_Connection=true;";

        // 📥 Lấy toàn bộ bài hát
        public List<Song> GetAllSongs()
        {
            List<Song> songs = new List<Song>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Song ORDER BY Title";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        songs.Add(new Song
                        {
                            SongID = Convert.ToInt32(reader["SongID"]),
                            Title = reader["Title"].ToString(),
                            Artist = reader["Artist"].ToString(),
                            Album = reader["Album"]?.ToString() ?? "",
                            Genre = reader["Genre"]?.ToString() ?? "",
                            Duration = reader["Duration"] is DBNull ? 0 : Convert.ToInt32(reader["Duration"]),
                            FilePath = reader["FilePath"].ToString(),
                            Lyrics = reader["Lyrics"]?.ToString() ?? "",
                            ReleaseYear = reader["ReleaseYear"] is DBNull ? 0 : Convert.ToInt32(reader["ReleaseYear"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi tải danh sách nhạc: " + ex.Message);
                }
            }
            return songs;
        }

        // ➕ Thêm bài hát mới
        public void AddSong(Song song)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    INSERT INTO Song (Title, Artist, Album, Genre, Duration, FilePath, Lyrics, ReleaseYear)
                    VALUES (@Title, @Artist, @Album, @Genre, @Duration, @FilePath, @Lyrics, @ReleaseYear)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", song.Title ?? "");
                cmd.Parameters.AddWithValue("@Artist", song.Artist ?? "");
                cmd.Parameters.AddWithValue("@Album", string.IsNullOrEmpty(song.Album) ? (object)DBNull.Value : song.Album);
                cmd.Parameters.AddWithValue("@Genre", string.IsNullOrEmpty(song.Genre) ? (object)DBNull.Value : song.Genre);
                cmd.Parameters.AddWithValue("@Duration", song.Duration == 0 ? (object)DBNull.Value : song.Duration);
                cmd.Parameters.AddWithValue("@FilePath", song.FilePath ?? "");
                cmd.Parameters.AddWithValue("@Lyrics", string.IsNullOrEmpty(song.Lyrics) ? (object)DBNull.Value : song.Lyrics);
                cmd.Parameters.AddWithValue("@ReleaseYear", song.ReleaseYear == 0 ? (object)DBNull.Value : song.ReleaseYear);

                cmd.ExecuteNonQuery();
            }
        }

        // 🔍 Tìm kiếm bài hát
        public List<Song> SearchSongs(string keyword)
        {
            List<Song> songs = new List<Song>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT * FROM Song 
                    WHERE Title LIKE @kw OR Artist LIKE @kw OR Genre LIKE @kw";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    songs.Add(new Song
                    {
                        SongID = Convert.ToInt32(reader["SongID"]),
                        Title = reader["Title"].ToString(),
                        Artist = reader["Artist"].ToString(),
                        Album = reader["Album"]?.ToString() ?? "",
                        Genre = reader["Genre"]?.ToString() ?? "",
                        Duration = reader["Duration"] is DBNull ? 0 : Convert.ToInt32(reader["Duration"]),
                        FilePath = reader["FilePath"].ToString(),
                        Lyrics = reader["Lyrics"]?.ToString() ?? "",
                        ReleaseYear = reader["ReleaseYear"] is DBNull ? 0 : Convert.ToInt32(reader["ReleaseYear"])
                    });
                }
            }
            return songs;
        }
    }
}
