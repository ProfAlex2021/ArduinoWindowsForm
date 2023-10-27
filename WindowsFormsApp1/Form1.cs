using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SerialPort usb;
        
        public Form1()
        {
            InitializeComponent();
            usb = new SerialPort("COM5", 9600);
            usb.DataReceived += Usb_DataReceived;
        }

        private void Usb_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string linha = (sender as SerialPort).ReadLine();
        }

        bool ligado = false;
        private void Button1_Click(object sender, EventArgs e)
        {
            if(ligado)
            {
                pictureBox1.BackColor = Color.Blue;
                ligado = false;
            }
            else
            {
                pictureBox1.BackColor = SystemColors.Control;
                ligado = true;
            }
        }
    }
}
