namespace MusicApp
{
    partial class MainForm
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnPlay = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lstSongs = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtLyrics = new System.Windows.Forms.TextBox();
            this.trkVolume = new System.Windows.Forms.TrackBar();
            this.lblArtist = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddSong = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.trkVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(457, 513);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 28);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "▶";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lstSongs
            // 
            this.lstSongs.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstSongs.FormattingEnabled = true;
            this.lstSongs.ItemHeight = 16;
            this.lstSongs.Location = new System.Drawing.Point(0, 0);
            this.lstSongs.Name = "lstSongs";
            this.lstSongs.Size = new System.Drawing.Size(251, 553);
            this.lstSongs.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(270, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(176, 33);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Tên bài hát";
            // 
            // txtLyrics
            // 
            this.txtLyrics.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLyrics.Location = new System.Drawing.Point(313, 225);
            this.txtLyrics.Multiline = true;
            this.txtLyrics.Name = "txtLyrics";
            this.txtLyrics.ReadOnly = true;
            this.txtLyrics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLyrics.Size = new System.Drawing.Size(381, 159);
            this.txtLyrics.TabIndex = 3;
            this.txtLyrics.Text = " ";
            // 
            // trkVolume
            // 
            this.trkVolume.LargeChange = 10;
            this.trkVolume.Location = new System.Drawing.Point(684, 489);
            this.trkVolume.Maximum = 100;
            this.trkVolume.Name = "trkVolume";
            this.trkVolume.Size = new System.Drawing.Size(97, 56);
            this.trkVolume.TabIndex = 4;
            this.trkVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkVolume.Value = 80;
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtist.Location = new System.Drawing.Point(270, 73);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(83, 25);
            this.lblArtist.TabIndex = 2;
            this.lblArtist.Text = "Ca sĩ: ...";
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(457, 484);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 28);
            this.btnPause.TabIndex = 0;
            this.btnPause.Text = "⏸";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(295, 484);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 28);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "■";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(376, 484);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 28);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "◀";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenre.Location = new System.Drawing.Point(270, 110);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(108, 25);
            this.lblGenre.TabIndex = 2;
            this.lblGenre.Text = "Thể loại: ...";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuration.Location = new System.Drawing.Point(270, 158);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(165, 25);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "Thời lượng: 00:00";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(538, 484);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 28);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "▶";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnMute
            // 
            this.btnMute.Location = new System.Drawing.Point(619, 484);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(75, 28);
            this.btnMute.TabIndex = 5;
            this.btnMute.Text = "🔇";
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(533, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(142, 22);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.Text = "Tìm bài hát...";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(695, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddSong
            // 
            this.btnAddSong.Location = new System.Drawing.Point(695, 77);
            this.btnAddSong.Name = "btnAddSong";
            this.btnAddSong.Size = new System.Drawing.Size(75, 23);
            this.btnAddSong.TabIndex = 7;
            this.btnAddSong.Text = "✚ Thêm bài hát";
            this.btnAddSong.UseVisualStyleBackColor = true;
            this.btnAddSong.Click += new System.EventHandler(this.btnAddSong_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(35, 158);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(181, 124);
            this.axWindowsMediaPlayer1.TabIndex = 8;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.btnAddSong);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.trkVolume);
            this.Controls.Add(this.txtLyrics);
            this.Controls.Add(this.lstSongs);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Music Player";
            ((System.ComponentModel.ISupportInitialize)(this.trkVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private System.Windows.Forms.Button btnPlay;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListBox lstSongs;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtLyrics;
        private System.Windows.Forms.TrackBar trkVolume;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddSong;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

