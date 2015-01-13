using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InteractiveResponse;
using InteractiveResponse.Model;

namespace IvrUI
{
    public partial class Form1 : Form
    {
        Questions question = new Questions();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string response = textBox1.Text;

            question = question.GetQuestion();

            Questions q = question;
            

            while (true)
            {
                
                if (q.IsConfirmationRequired)
                {
                    q = q.ChildQuestions.FirstOrDefault();
                    var result = MessageBox.Show(q.QuestionText, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        q = q.YesQuestion;                        
                    }
                    else
                    {
                        q = q.NoQuestion;
                    }

                }
                else if (q.IsYesNo)
                {
                    var result = MessageBox.Show(q.QuestionText, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        q = q.YesQuestion;
                    }
                    else
                    {
                        q = q.NoQuestion;
                    }
                }
                else
                {
                    var result = MessageBox.Show(q.QuestionText, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
            }
            
        }


    }
}
