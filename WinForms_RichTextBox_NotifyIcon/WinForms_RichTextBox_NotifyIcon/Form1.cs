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

namespace WinForms_RichTextBox_NotifyIcon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            notifyIcon1.BalloonTipText = "Нажмите, чтобы отобразить окно";
            notifyIcon1.BalloonTipTitle = "Подсказка";
            notifyIcon1.ShowBalloonTip(12);
            notifyIcon1.DoubleClick += NotifyIcon1_Click;
            ContextMenu cm = new ContextMenu();
            MenuItem showYouTube = new MenuItem("Хочу YouTube");
            showYouTube.Click += ShowYouTube_Click;
            cm.MenuItems.Add(showYouTube);
            notifyIcon1.ContextMenu = cm;
            richTextBox1.LinkClicked += RichTextBox1_LinkClicked;
            richTextBox1.DetectUrls = true;
        }

        private void RichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void ShowYouTube_Click(object sender, EventArgs e)
        {
            Process.Start("");//ссылка 
        }

        private void NotifyIcon1_Click(object sender, EventArgs e)
        {
            NotifyIcon item = sender as NotifyIcon;
            
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(dialog.FileName, Encoding.Default);
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog.Font;
                richTextBox1.SelectionColor = fontDialog.Color;
            }
        }
    }
}