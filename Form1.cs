using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
     
        private Control activeControle;
        private Point previousPosition;
        private PictureBox myControle;
        public Form1()
        {

            InitializeComponent();
        }

        //Method to create pictureBox and import image 
        public void GenerateIcon(string iconName)
        {
            myControle = new PictureBox
            {
                Name = "pictureBox",
                Size = new Size(120, 120),
                Location = new Point(100, 100),
                Image = Image.FromFile(iconName),
            };
            myControle.Location = new Point(30, 50);
            myControle.MouseDown += new MouseEventHandler(myControle_MouseDown);
            myControle.MouseMove += new MouseEventHandler(myControle_MouseEvent);
            myControle.MouseUp += new MouseEventHandler(myControle_Mouseup);
            if (metroTabControl1.SelectedTab == metroTabControl1.TabPages["metroTabPage2"])
            {

                metroTabPage2.Controls.Add(myControle);
            }
            else if (metroTabControl1.SelectedTab == metroTabControl1.TabPages["metroTabPage3"])
            {

                metroTabPage3.Controls.Add(myControle);
            }
        }

        private void myControle_MouseDown(object sender, MouseEventArgs e)
        {
            activeControle = sender as Control;
            previousPosition = e.Location;
            Cursor = Cursors.Hand;
        }

        private void myControle_Mouseup(object sender, MouseEventArgs e)
        {
            activeControle = null;
            Cursor = Cursors.Default;
        }

        private void myControle_MouseEvent(object sender, MouseEventArgs e)
        {
            if (activeControle == null || activeControle != sender)
            {
                return;
            }
            var loaction = activeControle.Location;
            loaction.Offset(e.Location.X - previousPosition.X, e.Location.Y - previousPosition.Y);
            activeControle.Location = loaction;
        }
   
        //autoclave icon button
        private void button1_Click(object sender, EventArgs e)
        {
            //please change her the image of autoclave path 
            GenerateIcon("C:\\Users\\Reem El-Shenawy\\source\\repos\\WindowsFormsApp1\\Resources\\Autoclave.png");

        }
        //Coverdesatvent icon button
        private void button2_Click(object sender, EventArgs e)
        {
            //please change her the path of coverdestvent image
            GenerateIcon("C:\\Users\\Reem El-Shenawy\\source\\repos\\WindowsFormsApp1\\Resources\\Coveredgasvent.png");
        }
        //knockoutdrum icon button
        private void IconButton_Click(object sender, EventArgs e)
        {
            //please change her the path of the knockoutdrum image 
            GenerateIcon("C:\\Users\\Reem El-Shenawy\\source\\repos\\WindowsFormsApp1\\Resources\\Knockoutdrum.png");

        }
       //here method to creat arrow 
        private void metroTabPage2_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 30);
          //  p.StartCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
            p.EndCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
            e.Graphics.DrawLine(p, 20, 20, 100, 100);


        }
        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
