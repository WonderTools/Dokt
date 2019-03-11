using System;
using System.Linq;

namespace WonderTools.FakeHttpClient
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

        public static Rule WhenUriScheme(this Rule rule, string scheme)
        {
            rule.AddEntryCondition(x => x.RequestUri.Scheme.Equals(scheme));
            return rule;
        }

        public static Rule WhenUriAuthority(this Rule rule, string authority)
        {
            rule.AddEntryCondition(x => x.RequestUri.Authority.Equals(authority));
            return rule;
        }

        public static Rule WhenUriWithQuery(this Rule rule, string query)
        {
            rule.AddEntryCondition(x => x.RequestUri.Query.Equals(query));
            return rule;
        }

        public static Rule WhenUriHasSegment(this Rule rule, string segment)
        {
            rule.AddEntryCondition(x => x.RequestUri.Segments.Contains(segment));
            return rule;
        }
    }
}
