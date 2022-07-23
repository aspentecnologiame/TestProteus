using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcosCosta.Domain.Options
{
    public class AppSettings
    {
        public string FeedRDFUrl { get; set; }
        public string XMLFileName { get; set; }
        public string BearerToken { get; set; }
        public Authentication Authentication { get; set; }
    }
}
