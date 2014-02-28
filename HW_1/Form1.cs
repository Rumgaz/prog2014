using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

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
            comboBox1.Text = "1024 x 768";
            checkBox1.Checked = true;
            checkBox2.Checked = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Options|*.optionsData";
            var sfdResult = sfd.ShowDialog();
            if (sfdResult == DialogResult.OK)
            {

                userOptions userOptions = new userOptions();
                if (checkBox1.Checked == true)
                    userOptions.smoothing = true;
                if (checkBox2.Checked == true)
                    userOptions.verticalSync = true;
                userOptions.windowSize = comboBox1.Text;
                userOptions.brightLevel = trackBar1.Value;
                XmlSerializer xs = new XmlSerializer(typeof(userOptions));
                var fileName = sfd.FileName;
                var fileStream = File.Create(fileName);
                xs.Serialize(fileStream, userOptions);
                fileStream.Close();
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
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
        }

        public class userOptions
        {
            public string windowSize { get; set; }
            public bool verticalSync { get; set; }
            public bool smoothing { get; set; }
            public int brightLevel { get; set; }
        }
        
    }
}

