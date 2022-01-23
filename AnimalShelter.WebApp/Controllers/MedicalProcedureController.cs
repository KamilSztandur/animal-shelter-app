﻿using AnimalShelter.WebApp.Common;
using AnimalShelter.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AniimalShelter.WebApp.Controllers
{
    [Authorize]
    public class MedicalProcedureController : Controller
    {
        public IConfiguration Configuration;

        public MedicalProcedureController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult GetHostUrl()
        {
            var result = Configuration["RestApiUrl:HostUrl"];
            return Content(result);
        }

        private string CN()
        {
            string cn = ControllerContext.RouteData.Values["controller"].ToString();
            return cn;
        }

        public async Task<IActionResult> Index()
        {
            string _restpath = GetHostUrl().Content + CN();

            var tokenString = JWTGenerator.GenerateJSONWebToken();

            List<MedicalProcedureVM> medicalProceduresList = new List<MedicalProcedureVM>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);

                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    medicalProceduresList = JsonConvert.DeserializeObject<List<MedicalProcedureVM>>(apiResponse);
                }
            }

            return View(medicalProceduresList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicalProcedureVM t)
        {
            string _restpath = GetHostUrl().Content + CN();

            var tokenString = JWTGenerator.GenerateJSONWebToken();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);

                string jsonString = System.Text.Json.JsonSerializer.Serialize(t);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                await httpClient.PostAsync(_restpath, content);
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();

            var tokenString = JWTGenerator.GenerateJSONWebToken();

            MedicalProcedureVM t = new MedicalProcedureVM();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);

                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    t = JsonConvert.DeserializeObject<MedicalProcedureVM>(apiResponse);

                }
            }

            return View(t);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MedicalProcedureVM t)
        {
            string _restpath = GetHostUrl().Content + CN();

            var tokenString = JWTGenerator.GenerateJSONWebToken();

            Boolean result;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);

                    string jsonString = System.Text.Json.JsonSerializer.Serialize(t);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{t.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<Boolean>(apiResponse);

                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + CN();

            var tokenString = JWTGenerator.GenerateJSONWebToken();

            MedicalProcedureVM t = new MedicalProcedureVM();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);

                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    t = JsonConvert.DeserializeObject<MedicalProcedureVM>(apiResponse);

                }
            }

            return View(t);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MedicalProcedureVM t)
        {
            string _restpath = GetHostUrl().Content + CN();

            var tokenString = JWTGenerator.GenerateJSONWebToken();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);

                    var response = await httpClient.DeleteAsync($"{_restpath}/{t.Id}");
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
