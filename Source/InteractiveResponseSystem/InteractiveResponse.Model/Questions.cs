using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveResponse.Model
{
    public class Questions
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }
        
        public ICollection<Answers> Answers { get; set; }
        public Answers answer {get; set;}
        
        public ICollection<Questions> ChildQuestions { get; set; }
        public ICollection<Keyword> Keywords { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsYesNo { get; set; }

        public int Sequence { get; set; }
        
        public bool IsAnswered { get; set; }
        
        public bool IsSuccessfull { get; set; }
        
        public bool IsConfirmationRequired { get; set; }

        public bool IsConfirmed { get; set; }

        public bool IsDataSufficientToAnwser { get; set; }
        public Questions YesQuestion { get; set; }
        public Questions NoQuestion { get; set; }
        public Questions ParentQuestion { get; set; }
        public Questions ConfirmationQuestion{ get; set; }

        public string Result
        {
            get;
            set;
        }

        //public string SearchQuestions(string query)
        //{
        //    Questions q = this.GetQuestion();
        //    this.Execute(q);
        //    return null;
        //}

        public Questions Execute(Questions question, Questions MainContext)
        {

            if (question.IsConfirmationRequired)
            {
                return MainContext.ConfirmationQuestion;
            }

            return null;
        }

        //public void ConfirmFromUser(Questions q)
        //{
            
        //}

        public IEnumerable<Questions> GetQuestion()
        {
            Questions q = new Questions();
            q.Id = 1;

            q.ChildQuestions = new List<Questions>()
                                {
                                    new Questions()
                                    {
                                        QuestionText = "What is your Account Number",
                                        IsMandatory = true,
                                        IsConfirmationRequired = true,
                                        ConfirmationQuestion = new Questions()
                                        {
                                            QuestionText = "Does your account number is ",
                                            IsYesNo = true
                                        }},
                                     new Questions()
                                     {
                                        QuestionText = "What is your Account Type",
                                        IsMandatory = true,
                                        IsConfirmationRequired = true,
                                        ConfirmationQuestion = new Questions()
                                        {
                                            QuestionText = "Does your Account Type is ",
                                            IsYesNo = true
                                        }
                                     }
                                };
            q.QuestionText = "I want to know my account balance.";
            q.IsConfirmationRequired = true;
            q.Keywords = new List<Keyword>
            {
                new Keyword()
                {
                    Id=1,
                    KeyText="Account"
                }
            };
            q.ConfirmationQuestion = new Questions()
            {
                QuestionText = "Do you want to know your Account Balance?",
                IsYesNo = false
            };

            Questions q2 = new Questions();
            q2.Id = 2;

            q2.ChildQuestions = new List<Questions>()
                                {
                                    new Questions()
                                    {
                                        QuestionText = "What is your Account Number",
                                        IsMandatory = true,
                                        IsConfirmationRequired = true,
                                        ConfirmationQuestion = new Questions()
                                        {
                                            QuestionText = "Does your account number is ",
                                            IsYesNo = true
                                        }
                                    }
                                };
            q2.QuestionText = "I want to know my RD account balance.";
            q2.IsConfirmationRequired = true;
            q2.Keywords = new List<Keyword>
            {
                new Keyword()
                {
                    Id=1,
                    KeyText="RD"
                },
                new Keyword()
                {
                    Id=2,
                    KeyText="Account"
                }
            };
            q2.ConfirmationQuestion = new Questions()
            {
                QuestionText = "Do you want to know your RD account balance?",
                IsYesNo = false
            };


            var list = new List<Questions>();
            list.Add(q);
            list.Add(q2);

            return list; 
        }
    }

    public class Answers
    {
        public int Id { get; set; }
        
        public string AnswerText { get; set; }

        public bool IsSuccessfull { get; set; }
    }

    public class Keyword
    {
        public int Id { get; set; }
        public string KeyText { get; set; }
    }
}
