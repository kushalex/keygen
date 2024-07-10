using System.Media;
using System.Text;
using System.Windows.Forms;

namespace zarkey
{
    public partial class Form1 : Form
    {
        public Point mouseLocation;
        private SoundPlayer soundPlayer;
        public Form1()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer(ZARKEY.Properties.Resources.zarkey);
            soundPlayer.PlayLooping();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = panel1;
            panel1.BackColor = Color.FromArgb(200, 0, 0, 0);
        }

        // "Generate" button
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a username.", "Username Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Text = "";
                return;
            }

            string userInput = textBox1.Text;
            StringBuilder asciiBuilder = new StringBuilder();
            foreach (char c in userInput)
            {
                // char to ASCII
                asciiBuilder.Append(((int)c).ToString() + " ");
            }

            // set modifiedText in textBox3
            string modifiedText = asciiBuilder.ToString().Trim(); // remove trailing space
            textBox3.Text = modifiedText;
        }

        // "Exit" button
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It's watching you now.", "", MessageBoxButtons.OK);
            Application.Exit();
        }

        // move application on click drag
        private void mouse_Down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouse_Move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePos;
            }
        }

        // open form2 when user clicks "About" button
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
