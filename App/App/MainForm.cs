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
using System.Collections.Concurrent;

namespace App
{
    public partial class MainForm : Form
    {
        public static SerialPort sp = new SerialPort("COM3", 9600);
        Thread SenderThread;
        Thread ReadThread;
        ConcurrentQueue<String> buffer;
        Mapping currentMapping;
        public MainForm()
        {
            InitializeComponent();

            buffer = new ConcurrentQueue<string>();
            SenderThread = new Thread(UseKeyBuffer);
            ReadThread = new Thread(ReadFromArduino);

            currentMapping = new Mapping("Spotify");
        }

        private void UseKeyBuffer()
        {
            while (true)
            {
                if (buffer.Count == 0) { Thread.Sleep(1000); continue; }
                string result;
                if (buffer.TryDequeue(out result))
                    SendKeys.SendWait(result);
                Application.DoEvents();
                Thread.Sleep(200);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (sp.IsOpen) sp.Close();
            base.OnClosing(e);
        }

        protected override void OnShown(EventArgs e)
        {
            try
            {
                sp.Open();
            }
            catch (SystemException)
            {
                Console.WriteLine("Error opening port.");
            }
            if (sp.IsOpen)
            {
                SenderThread.Start();
                ReadThread.Start();
                Console.WriteLine("Port COM3 is open.");
            }
            base.OnShown(e);
        }

        private void ReadFromArduino()
        {
            while (true)
            {
                if (!sp.IsOpen) { Thread.Sleep(2000); continue; }
                Console.WriteLine("Checking for incoming data....");
                while (sp.BytesToRead > 0)
                {
                    EventType val = (EventType)sp.ReadByte();
                    Console.WriteLine("Got value: {0}", val);
                    string action = currentMapping.GetAction(val);
                    if (action != null) buffer.Enqueue(action);
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
