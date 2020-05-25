using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IScrapingServices
    {
        public string GetContentPage(ScrapingParameters parameters);
        public GitHub GetContentGitHub(ScrapingParameters parameters);
    }
}
