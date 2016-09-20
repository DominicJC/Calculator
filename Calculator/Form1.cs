/**
Simple calculator application. 
Contains 2 classes. The main form class and a static utility class to carry out the calculations.
Numbers are input to the main display label. A second label displays a running total of the sum.
When the equals button is pressed, the result is displayed in the main label.
**/

using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private static string workingString = ""; //input string. 
        private static decimal result = 0; //decimal to hold the result of calculations.
        private static bool resulted = false; //bool handle triggered when sum is calculated.
        private static bool decimalPointed = false; //bool handle prevents multiple decimal points.
        private static bool newNumber = true; //bool handle prevents multiple zeros at the start of a number.

        public Calculator()
        {
            InitializeComponent();
        }

        private void Display()
        {
            lblDisplay1.Text = workingString;
        }

        //Checks for operators in the string and, if so, calculates the sum and displays it in the
        //second display label.
        private void ButtonPress()
        {
            if (Calculate.CheckContainsOperators(workingString))
            {
                result = Calculate.calculate(workingString);
                lblDisplay3.Text = result.ToString();
            }
            resulted = false;
            newNumber = false;
            Display();
        }


        //If the equals button has been pressed the result is cleared and handles reset.
        //If not, the last digit or operator is deleted from the input. Checks are done to ensure
        //that multiple operators, decimal points etc can't be entered afterwards.
        //If the input is completely deleted then everything is cleared. 
        private void Delete()
        {
            if (resulted == true)
            {
                lblDisplay1.Text = "";
                lblDisplay3.Text = "";
                workingString = "";
                result = 0;
                decimalPointed = false;
                newNumber = true;
            }
            else
            {
                if (workingString.Length > 0)
                {
                    workingString = workingString.Remove(workingString.Length - 1);

                    if (workingString.Length > 0 && Calculate.CheckContainsOperators(workingString)
                        && !Calculate.CheckForDoubleOperator(workingString))
                    {
                        result = Calculate.calculate(workingString);
                        lblDisplay3.Text = result.ToString();
                    }

                    if (workingString.Contains("."))
                    {
                        if (Calculate.CheckContainsOperators(workingString))
                        {
                            string[] splitString;                          
                            splitString = workingString.Split('+', '-', '*', '/');

                            if (splitString[splitString.Length - 1].Contains("."))
                            {
                                decimalPointed = true;
                            }
                            else decimalPointed = false;
                        }
                        else decimalPointed = true;
                    }
                    else decimalPointed = false;

                    if(Calculate.CheckContainsOperators(workingString))
                    {
                        string[] splitString;
                        splitString = workingString.Split('+', '-', '*', '/');

                        if(splitString[splitString.Length - 1].Length == 0)
                        {
                            newNumber = true;
                        }
                    }

                    lblDisplay1.Text = "";
                    Display();
                }
                else
                {
                    lblDisplay1.Text = "";
                    lblDisplay3.Text = "";
                    workingString = "";
                    result = 0;
                    decimalPointed = false;
                    newNumber = true;
                }
            }
            
        }

        //Operator methods. 
        //Passes the input string to the calculate method in the utility class so running calc can be carried out.
        //Displays running total in the second display box.
        private void Add()
        {
            if (workingString.Length != 0 && !Calculate.CheckForDoubleOperator(workingString))
            {
                result = Calculate.calculate(workingString);
                workingString += "+";
                lblDisplay3.Text = result.ToString();
                decimalPointed = false;
                resulted = false;
                newNumber = true;
                Display();
            }
        }

        private void Subtract()
        {
            if (workingString.Length != 0 && !Calculate.CheckForDoubleOperator(workingString))
            {
                result = Calculate.calculate(workingString);
                workingString += "-";
                lblDisplay3.Text = result.ToString();
                decimalPointed = false;
                resulted = false;
                newNumber = true;
                Display();
            }
        }

        private void Multiply()
        {
            if (workingString.Length != 0 && !Calculate.CheckForDoubleOperator(workingString))
            {
                result = Calculate.calculate(workingString);
                workingString += "*";
                lblDisplay3.Text = result.ToString();
                decimalPointed = false;
                resulted = false;
                newNumber = true;
                Display();
            }
        }

        private void Divide()
        {
            if (workingString.Length != 0 && !Calculate.CheckForDoubleOperator(workingString))
            {
                result = Calculate.calculate(workingString);
                workingString += "/";
                lblDisplay3.Text = result.ToString();
                decimalPointed = false;
                resulted = false;
                newNumber = true;
                Display();
            }
        }

        private void DecimalPoint()
        {
            if(!decimalPointed)
            {
                workingString += ".";
                decimalPointed = true;
                newNumber = false;
                Display();
            }
        }

        //Triggered by the equals button. 
        //Passes the input string to the calculate method in the utility class.
        //Displays the result in the main display label and clears the second one. 
        private void SumResult()
        {
            if (workingString.Length != 0 && !Calculate.CheckForDoubleOperator(workingString))
            {
                result = Calculate.calculate(workingString);
                lblDisplay1.Text = result.ToString();
                lblDisplay3.Text = "";
                workingString = result.ToString();
                resulted = true;
                if (!result.ToString().Contains("."))
                {
                    decimalPointed = false;
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if(!newNumber)
            {
                workingString += "0";
                ButtonPress();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            workingString += "1";
            ButtonPress();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            workingString += "2";
            ButtonPress();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            workingString += "3";
            ButtonPress();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            workingString += "4";
            ButtonPress();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            workingString += "5";
            ButtonPress();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            workingString += "6";
            ButtonPress();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            workingString += "7";
            ButtonPress();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            workingString += "8";
            ButtonPress();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            workingString += "9";
            ButtonPress();
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            DecimalPoint();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Add();            
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            Subtract();
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            Multiply();
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            Divide();
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            SumResult();
        }

        private void lblOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
