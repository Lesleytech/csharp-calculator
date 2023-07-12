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
        bool start = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void insertValue(char val)
        {
            if ((!start || !char.IsDigit(val)) && (expInput.Text != "0" || !char.IsDigit(val)))
            {
                expInput.Text += val.ToString();
            }
            else
                expInput.Text = val.ToString();

            start = false;
        }

        private void removeValue()
        {
            expInput.Text = expInput.Text.Substring(0, expInput.Text.Length - 1);

            if (expInput.Text.Length == 0)
                expInput.Text = "0";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            insertValue('0');
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            insertValue('1');
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            insertValue('2');
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            insertValue('3');
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            insertValue('4');
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            insertValue('5');
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            insertValue('6');
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            insertValue('7');
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            insertValue('8');
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            insertValue('9');
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            expInput.Text = "0";
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            int decIndex = expInput.Text.LastIndexOf(".");
            bool canAddDec = true;
            char val;

            if (decIndex != -1)
            {
                for(int i = expInput.Text.Length - 1; i >= 0; i--)
                {
                    val = expInput.Text[i];
                    if (val == '+' || val == '-' || val == '*' || val == '/')
                        break;
                    else if(val == '.')
                    {
                        canAddDec = false;
                        break;
                    }
                }
            }

            if (canAddDec)
                insertValue('.');
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (expInput.Text.Length > 0)
                removeValue();           
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            while (isLastValueOperator())
                removeValue();
            insertValue('÷');
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            while (isLastValueOperator())
                removeValue();
            insertValue('×');
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            while (isLastValueOperator())
                removeValue();
            insertValue('−');
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            while (isLastValueOperator())
                removeValue();
            insertValue('+');
        }

        private bool isLastValueOperator()
        {
            if (expInput.Text.Length == 0 || Char.IsDigit(expInput.Text.Last()))
                return false;

            return true;
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            string parsedExp;
            string result;

            if (expInput.Text.Length == 0)
                return;

            if (isLastValueOperator())
                removeValue();

            parsedExp = expInput.Text.Replace("÷", "/").Replace("×", "*").Replace("−", "-");

            DataTable dt = new DataTable();

            try
            {
                result = dt.Compute(parsedExp, "").ToString();
                expInput.Text = result;
            }
            catch(Exception)
            {
                MessageBox.Show("Invalid expression", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                start = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.D0:
                case Keys.NumPad0:
                    btn0_Click(null, null);
                    return true;
                case Keys.D1:
                case Keys.NumPad1:
                    btn1_Click(null, null);
                    return true;
                case Keys.D2:
                case Keys.NumPad2:
                    btn2_Click(null, null);
                    return true;
                case Keys.D3:
                case Keys.NumPad3:
                    btn3_Click(null, null);
                    return true;
                case Keys.D4:
                case Keys.NumPad4:
                    btn4_Click(null, null);
                    return true;
                case Keys.D5:
                case Keys.NumPad5:
                    btn5_Click(null, null);
                    return true;
                case Keys.D6:
                case Keys.NumPad6:
                    btn6_Click(null, null);
                    return true;
                case Keys.D7:
                case Keys.NumPad7:
                    btn7_Click(null, null);
                    return true;
                case Keys.D8:
                case Keys.NumPad8:
                    btn8_Click(null, null);
                    return true;
                case Keys.D9:
                case Keys.NumPad9:
                    btn9_Click(null, null);
                    return true;
                case Keys.Add:
                    btnAdd_Click(null, null);
                    return true;
                case Keys.Subtract:
                    btnSubtract_Click(null, null);
                    return true;
                case Keys.Divide:
                    btnDivide_Click(null, null);
                    return true;
                case Keys.Multiply:
                    btnMultiply_Click(null, null);
                    return true;
                case Keys.Decimal:
                    btnDecimal_Click(null, null);
                    return true;
                case Keys.Back:
                case Keys.Delete:
                    btnBack_Click(null, null);
                    return true;
                case Keys.Enter:
                    btnResult_Click(null, null);
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
