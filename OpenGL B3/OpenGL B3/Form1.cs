using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tao.OpenGl;
using System.Xml.Serialization;
using System.IO;

namespace OpenGL_B3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            simpleOpenGlControl1.InitializeContexts();
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            int w = simpleOpenGlControl1.Width;
            int h = simpleOpenGlControl1.Height;
            Gl.glViewport(0, 0, w, h);
            Glu.gluPerspective(90, w / h, 1, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Glu.gluLookAt(0, 0, 5, 0, 0, 1, 0, 1, 0);

            
        }
        

        //*****
        //Программа 1
        //*****

        public int rotor1=0 , rotor2=0, rotor3=0;
        void giveRotor()
        {
            timer2.Enabled = true;
            rotor1 = rotor2 = rotor3 = 0;
            var ofd = new OpenFileDialog();
            var file = File.Open(fileName, FileMode.Open);
            var xs = new XmlSerializer(typeof(TrianglesOptions));
            var triaglesOptionOUT = (TrianglesOptions)xs.Deserialize(file);
            file.Close();

            if (triaglesOptionOUT.rotor == 0)
                rotor1 = rotor2 = rotor3 = 1;
            if (triaglesOptionOUT.rotor == 1)
                rotor1 = 1;
            if (triaglesOptionOUT.rotor == 2)
                timer2.Enabled = false;
        }


        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
           // giveRotor();           
            
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();           
            
            Gl.glRotated(andgle, rotor1, rotor2, rotor3);
            
            Gl.glBegin(Gl.GL_TRIANGLES);

            var ofd = new OpenFileDialog();
            var file = File.Open(fileName, FileMode.Open);
            var xs = new XmlSerializer(typeof(TrianglesOptions));
            var triaglesOptionOUT = (TrianglesOptions)xs.Deserialize(file);
            file.Close();


            Gl.glColor3f(triaglesOptionOUT.color[0], 0, 0);
            Gl.glVertex3f(-triaglesOptionOUT.side, 0, 0);

            Gl.glColor3f(0, triaglesOptionOUT.color[1], 0);
            Gl.glVertex3f(triaglesOptionOUT.side, 0, 0);

            Gl.glColor3f(0, 0, triaglesOptionOUT.color[2]);
            Gl.glVertex3f(0, triaglesOptionOUT.side, 0);

            Gl.glEnd();

            Gl.glPopMatrix();
        }


        public double andgle = 0;

        private void timer2_Tick(object sender, EventArgs e)
        {
            simpleOpenGlControl1.Invalidate();
            andgle += 10;   
        }


        //*****
        //Программа 2
        //*****
        string fileName = "trianglesOptions";
        private void drawButton_Click(object sender, EventArgs e)
        {
            //Сохранение
            var sfd = new SaveFileDialog();   
                var trianglesOptionsIN = new TrianglesOptions();
                trianglesOptionsIN.side = Convert.ToInt32(textBox1.Text);
                trianglesOptionsIN.color.Add(redBar.Value);
                trianglesOptionsIN.color.Add(greenBar.Value);
                trianglesOptionsIN.color.Add(blueBar.Value);
                trianglesOptionsIN.rotor = whatToDo();
            var xs = new XmlSerializer(typeof(TrianglesOptions));            
            var fileStream = File.Create(fileName);
            xs.Serialize(fileStream, trianglesOptionsIN);
            fileStream.Close();         

            giveRotor();
        }
        //Задание треугольника
        public class TrianglesOptions
        {
            public int side { get; set; }
            public List<float> color = new List<float>();

            public float rotor { get; set; }
            
        }
        //Способ закрутки
        int whatToDo()
        {
            
            if (comboBox1.Text == "вертелось чудно.")
                return 0;
            if (comboBox1.Text == "вертелось спокойно.")
                return 1;
                return 2;
        }
        //В textbox1 вводим только цифры
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }           

    }
}
