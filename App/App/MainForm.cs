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
using System.IO;

namespace App
{
    public partial class MainForm : Form
    {
        public static SerialPort sp;
        Thread SenderThread;
        Thread ReadThread;
        Thread InitThread;

        List<String> buffer;
        Mapping currentMapping;
        StartingDialog dialog = new StartingDialog();
        private string port;

        public List<Mapping> Mappings { get; private set; }

        public MainForm()
        {
            InitializeComponent();

            buffer = new List<String>();
            SenderThread = new Thread(UseKeyBuffer);
            ReadThread = new Thread(ReadFromArduino);
            try
            {
                using (StreamReader s = new StreamReader("port.txt"))
                {
                    this.port = s.ReadLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Especifique a porta para usar:");
                String s = Console.ReadLine();
                this.port = s;
            }
            sp = new SerialPort(this.port, 9600);
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
            dialog.LabelText = "Conectando via Bluetooth...";
            Thread.Sleep(1000);
            try
            {
                dialog.Progress = 20;
                sp.Open();
            }
            catch (SystemException)
            {
                dialog.LabelText = "Erro na conexão!";
                Thread.Sleep(750);
                errorPort = true;
            }
            if (sp.IsOpen)
            {
                SenderThread.Start();
                ReadThread.Start();
                Console.WriteLine("Port COM3 is open.");
                dialog.LabelText = "Conexão bem-sucedida.";
                dialog.Progress = 50;
            }
            Thread.Sleep(1000);
            if (dialog.Visible)
            {
                dialog.LabelText = "Carregando perfis...";
                dialog.Progress = 75;
                ReloadMappings();
                Thread.Sleep(1000);
                dialog.LabelText = "Pronto!";
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
                while (MessageBox.Show("Erro de conexão bluetooth. Tentar novamente?",
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
                while (sp.BytesToRead > 0)
                {
                    try
                    {
                        EventType val = (EventType)Enum.Parse(typeof(EventType), sp.ReadByte().ToString());
                        string action = currentMapping.GetAction(val);
                        if (action != null)
                        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            ModifyMapping win = new ModifyMapping(currentMapping);
            win.ShowDialog();
            ReloadMappings();
        }

        private void ReloadMappings()
        {
            string[] mappings = Mapping.GetAvailableMappings();
            this.Mappings = new List<Mapping>();
            foreach (string m in mappings)
            {
                this.Mappings.Add(Mapping.ByName(m));
            }
            this.mappingComboBox.DataSource = Mappings;
        }

        private void btnCreateMapping_Click(object sender, EventArgs e)
        {
            ModifyMapping win = new ModifyMapping();
            win.ShowDialog();
            ReloadMappings();
        }

    }
}
