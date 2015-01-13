using InteractiveResponse.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveResponse.Service
{
    public class QueryAnalyzer
    {
        private SearchEngine _searchEngine;

        private Sanitizer _textSanitizer;

        public QueryAnalyzer(SearchEngine searchEngine, Sanitizer textSanitizer)
        {
            _searchEngine = searchEngine;
            _textSanitizer = textSanitizer;
        }

        public QueryResponse Analyze(Query query)
        {
            ICollection<Questions> questions = new Collection<Questions>();

            var sanitizedWords = _textSanitizer.SanitizeString(query.Text);

            if (!query.InContext)
            {
                questions = _searchEngine.Search(sanitizedWords);
            }
            else
            {
                if (query.CurrentQuery.ChildQuestions != null && !query.CurrentQuery.ChildQuestions.Count().Equals(0)) {

                    //query.CurrentQuery.ChildQuestions.Where(q=> q.

                    //foreach (var question in query.CurrentQuery.ChildQuestions.Where) { 
                    
                    //}

                }
            }

            return new QueryResponse { PossibleQuestions = questions, Type = ResponseType.Question };
        }
    }
}
