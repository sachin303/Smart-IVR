using InteractiveResponse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveResponse.Service
{
    public class SearchEngine
    {
        private static ICollection<Questions> questionsCache = null; 

        public SearchEngine()
        {
            if (questionsCache == null)
                questionsCache = QuestionsCollection.GetQuestions();
        }

        public ICollection<Questions> Search(IEnumerable<string> searchText)
        {
            List<Questions> ques = new List<Questions>();

            foreach (var word in (searchText))
            {
                ques = ques.Union(questionsCache.Where(c => c.QuestionText.ToLower().Contains(word.ToLower())).ToList()).ToList();
            }

            return ques;
        }

    }

}
