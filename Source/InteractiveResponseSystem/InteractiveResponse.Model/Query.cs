using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveResponse.Model
{
    public class Query
    {
        public bool InContext
        {
            get
            {
                return (Context == null ? false : true);
            }
        }

        public QueryType Type { get; set; }

        public QueryContext Context { get; set; }

        public Questions CurrentQuery { get; set; }

        public string Text { get; set; }
    }
}
