using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        bool operandPerfom = false;
        string oper = "";
        double result = 0.0;
        private double memory;
        private bool memFlag;

        public Form1()
        {
            InitializeComponent();
            B_MC.Enabled = false;
            B_MR.Enabled = false;
        }
        private void NumEvent(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || operandPerfom || memFlag == true)
                textBox1.Clear();
            Button btn = (Button)sender;
           textBox1.Text += btn.Text;
            operandPerfom = false;
            memFlag = false;
        }

        private void OperandEvent(object sender, EventArgs e)
        {
            operandPerfom = true;
            Button btn = (Button)sender;
            string newOp = btn.Text;
            label1.Text = label1.Text + " " + textBox1.Text + " " + newOp;

            switch (oper)
            {
                case "+":textBox1.Text = (result + Double.Parse(textBox1.Text)).ToString();break ;
                case "-": textBox1.Text = (result - Double.Parse(textBox1.Text)).ToString(); break;
                case "*": textBox1.Text = (result * Double.Parse(textBox1.Text)).ToString(); break;
                case "/": textBox1.Text = (result / Double.Parse(textBox1.Text)).ToString(); break;
                default:break;
            }
            result = Double.Parse(textBox1.Text);
            oper = newOp;

        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            label1.Text = "";
            result = 0;
            oper = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            operandPerfom = true;

            switch (oper)
            {
                case "+": textBox1.Text = (result + Double.Parse(textBox1.Text)).ToString(); break;
                case "-": textBox1.Text = (result - Double.Parse(textBox1.Text)).ToString(); break;
                case "*": textBox1.Text = (result * Double.Parse(textBox1.Text)).ToString(); break;
                case "/": textBox1.Text = (result / Double.Parse(textBox1.Text)).ToString(); break;
                default: break;
            }
            result = Double.Parse(textBox1.Text);
            textBox1.Text = result.ToString();
            result = 0;
            oper = "";


        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (!operandPerfom && !textBox1.Text.Contains("."))
            {
                textBox1.Text += ".";
            }
            else if (operandPerfom)
            {
                textBox1.Text = "0";
            }

            if (!textBox1.Text.Contains("."))
            {
                textBox1.Text += ".";
            }

            operandPerfom = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            double temp = Convert.ToDouble(textBox1.Text);
            label1.Text = $"x^2({temp})";
            temp = Math.Pow(temp, 2);
            textBox1.Text = Convert.ToString(temp);
        }

      

        private void button20_Click(object sender, EventArgs e)
        {
            double temp = Convert.ToDouble(textBox1.Text);
            label1.Text = $"√({temp})";
            temp = Math.Sqrt(temp);
            textBox1.Text = Convert.ToString(temp);
        }

        private void button21_Click(object sender, EventArgs e)
        {         
             double temp = Convert.ToDouble(textBox1.Text);
            label1.Text = $"Log({temp})";
            temp = Math.Log(temp);      
            textBox1.Text = Convert.ToString(temp);
        }

        private void B_MC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            memory = 0;
            B_MR.Enabled = false;
            B_MC.Enabled = false;
        }

        private void B_MS_Click(object sender, EventArgs e)
        {
            memory = Double.Parse(textBox1.Text);
            B_MC.Enabled = true;
            B_MR.Enabled = true;
            memFlag = true;
        }

        private void B_MR_Click(object sender, EventArgs e)
        {
            textBox1.Text = memory.ToString();
            memFlag = true;
        }

        private void B_M1_Click(object sender, EventArgs e)
        {
            memory += Double.Parse(textBox1.Text);
        }

        private void B_M__Click(object sender, EventArgs e)
        {
            memory -= Double.Parse(textBox1.Text);
        }
    }
}
