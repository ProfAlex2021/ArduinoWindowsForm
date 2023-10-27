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
            usb = new SerialPort("COM3", 9600);
            usb.DataReceived += Usb_DataReceived;
        }

        private void Usb_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string linha = (sender as SerialPort).ReadLine().Trim('\r');
            switch (linha)
            {
                case "1":
                    TrocarCor(true);
                    ligado = true;
                    break;
                case "0":
                    TrocarCor(false);
                    ligado = false;
                    break;
            }
        }

        bool ligado = false;
        private void Button1_Click(object sender, EventArgs e)
        {
            TrocarCor(ligado);
            ligado = !ligado;
        }

        private void TrocarCor(bool estado)
        {
            if (estado)
            {
                pictureBox1.BackColor = Color.Blue;
            }
            else
            {
                pictureBox1.BackColor = SystemColors.Control;
            }
        }
    }
}
