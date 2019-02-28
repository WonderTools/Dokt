using System;
using System.Collections.Generic;
using System.Text;

namespace FakeHttpClient
{
    public static class RuleUriExtensions
    {
        public static Rule WhenUri(this Rule rule, string uri)
        {
            rule.AddEntryCondition(x => x.RequestUri.AbsoluteUri == uri);
            return rule;
        }

        public static Rule WhenUriStartsWith(this Rule rule, string segment)
        {
            rule.AddEntryCondition(x => x.RequestUri.OriginalString.StartsWith(segment));
            return rule;
        }

        public static Rule WhenUriContains(this Rule rule, string segment)
        {
            rule.AddEntryCondition(x => x.RequestUri.AbsoluteUri.Contains(segment));
            return rule;
        }

        public static Rule WhenUriPort(this Rule rule, int port)
        {
            rule.AddEntryCondition(x => x.RequestUri.Port.Equals(port));
            return rule;
        }
    }
}
