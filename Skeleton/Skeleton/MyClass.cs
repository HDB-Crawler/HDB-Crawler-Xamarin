using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    public class Constants
    {
        // Replace 192.168.8.106 with the IP of the API server
        private static string BASE_URL = "http://192.168.8.106/HdbEvents/public/";

        // URL for GET activities
        public static string ACTIVITY_URL = BASE_URL + "apiGetActivities";
        // URL for POST feedback
        public static string FEEDBACK_URL = BASE_URL + "postApiSetFeedback";
        // URL for POST rsvp (not implemented)
        public static string RSVP_URL = BASE_URL + "apiIncrement"; // increment member count in database. (hardcoded)
    }

    public class MyClass
    {
        public MyClass()
        {
        }
    }

    public class Activity
    {
        public string id { get; set; }

        // Might need
        public string category { get; set; }
        public string end_time { get; set; }

        // Need
        public string title { get; set; }
        public string venue { get; set; }
        public string date { get; set; }
        public string start_time { get; set; }
        public string description { get; set; }
        public string members_attending { get; set; }

        // Don't need
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string user_id { get; set; }
        public string sentiment { get; set; }
    }

    public class Message
    {
        public string message { get; set; }
    }

    public class ViewModel
    {
		// Variable that stores the result from calling the web service
        public ObservableCollection<Activity> Activities { get; set; } = new ObservableCollection<Activity>();
		// Call web service to get activity list
        public async Task<Boolean> GetActivitiesAsync()
        {
            try
            {
                var client = new HttpClient();
				// GET request
                var response = await client.GetStringAsync(Constants.ACTIVITY_URL);

                Debug.WriteLine(response);
                // Converts JSON to the specified .NET type (i.e. List<Activity>)
                var items = JsonConvert.DeserializeObject<List<Activity>>(response);

                // Refresh the elements in the ObservableCollection by clearing it and then re-populating it
                Activities.Clear();
                foreach (var item in items)
                {
                    Activities.Add(item);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return true;
        }

        public async Task<Boolean> SetIncrement()
        {
            try
            {
                var client = new HttpClient();
                // RSVP -> increment the number of attendees by 1
                var response = await client.GetStringAsync(Constants.RSVP_URL);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
            return true;
        }

        public async Task<Boolean> SetFeedback(String message)
        {
            try
            {
                var client = new HttpClient();

                // public class Message { public string message { get; set; } } was above
                Message message2 = new Message();
                message2.message = message;

                // Converts Message instance to JSON
                var json = JsonConvert.SerializeObject(message2);
                // Stopped here on 26 June 2016
                // Convert JSON format to string to send to the server
                var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
				
                // Why GET?
                // var response = await client.GetStringAsync(Constants.FEEDBACK_URL);
				// TODO: Test this web service
				var response = await client.PostAsync(Constants.FEEDBACK_URL, jsonContent);
				var responseContent = response.Content;
				var result = await responseContent.ReadAsStringAsync();

                Debug.WriteLine(response);

                var items = JsonConvert.DeserializeObject<List<Activity>>(result);
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return true;
        }
    }
}