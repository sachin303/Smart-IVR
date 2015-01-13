using InteractiveResponse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveResponse.Service
{
    public static class QuestionsCollection
    {
        public static ICollection<Questions> GetQuestions()
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
                                        IsDataSufficientToAnwser=true,
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
            q.answer =  new Answers { AnswerText = "Your balance for your account is {balance}" };
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
                                        IsDataSufficientToAnwser=true,
                                        ConfirmationQuestion = new Questions()
                                        {
                                            QuestionText = "Does your account number is ",
                                            IsYesNo = true
                                        }
                                    }
                                };
            q2.QuestionText = "I want to know my RD account balance.";
            q2.answer = new Answers { AnswerText = "Your recurring account balance is {balance}" };
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


            Questions q3 = new Questions();
            q3.Id = 3;

            q3.ChildQuestions = new List<Questions>()
                                {
                                    new Questions()
                                    {
                                        QuestionText = "What is your Account Number",
                                        IsMandatory = true,
                                        IsConfirmationRequired = true,
                                        IsDataSufficientToAnwser=true,
                                        ConfirmationQuestion = new Questions()
                                        {
                                            QuestionText = "Does your account number is ",
                                            IsYesNo = true
                                        }
                                    }
                                };
            q3.QuestionText = "I want to know my last transaction.";
            q3.answer = new Answers { AnswerText = "Your last transaction amount is {balance}" };
            q3.IsConfirmationRequired = true;
            q3.Keywords = new List<Keyword>
            {
                new Keyword()
                {
                    Id=1,
                    KeyText="Transaction"
                },
                new Keyword()
                {
                    Id=2,
                    KeyText="Account"
                }
            };
            q3.ConfirmationQuestion = new Questions()
            {
                QuestionText = "Do you want to know your Last transaction?",
                IsYesNo = false
            };


            var list = new List<Questions>();
            list.Add(q);
            list.Add(q2);
            list.Add(q3);

            return list;
        }
    }
}

