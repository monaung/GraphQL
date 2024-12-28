using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MyGraphQLNet.GraphQL
{
    public class Resolvers
    {
        public string GetFormattedDate([Parent]Book e)
        {
            return e.PublishDate.ToShortDateString();
        }
    }
}