using newsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace newsApp.Controllers
{
    public class RssController : Controller
    {
        private readonly RssReaderService _readerService;

        public RssController(RssReaderService readerService)
        {
            _readerService = readerService;
        }

        [HttpGet]
        [Route("api/tuoi-tre-rss")]
        public async Task<List<RSS>> GetTuoiTreRss()
        {
            return await _readerService.GetTuoiTreNews();
        }
    }
}