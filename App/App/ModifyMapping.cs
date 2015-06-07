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
    public partial class ModifyMapping : Form
    {
        private TextBox[] textBoxes;

        public Mapping Mapping { get; set; }

        public ModifyMapping()
        {
            InitializeComponent();
            if (this.Mapping == null) this.Mapping = new Mapping();
        }

        public ModifyMapping(Mapping m) :
                this()
        {
            this.Mapping = m;
            this.tbAppName.Text = m.AppName;
            this.textBoxes = new TextBox[] {
                tbSINGLE_CLICK, tbDOUBLE_CLICK, tbTRIPLE_CLICK,
                tbROTATE_CCW, tbROTATE_CW
            };
        }


        private void handleKeystroke(object sender, KeyEventArgs e)
        {
            TextBox s = sender as TextBox;

            s.Text = "";
            if (e.Modifiers.HasFlag(Keys.Control))
            {
                s.Text += "^";
            }
            if (e.Modifiers.HasFlag(Keys.Shift))
            {
                s.Text += "+";
            }
            if (e.Modifiers.HasFlag(Keys.Alt))
            {
                s.Text += "%";
            }
            s.Text += ((char)e.KeyValue).ToString();
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (this.tbAppName.Text.Length == 0)
            {
                MessageBox.Show("O nome do aplicativo não pode ser vazio", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Mapping x = null;
            if (this.tbAppName.Text != this.Mapping.AppName)
            {
                x = new Mapping(this.tbAppName.Text);
            }
            else x = this.Mapping;
            if (tbSINGLE_CLICK.Text.Length > 0)
                x.AddAction(EventType.SINGLE_CLICK, tbSINGLE_CLICK.Text);
            if (tbDOUBLE_CLICK.Text.Length > 0)
                x.AddAction(EventType.DOUBLE_CLICK, tbDOUBLE_CLICK.Text);
            if (tbTRIPLE_CLICK.Text.Length > 0)
                x.AddAction(EventType.TRIPLE_CLICK, tbTRIPLE_CLICK.Text);
            if (tbROTATE_CCW.Text.Length > 0)
                x.AddAction(EventType.ROTATE_CCW, tbROTATE_CCW.Text);
            if (tbROTATE_CW.Text.Length > 0)
                x.AddAction(EventType.ROTATE_CW, tbROTATE_CW.Text);
            if (x.SaveToFile())
            {
                this.Mapping = x;
                this.Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
