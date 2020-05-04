using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Kristopher Clancy, owner of this Project and Student of CSC370

    //Named it add stuff 2, because well... it add stuffs, and this is the second time we made it!
namespace AddStuff2
{
    public partial class AddStuff2 : Form
    {
        //We have to declare variables so that we can "do math" with it later
        double box1;
        double total;
        
        
        //We have to intiliaze the form here, otherwise it will not run!
        public AddStuff2()
        {
            InitializeComponent();
        }
        //"unused" label and text stuff, meaning that we did not hard code anything in here to do stuff with
        private void header_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //When we click the button, we are gonna be setting the number we just entered
            //Into the previous number entered box, and that previous numbered is then
            //Added to a running total for the user to keep track with
            try
            {
                box1 = Convert.ToDouble(this.textBox1.Text);
                this.label8.Text = box1.ToString();
                total += box1;
                this.label5.Text = total.ToString();

            }

            //If for some reason the user decides to input something other than a number, they get
            //this wonderful error message to inform them how silly they are :)
            catch
            {
                MessageBox.Show("ERROR, INCORRECT INPUT.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //We have to "dump" out the running total so that we can start with a fresh total!
            this.label5.Text = 0.ToString();
            total = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
