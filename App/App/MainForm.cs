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
        Thread InitThread;

        List<String> buffer;
        Mapping currentMapping;
        StartingDialog dialog = new StartingDialog();

        public List<Mapping> Mappings { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            buffer = new List<String>();
            SenderThread = new Thread(UseKeyBuffer);
            ReadThread = new Thread(ReadFromArduino);
        }

        private void UseKeyBuffer()
        {
            while (true)
            {
                if (buffer.Count == 0) { Console.WriteLine("Empty buffer."); Thread.Sleep(200); continue; }
                string result = buffer[0];
                SendKeys.SendWait(result);
                buffer.RemoveAt(0);
                Application.DoEvents();
                Thread.Sleep(100);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (sp.IsOpen) sp.Close();
            base.OnClosing(e);
        }
        private void ShowInitDialog()
        {
            dialog.ShowDialog();
        }

        protected override void OnShown(EventArgs e)
        {
            bool errorPort = false;
            InitThread = new Thread(ShowInitDialog);
            InitThread.Start();
            dialog.LabelText = "Opening port...";
            Thread.Sleep(1000);
            try
            {
                sp.Open();
                dialog.Progress = 20;
            }
            catch (SystemException)
            {
                dialog.LabelText = "Error opening port!";
                Thread.Sleep(1000);
                errorPort = true;
            }
            if (sp.IsOpen)
            {
                SenderThread.Start();
                ReadThread.Start();
                Console.WriteLine("Port COM3 is open.");
                dialog.LabelText = "Port opened.";
                dialog.Progress = 50;
            }
            Thread.Sleep(1000);
            if (dialog.Visible)
            {
                dialog.LabelText = "Loading mappings...";
                dialog.Progress = 75;
                string[] mappings = Mapping.GetAvailableMappings();
                this.Mappings = new List<Mapping>();
                foreach (string m in mappings)
                {
                    this.Mappings.Add(new Mapping(m));
                }
                this.mappingComboBox.DataSource = Mappings;
                Thread.Sleep(1000);
                dialog.LabelText = "Done!";
                dialog.Progress = 100;
                Thread.Sleep(1000);
                dialog.CallClose();
            }

            if (Mappings.Count != 0)
            {
                currentMapping = Mappings[0];
            }
            if (errorPort)
            {
                while (MessageBox.Show("Error establishing Bluetooth connection. Retry?",
                    "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        sp.Open();
                    }
                    catch (SystemException)
                    {
                        continue;
                    }
                    errorPort = false;
                    break;
                }
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
                    try
                    {
                        EventType val = (EventType)Enum.Parse(typeof(EventType), sp.ReadByte().ToString());
                        Console.WriteLine("Got byte from arduino");
                        string action = currentMapping.GetAction(val);
                        Console.WriteLine("Action: {0}", action);
                        if (action != null)
                        {
                            Console.WriteLine("Enqueuing action {0}", action);
                            buffer.Add(action);
                        }
                    }
                    catch (ArgumentException)
                    {
                        continue;
                    }
                }
                Application.DoEvents();
                Thread.Sleep(200);
            }
        }

        private void mappingComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb != null)
            {
                this.currentMapping = (Mapping) cb.SelectedItem;
            }
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
