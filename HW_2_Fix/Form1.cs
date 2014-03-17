using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using DevExpress.XtraReports.UI;
=======
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System.Xml.Serialization;
>>>>>>> Fix

namespace Options
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            comboBox1.Text = "1024 x 768";
            checkBox1.Checked = true;
            checkBox2.Checked = true;
        }

    /*    private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Options|*.optionsData";
            var sfdResult = sfd.ShowDialog();
            if (sfdResult == DialogResult.OK)
            {

                userOptions userOptionsEx = new userOptions();
                if (checkBox1.Checked == true)
                    userOptionsEx.smoothing = true;
                if (checkBox2.Checked == true)
                    userOptionsEx.verticalSync = true;
                userOptionsEx.windowSize = comboBox1.Text;
                userOptionsEx.brightLevel = trackBar1.Value;
                XmlSerializer xs = new XmlSerializer(typeof(userOptions));
                var fileName = sfd.FileName;
                var fileStream = File.Create(fileName);
                xs.Serialize(fileStream, userOptionsEx);
                fileStream.Close();
            }
        } */

    /*    private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Options|*.optionsData";
            var ofdResult = ofd.ShowDialog();
            if (ofdResult == DialogResult.OK)
            {
                var xs = new XmlSerializer(typeof(userOptions));
                var file = File.Open(ofd.FileName, FileMode.Open);
                var userOptionsOpen = (userOptions)xs.Deserialize(file);
                file.Close();
                comboBox1.Text = userOptionsOpen.windowSize;
                checkBox1.Checked = userOptionsOpen.smoothing;
                checkBox2.Checked = userOptionsOpen.verticalSync;
                trackBar1.Value = userOptionsOpen.brightLevel;
            }
        } */

        public class userOptions
        {
            public string windowSize { get; set; }
            public bool verticalSync { get; set; }
            public bool smoothing { get; set; }
            public int brightLevel { get; set; }
         }
=======
            var rnd = new Random();
            comboBox1.Text = rnd.Next(256, 2048).ToString() + "x" + rnd.Next(256, 2048).ToString();
            trackBar1.Value = rnd.Next(1, 10);
            listBox1.Items.Add(comboBox1.Text + " " + trackBar1.Value);
        }

        //private void buttonSave_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.Filter = "Options|*.optionsData";
        //    var sfdResult = sfd.ShowDialog();
        //    if (sfdResult == DialogResult.OK)
        //    {
        //        userOptions userOptionsEx = new userOptions();
        //        if (checkBox1.Checked == true)
        //            userOptionsEx.smoothing = true;
        //        if (checkBox2.Checked == true)
        //            userOptionsEx.verticalSync = true;
        //        userOptionsEx.windowSize = comboBox1.Text;
        //        userOptionsEx.brightLevel = trackBar1.Value;
        //        XmlSerializer xs = new XmlSerializer(typeof(userOptions));
        //        var fileName = sfd.FileName;
        //        var fileStream = File.Create(fileName);
        //        xs.Serialize(fileStream, userOptionsEx);
        //        fileStream.Close();
        //    }
        //} 

        //private void buttonLoad_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.Filter = "Options|*.optionsData";
        //    var ofdResult = ofd.ShowDialog();
        //    if (ofdResult == DialogResult.OK)
        //    {
        //        var xs = new XmlSerializer(typeof(userOptions));
        //        var file = File.Open(ofd.FileName, FileMode.Open);
        //        var userOptionsOpen = (userOptions)xs.Deserialize(file);
        //        file.Close();
        //        comboBox1.Text = userOptionsOpen.windowSize;
        //        checkBox1.Checked = userOptionsOpen.smoothing;
        //        checkBox2.Checked = userOptionsOpen.verticalSync;
        //        trackBar1.Value = userOptionsOpen.brightLevel;
        //    }
        //} 

        public class userOptions
        {
            //public string windowSize { get; set; }
            //public bool verticalSync { get; set; }
            //public bool smoothing { get; set; }
            //public int brightLevel { get; set; }
            public List<string> outData { get; set;}
         }
    
>>>>>>> Fix

        //Создание
        public userOptions createUserOptions()
        {
<<<<<<< HEAD
            userOptions uo = new userOptions();
            uo.windowSize = comboBox1.Text;
            uo.brightLevel = trackBar1.Value;
            return uo;           
        } 

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Add(comboBox1.Text + " " + trackBar1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {


=======
            var uo = new userOptions();
            uo.outData = new List<string>();
            foreach (string now in listBox1.Items)
            {
                uo.outData.Add(now); 
            }         
            return uo;           
        } 

        private void button2_Click(object sender, EventArgs e)
        {
>>>>>>> Fix
            XtraReport1 report = new XtraReport1();            
            userOptions uo = createUserOptions();
            report.DataSource = new BindingSource() { DataSource = uo };
            report.ShowPreview();
<<<<<<< HEAD
        }        
=======
        } 
>>>>>>> Fix
    }
}

