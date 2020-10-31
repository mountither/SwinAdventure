using InitialGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwinAdven;
using System.Runtime.InteropServices;

namespace GUI
{
    public partial class GUIStart : Form
    {
        public GUIStart()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Button1_Click(object sender, EventArgs e)
        {
            GUIEnter enterNew = new GUIEnter(nameBox.Text, describeBox.Text);
            this.Hide();
            enterNew.StartPosition = FormStartPosition.Manual;
            enterNew.Location = this.Location;
            enterNew.Size = this.Size;
            enterNew.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public string NameTextBox
        {
            get
            {
                return nameBox.Text;
            }
            set
            {
                nameBox.Text = value;
            }
        }
        public string DescTextBox
        {
            get
            {
                return describeBox.Text;
            }
            set
            {
                describeBox.Text = value;
            }
        }


        public bool ButtonStartEnabled
        {
            get
            {
                return button1.Enabled;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(describeBox.Text) && !string.IsNullOrWhiteSpace(nameBox.Text);
        }

        private void describeBox_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(describeBox.Text) && !string.IsNullOrWhiteSpace(nameBox.Text);
        }
    }
}
