using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App
{
    public partial class Form1 : Form
    {
        public const int SINGLE_CLICK = 4;
        public static SerialPort sp = new SerialPort("COM3", 9600);
        delegate void Func();
        Thread SenderThread;
        Thread ReadThread;
        List<string> buffer;
        public Form1()
        {
            InitializeComponent();
            SenderThread = new Thread(UseKeyBuffer);
            SenderThread.Start();
            buffer = new List<string>();
            ReadThread = new Thread(ReadFromArduino);
            ReadThread.Start();
        }

        private void UseKeyBuffer()
        {
            while (true)
            {
                if (buffer.Count == 0) { Thread.Sleep(1000); continue; }
                SendKeys.SendWait(buffer.ElementAt<String>(0));
                buffer.RemoveAt(0);
                Application.DoEvents();
                Thread.Sleep(200);
            }
        }

        Func func;
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            func = ReadFromArduino;
            try
            {
                sp.Open();
            }
            catch (SystemException)
            {
                Console.WriteLine("Error opening port.");
            }
            if (sp.IsOpen) Console.WriteLine("Port COM3 is open.");

        }

        private void ReadFromArduino()
        {
            while (true)
            {
                if (!sp.IsOpen) { Thread.Sleep(2000); continue; }
                Console.WriteLine("Checking for incoming data....");
                while (sp.BytesToRead > 0)
                {
                    
                    int val = sp.ReadByte();
                    Console.WriteLine("Got value: {0}", val);
                    switch (val)
                    {
                        case SINGLE_CLICK:
                            Console.WriteLine("GOTCLICK");
                            buffer.Add(" ");
                            break;
                        default:
                            break;
                    }
                }
                Application.DoEvents();
                Thread.Sleep(1000);
            }
        }

        public void AppendToTextbox(char b)
        {
            textBox1.Text += b.ToString();
        }

        public void AppendToTextbox(String s)
        {
            textBox1.Text += s;
        }
        /*
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("Received data!");
            switch (e.EventType)
            {
                case SerialData.Chars:
                    AppendToTextbox(e.ToString());
                    break;
                
            }
        }

        private void serialPort1_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            
            Console.WriteLine("received error wtf");
        }*/
    }
}
