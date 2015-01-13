using InteractiveResponse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveResponse.Service
{
    public class ResponseService
    {
        private QueryAnalyzer _queryAnalyzer;

        public ResponseService(QueryAnalyzer queryAnalyzer)
        {
            _queryAnalyzer = queryAnalyzer;
        }

        public QueryResponse Search(Query query) {

            var response = _queryAnalyzer.Analyze(query);
            return response;
        }

        //public QueryResponse RespondTo(Questions query, string resultText) {

        //    return new QueryResponse();

        //}

    }
}
