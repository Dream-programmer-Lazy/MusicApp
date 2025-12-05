using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicApp
{
    public partial class MainForm : Form
    {
        private const string PLACEHOLDER = "Tìm bài hát...";
        private bool isMuted = false;
        private int lastVolume = 80;

        public MainForm()
        {
            InitializeComponent();
            trkVolume.Value = 80;
            axWindowsMediaPlayer1.settings.volume = 80;
            trkVolume.Scroll += TrkVolume_Scroll;
            SetupSearchBox();
            LoadSongs(); 
        }


        private void SetupSearchBox()
        {
            txtSearch.Text = PLACEHOLDER;
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == PLACEHOLDER)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = PLACEHOLDER;
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void TrkVolume_Scroll(object sender, EventArgs e)
        {
            int newVolume = trkVolume.Value;
            axWindowsMediaPlayer1.settings.volume = newVolume;

            if (newVolume > 0 && isMuted)
            {
                isMuted = false;
                btnMute.Text = "🔊";
            }
            else if (newVolume == 0 && !isMuted)
            {
                isMuted = true;
                btnMute.Text = "🔇";
            }
        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            if (isMuted)
            {
                axWindowsMediaPlayer1.settings.volume = lastVolume;
                trkVolume.Value = lastVolume;
                btnMute.Text = "🔊";
                isMuted = false;
            }
            else
            {
                lastVolume = trkVolume.Value;
                axWindowsMediaPlayer1.settings.volume = 0;
                trkVolume.Value = 0;
                btnMute.Text = "🔇";
                isMuted = true;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (lstSongs.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một bài hát.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string item = lstSongs.SelectedItem.ToString();
            string filePath = ExtractFilePath(item);

            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("File nhạc không tồn tại hoặc không hợp lệ 1:\n" + filePath, "Lỗi1", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.IO.File.Exists(filePath))
            {
                MessageBox.Show("File nhạc không tồn tại hoặc không hợp lệ 2:\n" + filePath, "Lỗi2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            axWindowsMediaPlayer1.URL = filePath;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            DisplaySongInfo(filePath);
            lstSongs.Focus();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int currentIndex = lstSongs.SelectedIndex;
            if (currentIndex > 0)
            {
                lstSongs.SelectedIndex = currentIndex - 1;
                btnPlay_Click(null, EventArgs.Empty);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int currentIndex = lstSongs.SelectedIndex;
            if (currentIndex >= 0 && currentIndex < lstSongs.Items.Count - 1)
            {
                lstSongs.SelectedIndex = currentIndex + 1;
                btnPlay_Click(null, EventArgs.Empty);
            }
        }

        private void DisplaySongInfo(string filePath)
        {
            try
            {
                SongDAL dal = new SongDAL();
                Song song = dal.GetSongByFilePath(filePath);

                if (song != null)
                {
                    lblTitle.Text = song.Title;
                    lblArtist.Text = $"Ca sĩ: {song.Artist}";
                    lblGenre.Text = $"Thể loại: {song.Genre}";
                    lblDuration.Text = song.Duration > 0
                        ? $"Thời lượng: {TimeSpan.FromSeconds(song.Duration):mm\\:ss}"
                        : "Thời lượng: N/A";
                    txtLyrics.Text = song.Lyrics; 
                }
                else
                {

                    lblTitle.Text = "[Bài hát không có trong CSDL]";
                    lblArtist.Text = lblGenre.Text = lblDuration.Text = "";
                    txtLyrics.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin bài hát: " + ex.Message);
                txtLyrics.Text = "";
            }
        }

        private void btnAddSong_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddSongForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {

                        int duration = 0;
                        Song song = new Song
                        {
                            Title = addForm.Title,
                            Artist = addForm.Artist,
                            Genre = addForm.Genre,
                            FilePath = addForm.FilePath,
                            Lyrics = addForm.Lyrics,
                            ReleaseYear = addForm.ReleaseYear,
                            Duration = duration
                        };

                        SongDAL dal = new SongDAL();
                        dal.AddSong(song);

                        LoadSongs(); 
                        MessageBox.Show("Đã thêm bài hát thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi lưu bài hát: " + ex.Message);
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword) || keyword == PLACEHOLDER)
            {
                LoadSongs(); 
                return;
            }

            try
            {
                SongDAL dal = new SongDAL();
                var results = dal.SearchSongs(keyword);
                lstSongs.Items.Clear();
                foreach (var song in results)
                {
                    lstSongs.Items.Add($"{song.Title} - {song.Artist} | {song.FilePath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private string ExtractFilePath(string item)
        {
            int lastPipe = item.LastIndexOf(" | ");
            if (lastPipe != -1)
            {
                return item.Substring(lastPipe + 3);
            }
            return null; 
        }

        private void LoadSongs()
        {
            try
            {

                SongDAL dal = new SongDAL();
                var songs = dal.GetAllSongs();
                Debug.WriteLine("Đã kết nối thành công!");
                Debug.WriteLine($"Số bài hát: {songs.Count}");
                lstSongs.Items.Clear();
                foreach (var song in songs)
                {
                    string display = $"{song.Title} - {song.Artist} | {song.FilePath}";
                    lstSongs.Items.Add(display);
                }
                Debug.WriteLine(songs);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhạc: " + ex.Message);
            }
        }
        private void lstSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSongs.SelectedItem != null)
            {
                string filePath = ExtractFilePath(lstSongs.SelectedItem.ToString());
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    DisplaySongInfo(filePath);
                }
            }
        }

    }
}