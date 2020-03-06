using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace DidYouMeanBLL.Controllers
{
    [ApiController]
    public class DidYouMeanController : ControllerBase
    {
        int instanceId = 2;

        private readonly ILogger<DidYouMeanController> _logger;

        public DidYouMeanController(ILogger<DidYouMeanController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("getWords")]
        public Entity Get(string keyWord, int distance, [FromBody]Entity passedEntity)
        {
            List<string> output = new List<string>();

            int? pos = Array.IndexOf(passedEntity.Words, keyWord);
            if (pos != null && pos >= 0)
            {
                int offSet = (int)pos;

                for (int i = 0; i <= distance; i++)
                {
                    output.Add(passedEntity.Words[i + offSet]);
                }
            }

            Entity outputEntity = new Entity
            {
                InstanceId = instanceId,
                Time = DateTime.Now,
                Words = output.ToArray()
            };

            return outputEntity;
        }
    }
}
