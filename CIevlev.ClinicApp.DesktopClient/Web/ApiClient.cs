﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;

namespace CIevlev.ClinicApp.DesktopClient.Web
{
    public static class ApiClient
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static void Connect()
        {
            HttpClient.BaseAddress = new Uri(WebConfigurationManager.AppSettings["WebApiUrl"]);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static T GetRequest<T>(string requestUrl)
        {
            var response = HttpClient.GetAsync(requestUrl);
            if (response.Result.IsSuccessStatusCode)
            {
                return response.Result.Content.ReadAsAsync<T>().Result;
            }

            throw new Exception("Оу, ошибочка при получении!");
        }
        
        public static T PostRequest<T, U>(string requestUrl, U model)
        {
            var response = HttpClient.PostAsJsonAsync(requestUrl, model);
            if (response.Result.IsSuccessStatusCode)
            {
                return response.Result.Content.ReadAsAsync<T>().Result;
            }

            throw new Exception("Оу, ошибочка во время post запроса :)");
        }

        public static T DelRequest<T>(string requestUrl)
        {
            var response = HttpClient.DeleteAsync(requestUrl);
            if (response.Result.IsSuccessStatusCode)
            {
                return response.Result.Content.ReadAsAsync<T>().Result;
            }
            
            throw new Exception("Оу, ошибочка при удалении!");
        }

        public static T PutRequest<T, U>(string requestUrl, U model)
        {
            var response = HttpClient.PutAsJsonAsync(requestUrl, model);
            if (response.Result.IsSuccessStatusCode)
            {
                return response.Result.Content.ReadAsAsync<T>().Result;
            }
            
            throw new Exception("Оу, ошибочка во время put запроса :)");
        }
    }
}