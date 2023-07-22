using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Parent_child
{
    public partial class Child : Form
    {
        public event EventHandler ChildFormClosed;
        private Parent parent = null;
        private string syncroText;
        public string SyncroText
        {
            get { return syncroText; }
            set
            {
                syncroText = value;
                if (syncroText != textBox1.Text) textBox1.Text = value;
            }
        }

        public int FormIndex { get; set; }
        Random random = new Random();

        public Child()
        {
            InitializeComponent();

        }
        public Child(Parent parent)
        {
            InitializeComponent();
            Color newColor = Color.FromArgb(random.Next(180, 255), random.Next(180, 255), random.Next(180, 255));
            this.BackColor = newColor;


            this.parent = parent;
        }

        private void Child_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            parent.SyncroText = textBox1.Text;

        }
    }
}
