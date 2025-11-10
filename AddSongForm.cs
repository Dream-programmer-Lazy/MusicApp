using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicApp
{
    public partial class AddSongForm : Form
    {
        public string Title { get; private set; }
        public string Artist { get; private set; }
        public string Genre { get; private set; }
        public string FilePath { get; private set; }
        public string Lyrics { get; private set; }
        public int ReleaseYear { get; private set; }

        public AddSongForm()
        {
            InitializeComponent();
            nudYear.Minimum = 1900;
            nudYear.Maximum = DateTime.Now.Year;
            nudYear.Value = DateTime.Now.Year;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Audio Files|*.mp3;*.wav;*.wma|All Files|*.*";
                ofd.Title = "Chọn file nhạc";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = ofd.FileName;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra bắt buộc
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bài hát.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtArtist.Text))
            {
                MessageBox.Show("Vui lòng nhập ca sĩ.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFilePath.Text) || !File.Exists(txtFilePath.Text))
            {
                MessageBox.Show("Vui lòng chọn file nhạc hợp lệ.");
                return;
            }

            // Gán dữ liệu
            Title = txtTitle.Text.Trim();
            Artist = txtArtist.Text.Trim();
            Genre = txtGenre.Text.Trim();
            Lyrics = txtLyrics.Text.Trim();
            ReleaseYear = (int)nudYear.Value;
            FilePath = txtFilePath.Text;

            // Tính thời lượng (tạm thời để 0, hoặc dùng WMPLib để lấy sau)
            // Có thể thêm logic lấy Duration nếu cần

            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
