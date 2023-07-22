namespace Parent_child
{
    public partial class Parent : Form
    {
        public List<Child> Forms = new();

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


        public Parent()
        {
            InitializeComponent();
            MakeNewChild();
        }



        private void MakeNewChild()
        {
            var newChildForms = new Child(this);
            newChildForms.Show();
            newChildForms.FormIndex += Forms.Count();
            newChildForms.Text = $"Child form N{newChildForms.FormIndex}";
            newChildForms.FormClosed += ChildForm_FormClosed;
            Forms.Add(newChildForms);
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            MakeNewChild();
        }

        private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.Remove((Child)sender);
            int formIndex = 0;
            foreach (var child in Forms)
            {

                child.FormIndex = formIndex++;
                child.Text = $"Child form N{child.FormIndex}";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (var child in Forms)
            {
                child.SyncroText = textBox1.Text;
            }
        }
    }
}