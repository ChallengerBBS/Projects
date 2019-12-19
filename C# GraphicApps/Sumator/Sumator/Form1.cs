using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sumator
{
    public partial class FormSumator : Form
    {
        public FormSumator()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                var num1 = decimal.Parse(textBox1.Text);
                var num2 = decimal.Parse(textBox2.Text);
                var sum = num1 + num2;
                this.textBoxSum.Text = "" + sum;

            }
            catch (Exception)
            {
                this.textBoxSum.Text = "Грешка";
            }
        }
    }
}
