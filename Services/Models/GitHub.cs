using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class GitHub
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Bio { get; set; }
        public List<Repository> Repositories { get; set; }
    }

    public class Repository
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Language { get; set; }
        public string LastUpdate { get; set; }
    }
}
