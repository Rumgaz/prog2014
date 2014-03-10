using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraReports.UI;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randomValue = rnd.Next(1, 100);
            listBox1.Items.Add(randomValue);
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            //Передача значений в outData
            outData Data = new outData();
            for (int i = 0; i < listBox1.Items.Count; i++)                
                Data.Numbers[i] = (listBox1.Items[i].ToString());
            // Data.Numbers.Add(listBox1.Items[i].ToString());
            //ссылка на объект не указывает на экземпляр класса [?]
        }


        //На передачу
        public class outData
        {
            public List<string> Numbers {get; set;}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XtraReport1 report = new XtraReport1();
            report.DataSource = new BindingSource() { DataSource = Data }; //Которая сломана 
            report.ShowPreview();                               //Выставляем его в конструкторе 
        }


    }
}