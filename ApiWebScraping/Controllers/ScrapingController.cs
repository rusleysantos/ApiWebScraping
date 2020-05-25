using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Models;

namespace ApiWebScraping.Controllers
{
    [Route("api")]
    public class ScrapingController : Controller
    {
        private IScrapingServices Services { get; }
        public ScrapingController(IScrapingServices services)
        {
            Services = services;
        }

        [HttpGet("[action]")]
        public ActionResult GetContentPage([FromBody] ScrapingParameters parameters)
        {

            if (ModelState.IsValid)
            {
                return Ok(Services.GetContentPage(parameters));
            }
            else
            {
                return BadRequest("Model not valid, use PostMan to send data!");
            }

        }

        //TODO: Retornar todos os valores do perfil
        [HttpGet("[action]")]
        public ActionResult GetContentGitHub([FromBody] ScrapingParameters parameters)
        {
            if (ModelState.IsValid)
            {
                return Ok(Services.GetContentGitHub(parameters));
            }
            else
            {
                return BadRequest("Model not valid, use PostMan to send data!");
            }
        }
    }
}
