using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloseButtonTabPage
{
    public partial class Form1 : Form
    {
        Point _imageLocation = new Point(20, 4);
        Point _imgHitArea = new Point(20, 4);
        Image closeImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Image img = new Bitmap(closeImage);
            Rectangle r = e.Bounds;
            r = this.tabControl1.GetTabRect(e.Index);
            r.Offset(2, 2);
            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = this.Font;
            string title = this.tabControl1.TabPages[e.Index].Text;
            e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
            e.Graphics.DrawImage(img, new Point(r.X + (this.tabControl1.GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            Point p = e.Location;
            int _tabWidth = 0;
            _tabWidth = this.tabControl1.GetTabRect(tabControl.SelectedIndex).Width - (_imgHitArea.X);
            Rectangle r = this.tabControl1.GetTabRect(tabControl.SelectedIndex);
            r.Offset(_tabWidth, _imgHitArea.Y);
            r.Width = 16;
            r.Height = 16;
            if (tabControl1.SelectedIndex >= 1)
            {
                if (r.Contains(p))
                {
                    TabPage tabPage = (TabPage)tabControl.TabPages[tabControl.SelectedIndex];
                    tabControl.TabPages.Remove(tabPage);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            closeImage = Properties.Resources.Closebtn16;
            tabControl1.Padding = new Point(20, 4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int counter = tabControl1.TabCount;
            counter++;
            tabControl1.TabPages.Add($"tabPage{counter}"); 
        }
    }
}
