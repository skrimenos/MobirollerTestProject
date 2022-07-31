using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MobirollerTestProject.Api.WebServices;
using MobirollerTestProject.DataAccess.ApiHelperModels;
using MobirollerTestProject.DataAccess.Models;
using Repositories.Repository;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MobirollerTestProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : Controller
    {
        private readonly TurkishRepository _turkishRepository;
        private readonly ItalianRepository _italianRepository;
        private readonly IMapper _mapper;
        public ValuesController(TurkishRepository turkishRepository, ItalianRepository italianRepository,IMapper mapper)
        {
            _turkishRepository = turkishRepository;
            _italianRepository = italianRepository;
            _mapper = mapper;
        }

        [HttpGet("SaveTurkish")]
        public async Task<IActionResult> SaveTurkish()
        {
            try
            {
                var url = "https://s3.us-west-2.amazonaws.com/secure.notion-static.com/c86e0795-cfbb-42b9-8164-739f72ebf585/3455dde5.json?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&X-Amz-Credential=AKIAT73L2G45EIPT3X45%2F20220731%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20220731T022507Z&X-Amz-Expires=86400&X-Amz-Signature=474c41ad40126b8c8918506a0cd1284eb0645e0a3ebb579bda47ed6b1fa8201c&X-Amz-SignedHeaders=host&response-content-disposition=filename%20%3D%223455dde5.json%22&x-id=GetObject";


                var responseString = RestService.GetValuesAsync(url);

                var turkishList = new List<TurkishHelperModel>();
                if (!String.IsNullOrEmpty(await responseString))
                {
                    turkishList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TurkishHelperModel>>(await responseString);

                    List<Turkish> model = _mapper.Map<List<Turkish>>(turkishList);

                    _turkishRepository.AddRange(model);
                    return Ok(new { status = "OK", msg = "Saved!!!" });
                }

                return Ok(new { status = "error", msg = "ERROR!!!" });
            }
            catch (Exception)
            {

                return Ok(new { status = "error", msg = "ERROR!!!" });
            }
        }

        [HttpGet("SaveItalian")]
        public async Task<IActionResult> SaveItalian()
        {
            try
            {
                var url = "https://s3.us-west-2.amazonaws.com/secure.notion-static.com/8febcaa6-c2f8-4fab-b05b-141bafe4d344/1d6a2360.json?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Content-Sha256=UNSIGNED-PAYLOAD&X-Amz-Credential=AKIAT73L2G45EIPT3X45%2F20220731%2Fus-west-2%2Fs3%2Faws4_request&X-Amz-Date=20220731T033756Z&X-Amz-Expires=86400&X-Amz-Signature=dfae34cbf12d47d9b0664cb95ccdf53f5f11944dd27b0bf37615a9bb0fd3a037&X-Amz-SignedHeaders=host&response-content-disposition=filename%20%3D%221d6a2360.json%22&x-id=GetObject";

                var responseString = RestService.GetValuesAsync(url);
                var italianList = new List<ItalianHelperModel>();
                if (!String.IsNullOrEmpty(await responseString))
                {
                    italianList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItalianHelperModel>>(await responseString);

                    List<Italian> model = _mapper.Map<List<Italian>>(italianList);

                    _italianRepository.AddRange(model);
                    return Ok(new { status = "OK", msg = "Saved!!!" });
                }

                return Ok(new { status = "error", msg = "ERROR!!!" });
            }
            catch (Exception)
            {
                return Ok(new { status = "error", msg = "ERROR!!!" });
            }
        }
    }
}
