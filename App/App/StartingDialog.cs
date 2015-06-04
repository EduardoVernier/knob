using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class StartingDialog : Form
    {
        delegate void SetTextCallback(string text);
        delegate void SetProgressCallback(int progress);
        public StartingDialog()
        {
            InitializeComponent();
            
        }

        public string LabelText
        {
            get { return this.infoText.Text; }
            set
            {
                if (value != null)
                {
                    if (this.infoText.InvokeRequired)
                    {
                        SetTextCallback d = new SetTextCallback(SetText);
                        this.Invoke(d, new object[] { value });
                    }
                    else
                    {
                        this.infoText.Text = value;
                    }
                }
            }
        }

        public int Progress
        {
            get { return this.progressBar.Value; }
            set
            {
                if (this.progressBar.InvokeRequired)
                {
                    SetProgressCallback d = new SetProgressCallback(SetProgress);
                    this.Invoke(d, new object[] { value });
                }
                else
                {
                    this.progressBar.Value = value;
                }
            }
        }

        public void SetText(String text)
        {
            this.infoText.Text = text;
        }

        public void SetProgress(int progress)
        {
            this.progressBar.Value = progress;
        }

        public void CallClose()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(delegate() { Close(); }));
            }
            else
            {
                this.Close();
            }
        }
    }
}
