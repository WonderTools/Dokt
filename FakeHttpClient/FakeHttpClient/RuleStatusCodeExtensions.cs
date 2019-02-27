using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace FakeHttpClient
{
    public static class RuleStatusCodeExtensions
    {
        public static Rule UseStatusCode(this Rule rule, HttpStatusCode statusCode)
        {
            rule.AddModifier(x => { x.StatusCode = statusCode; });
            return rule;
        }
    }
}
