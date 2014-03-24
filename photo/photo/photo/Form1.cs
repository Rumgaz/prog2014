using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace photo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //var
        Bitmap inPicture;
        bool mouseClick;
        //***
        
       
        //Цветовые уровни
        private void button1_Click(object sender, EventArgs e)
        {
            var color = new Color();
            //Повторить для зелёного и синего, ставя соответсвующий trackBar, тогда будет как 
            //в фотошопах, но у меня 3 цвета ноут не тянет.
            for (int h = 0; h < inPicture.Height; h++)
            {
                for (int w = 0; w < inPicture.Width; w++)
                {
                    color = inPicture.GetPixel(w, h);
                    inPicture.SetPixel(w, h, Color.FromArgb(trackBar1.Value, color.G, color.B));
                }
            }
            pictureBox1.Refresh();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }  
        //**

        //Open/Save  
        private void openButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                inPicture = (Bitmap)Image.FromFile(ofd.FileName);
                pictureBox1.Enabled = true;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = inPicture;
                tabControl1.Visible = true;
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "jpg|*.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var fileName = sfd.FileName;
                var fileStream = File.Create(sfd.FileName);
                inPicture.Save(fileStream, inPicture.RawFormat);

            }
        }
        //***

        //Рисование
        
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseClick)
            {   
                //Рисует малёха не там, где курсор
                var selectedColor = new Color();
                 if (radioButton1.Checked) 
                     selectedColor = Color.Black; 
                 else
                     selectedColor=Color.Green;
                 if ((Cursor.Position.X < inPicture.Width) && 
                     (Cursor.Position.Y < inPicture.Height))
                 {
                     inPicture.SetPixel(Cursor.Position.X, Cursor.Position.Y, selectedColor);
                     pictureBox1.Refresh();
                 }
                           
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseClick = true;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClick = false;
        }
        //***
       

        




      
    }
}
