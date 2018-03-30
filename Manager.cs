using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
           
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                FileStream file = new FileStream("./TrainedFaces/TrainedLabels.txt", FileMode.Open);
                StreamReader read = new StreamReader(file);
                var arr = read.ReadToEnd().ToString().Split('%');
                for (int i = 1; i < arr.Length - 1; i++)
                {
                    listBox1.Items.Add(arr[i]);
                }
                file.Close();
            }
          catch(Exception ex)
            {
                MessageBox.Show("Không có data");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = listBox1.SelectedItem.ToString();
            int index = listBox1.SelectedIndex;
            index++;
            pictureBox1.BackgroundImage = Image.FromFile("./TrainedFaces/face"+index+".bmp");
        }
    }
}
