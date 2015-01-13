using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveResponse.Model
{
    public class QueryResponse
    {
        public ResponseType Type { get; set; }

        public ResponseResult Result { get; set; }

        public ICollection<Questions> PossibleQuestions { get; set; }
    }

}
