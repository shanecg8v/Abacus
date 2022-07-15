using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abacus
{
    public partial class Form1 : Form
    {
        private double _preNum = 0;
        private bool _isFirstClick = true;
        private bool _isOperator = false;
        private OperatorEnum _operatorEnum = OperatorEnum.none;

        public Form1()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (_operatorEnum == OperatorEnum.none) return;

            double curNum = double.Parse(textBox1.Text);
            _preNum = Calculate.Calc(curNum, _preNum, _operatorEnum);
            textBox1.Text = _preNum.ToString();
            _operatorEnum = OperatorEnum.none;
            _isOperator = true;
        }

        private void Operator_Click(object sender,EventArgs e)
        {
            Button clickedButton = (Button)sender;

            switch (clickedButton.Text)
            {
                case "+":
                    _operatorEnum = OperatorEnum.a;
                    break;
                case "-":
                    _operatorEnum = OperatorEnum.b;
                    break;
                case "*":
                    _operatorEnum = OperatorEnum.c;
                    break;
                case "/":
                    _operatorEnum = OperatorEnum.d;
                    break;
                default:
                    return;
            }
            _preNum = double.Parse(textBox1.Text);
            _isOperator = false;
            textBox1.Text = "0";
        }

        private void Number_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (_isFirstClick) _isFirstClick = false;
            if (_isOperator) textBox1.Text = "0";

            if (clickedButton.Text.Equals("0") 
                && textBox1.Text.Equals("0")) 
                return;

            if(textBox1.Text.Equals("0"))
                textBox1.Text = clickedButton.Text;
            else
                textBox1.Text += clickedButton.Text;
        }
        
        private void Clear_Click(object sender,EventArgs e)
        {
            _isFirstClick = true;
            _preNum = 0;
            _operatorEnum = OperatorEnum.none;
            textBox1.Text = "0";
        }

        private void Del_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 1) 
                textBox1.Text = "0";
            else
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
        }
    }
}
