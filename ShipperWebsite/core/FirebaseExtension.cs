using FireSharp;
using FireSharp.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using ShipperWebsite.FirebaseModel.FirebaseMessage;
using ShipperWebsite.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipperWebsite.core
{
    public static class FirebaseExtension
    {
        public static String PushNotification(this IFirebaseClient client, String topic, FMessage message)
        {
            var restClient = new RestClient(Config.FIREBASE_PUSH_NOTIFI_URL);
            var request = new RestRequest();
            request.Method = Method.POST;
            //request.Parameters.Clear();
            request.AddHeader("Authorization", "key="+Config.FIREBASE_PUSH_NOTIFI_API_KEY);
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/json", JsonConvert.SerializeObject(new {
                to = "/topics/"+topic,
                data = message
            }), ParameterType.RequestBody);
            var response = restClient.Execute(request);
            var content = response.Content;
            return JsonConvert.SerializeObject(new
            {
                to = "/topics/" + topic,
                data = message
            });
        }
    }
}