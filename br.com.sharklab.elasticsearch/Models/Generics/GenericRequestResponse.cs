using br.com.sharklab.elasticsearch.Models.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace br.com.sharklab.elasticsearch.Models.Generics
{
    public class GenericRequestResponse
    {
        public Dictionary<string, object> Request { get; private set; }
        public Dictionary<string, object> Response { get; private set; }
        public string RequestMethod { get; set; }
        public string RequestQuery { get; set; }
        public string RequestPath { get; set; }
        public DateTime TimeStamp { get; private set; }
        public int StatusCode { get; private set; }
        public double ElapsedResponse { get; private set; }
        public Dictionary<string, string> RequestHeader { get; set; }
        public Dictionary<string, string> ResponseHeader { get; set; }

        public static implicit operator GenericRequestResponse(IndexingTask indexingTask)
        {
            return GenerateDataToLog(indexingTask.RequestObj, indexingTask.ResponseContent, indexingTask.StatusCode, indexingTask.ElapsedTime,
                indexingTask.RequestHeader, indexingTask.ResponseHeader, indexingTask.RequestMethod, indexingTask.RequestQuery, indexingTask.RequestPath);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        internal GenericRequestResponse()
        {
            TimeStamp = DateTime.Now;
        }

        private static GenericRequestResponse GenerateDataToLog
            (string dataStringRequest, string dataStringResponse, int statusCode,
                double elapsedTime, IHeaderDictionary requestHeader, IHeaderDictionary responseHeader, string requestMethod, string requestQuery, string requestPath)
        {
            var jsonDictRequest = DeserializeJson(dataStringRequest);
            var jsonDictResponse = DeserializeJson(dataStringResponse);
            var jsonHeaderRequest = DeserializeJson(requestHeader);
            var jsonHeaderResponse = DeserializeJson(responseHeader);
            var response = new GenericRequestResponse
            {
                Request = jsonDictRequest,
                Response = jsonDictResponse,
                StatusCode = statusCode,
                ElapsedResponse = elapsedTime,
                RequestHeader = jsonHeaderRequest,
                ResponseHeader = jsonHeaderResponse,
                RequestMethod = requestMethod,
                RequestQuery = requestQuery,
                RequestPath = requestPath
            };

            return response;
        }

        private static Dictionary<string, object> DeserializeJson(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString)) return new Dictionary<string, object>();

            try
            {
                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
                var dictionaryCopy = new Dictionary<string, object>(dictionary);

                foreach (var kvp in dictionary)
                {
                    if (kvp.Value is JObject nestedObject)
                    {
                        dictionaryCopy[kvp.Key] = DeserializeJson(nestedObject.ToString());
                    }
                }
                return dictionaryCopy;
            }
            catch (JsonException e)
            {
                var result = new Dictionary<string, object>();
                result["responseValue"] = jsonString;
                return result;
            }
        }

        private static Dictionary<string, string> DeserializeJson(IHeaderDictionary headerDictionary)
        {
            if (headerDictionary == null) return new Dictionary<string, string>();

            var relevantData = new Dictionary<string, string>();

            foreach (var kvp in headerDictionary)
            {
                relevantData[kvp.Key] = kvp.Value;
            }

            return relevantData;
        }
    }
}