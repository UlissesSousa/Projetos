using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Maverick.TmdbAdapter.Clients
{
    internal class TmdbSearchPeopleGetResult
    {
        internal class ResultItem
        {
            public string name { get; set; }

        }

        public IEnumerable<ResultItem> Results { get; set; }
    }
}
