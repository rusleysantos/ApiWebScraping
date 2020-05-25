using HtmlAgilityPack;
using Services.Contracts;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;


namespace Services.Services
{
    public class ScrapingServices : IScrapingServices
    {
        public GitHub GetContentGitHub(ScrapingParameters parameters)
        {
            GitHub git = new GitHub();
            List<Repository> repositories = new List<Repository>();
            Queue<string> mylist = new Queue<string>();

            using (WebClient wc = new WebClient())
            {
                string page = wc.DownloadString(parameters.Url);
                var htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(page);


                git.Name = htmlDocument
                            .DocumentNode
                            .SelectSingleNode("//span[@itemprop='name']")
                            .InnerText;

                git.UserName = htmlDocument
                                .DocumentNode
                                .SelectSingleNode("//span[@itemprop='additionalName']")
                                .InnerText;

                git.Bio = htmlDocument
                                .DocumentNode
                                .SelectSingleNode("//div[@class='p-note user-profile-bio mb-2 js-user-profile-bio']")
                                .InnerText;


                   HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//a[@data-filterable-for='your-repos-filter']");
                foreach (HtmlNode htmlNode in (IEnumerable<HtmlNode>)nodes)
                {
                    if (!mylist.Contains(htmlNode.InnerText))
                    {
                        mylist.Enqueue(htmlNode.InnerText);

                    }
                }


                foreach (HtmlNode node in htmlDocument.DocumentNode.ge)
                {
                    if (node.Attributes.Count > 0)
                    {
                        Repository repository = new Repository();

                        //repository.Title = htmlDocument
                        //        .DocumentNode
                        //        .SelectSingleNode("//a[@itemprop='name codeRepository']")
                        //        .InnerText
                        //        .Trim()
                        //        .Replace("\\n","");

                       

                        repository.Title = node.Descendants().First(x => x.Attributes["class"].Value.Equals("name codeRepository")).InnerText;

                        repositories.Add(repository);
                    }
                }

                git.Repositories = repositories;

            }
            return git;
        }

        public string GetContentPage(ScrapingParameters parameters)
        {
            using (WebClient wc = new WebClient())
            {
                string page = wc.DownloadString(parameters.Url);

                return page;
            }
        }
    }
}
