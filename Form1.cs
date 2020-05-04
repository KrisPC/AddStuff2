using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Kristopher Clancy, owner of this Project and Student of CSC370
namespace AddStuff2
{
    public partial class AddStuff2 : Form
    {
        //We have to declare variables so that we can "do math" with it later
        double box1;
        double total;
        int count;
        double input;
        double counter;
        double average;
        double maxWeight;
        double countdown;
        
        
        //We have to intiliaze the form here, otherwise it will not run!
        //We also want the add textbox to be automatically focused
        public AddStuff2()
        {
            InitializeComponent();
            //This puts the mouse pointer automatically in the entry textbox to save time for the user
            this.ActiveControl = textBox1;
        }
    
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
            //We also have a counter so that if the user wants to try and undo later, they will have an option to do so
            //If and else statements to check for any sort of errors
            try
            {
                //In order to use the numbers the user enters, we must first convert them to doubles so that we can do math with them
                counter = input;
                box1 = Convert.ToDouble(this.textBox1.Text);
                input = Convert.ToDouble(this.textBox1.Text);
                maxWeight = Convert.ToDouble(this.textBox2.Text);

                //Setting a minimum amount for the user, and giving them a logical error message if they exceed that 
                if (input < .5)
                {
                    MessageBox.Show("Check for error (minimum and maximum weight, as well as negative numbers)", "ERROR");
                    count = count;
                    total = total;
                }
                //Setting a maximum amount for the user, and giving them a logical error message if they exceed that 
                else if (input > 10)
                {
                    MessageBox.Show("Check for error (minimum and maximum weight, as well as negative numbers)", "ERROR");
                    count = count;
                    total = total;
                }

                //We want math that will actually work if the user does not enter any invalid input, which is what is here
                else
                {
                    //Setting the control back into the input box after the user has pressed enter or pushed the enter button
                    this.ActiveControl = textBox1;
                    count += 1;
                    total += box1;
                    average = total / count;
                    countdown = maxWeight - total;
                    string countdownString = "Amount until bag is full: " + countdown.ToString();
                    //this.textBox2.Text = "".ToString();
                    this.textBox1.Text = " ".ToString();
                    this.label8.Text = box1.ToString() +  " lbs";
                    this.label5.Text = total.ToString() + " lbs";
                    this.label2.Text = count.ToString();
                    this.label14.Text = average.ToString() + " lbs";
                    MessageBox.Show(countdownString, "Amount to Go");

                    //This error message traps for when the user exceeds the bag weight limit, essentially getting rid of the entered amount off the total and count
                    if(total > maxWeight)
                    {
                        MessageBox.Show("Exceeded maximum bag limit, please save/clear and try again.", "ERROR");
                        count -= 1;
                        total -= box1;
                        this.label2.Text = count.ToString();
                        this.label5.Text = total.ToString() + " " + "lbs";
                    }


                }
            }


            //If for some reason the user decides to input something other than a number, they get
            //this wonderful error message to inform them how silly they are :)
            catch
            {
                MessageBox.Show("CHECK INPUT");
            }
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //We have to "dump" out the running total so that we can start with a fresh total!
            this.label5.Text = " ".ToString();
            this.textBox1.Text = " ".ToString();
            total = 0;
            count = 0;
            this.label8.Text = 0.ToString();
            this.label2.Text = 0.ToString();
            this.label14.Text = "";
            this.textBox2.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //We do not want a help section on the base app, rather have it be a seperate button for someone to click on to see what the app is designed for
        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
            
        {
            //Creating a file for the menu section when the user clicks on about so that they can learn some more about the app
            string path3 = Environment.CurrentDirectory + "/" + "Help.txt";
            if (!File.Exists(path3))
            {
                File.CreateText(path3);

            }
            Process.Start("notepad.exe", path3); ;
           
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //So, we want to check if our input is greater than 0 so that we can see if it makes sense to have an undo go through
            if(input > 0)
            {
                total = total - input;
                input = 0;
                count -= 1;
                this.label8.Text = counter.ToString() + " " + "lbs";
                this.label2.Text = count.ToString();
                this.label5.Text = total.ToString() + " " + "lbs";

            }

            //If it is 0 (or less) we will display a message to show that there is no input to undo
            else
            {
                MessageBox.Show("CAN'T UNDO", "ERROR");
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //First we want to save the running total and shim amount, so that we can have the user see where they are at
            //Then, we want to clear everything out, so that they can start fresh again.
            //We need to also create variables that will display all the information the user has been adding together.
             string path = Environment.CurrentDirectory + "/" + "File.txt";

            //Create a list of strings that adds all of our stuff that we've collected together.
            List<string> lines = File.ReadAllLines(path).ToList();
            string message2 = ("Equation saved, check File.txt for save information.");
            MessageBox.Show(message2, "Total Box");
            string messageDate = (DateTime.Now.ToString("F"));
            string totalNum = "Total number of shims was: " + label2.Text;
            string totalVal = "Total weight of shim bag was: " + label5.Text;
            string aveShim = "Average shim weight was: " + label14.Text;
            string exitMsg = "END OF THIS EQUATION";
           
            //We only want one statement for if the file doesn't already exist in the directory
            if(!File.Exists(path))
            {
               File.CreateText(path);
               
            }

            //We want whatever text that we collected from 'saving' our data in the app
            lines.Add("________");
            lines.Add(totalNum);
            lines.Add(totalVal);
            lines.Add("________");
            lines.Add(aveShim);
            lines.Add("Max shim weight: 10");
            lines.Add("Minimum shim weight: .5");
            lines.Add("________");
            lines.Add(messageDate);
            lines.Add(exitMsg);
            lines.Add(" ");
            lines.Add(" ");
            lines.Add(" ");

            File.WriteAllLines(path, lines);
            Console.ReadLine();

            Process.Start("notepad.exe", path);

            //When we press save and print, we want everything to start fresh again
            this.label5.Text = " ".ToString();
            this.textBox1.Text = " ".ToString();
            total = 0;
            count = 0;
            this.label8.Text = 0.ToString();
            this.label2.Text = 0.ToString();
            this.textBox2.Text = "";
            this.label14.Text = "";
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creating a creative quit button that prompts the user if they actually want to quit, which helps if the user accidentally hits the button...
            string message = "Would you like to exit the application?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if(result == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
            else
            {
                
            }
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creating a file for the about section when the user clicks on about so that they can learn some more about the app
            string path2 = Environment.CurrentDirectory + "/" + "About.txt";
            if (!File.Exists(path2))
            {
                File.CreateText(path2);

            }
            Process.Start("notepad.exe", path2);
        }
    }
}
