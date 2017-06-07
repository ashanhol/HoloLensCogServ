using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;

public class ImageToComputerVisionAPI : MonoBehaviour, IInputClickHandler {

    string VISIONKEY = "4d85151ca9504f36b92b911107244e6d"; // replace with your Computer Vision API Key

    string visionUrl = "https://eastus2.api.cognitive.microsoft.com/vision/v1.0/analyze?visualFeatures=Categories&language=en";

    public static byte[] files { get; set; }

    public string fileName { get; private set; }
    //string responseData;

    // Use this for initialization
    void Start () {
        fileName = Path.Combine(Application.streamingAssetsPath, "headshot.jpg"); // Replace with your file     

    }
	
	// Update is called once per frame
	void Update () {
	
        // This will be called with your specific input mechanism
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    GetVisionDataFromImages();
        //}

        //if (OnInputClicked())){

        //}
        ////{

        //}

	}
    /// <summary>
    /// Get emotion data from the Cognitive Services Emotion API
    /// Stores the response into the responseData string
    /// </summary>
    /// <returns> IEnumerator - needs to be called in a Coroutine </returns>
    public void OnInputClicked(InputClickedEventData eventData)
    {
        //     gameObject.GetComponent<Rigidbody>().useGravity=true;   
       if(gameObject.tag == "LoadCogServices")
        {
            byte[] abc = files;
            var coroutine = GetVisionDataFromImages(abc);
            StartCoroutine(coroutine);

        }

     }

    IEnumerator GetVisionDataFromImages(byte[] image)
    {
        var headers = new Dictionary<string, string>() {
                    { "Ocp-Apim-Subscription-Key", VISIONKEY },
                    { "Content-Type", "application/octet-stream" },
                    { "Host", "eastus2.api.cognitive.microsoft.com"}
        };

        //WWW www = new WWW(visionUrl, image, headers);

        //yield return www;
        //if (www.error == null)
        //{
        //    var responseData = www.text;
        //    GetComponent<ParseComputerVisionResponse>().ParseJSONData(responseData);

        //}
        //else
        //{
        //    System.Diagnostics.Debug.WriteLine("WWW Error: " + www.error);
        //}


        //}
        //byte[] abc = UnityEngine.Windows.File.ReadAllBytes(fileName);
        //name = gameObject.GetComponent<ImageToComputerVisionAPI>().fileName;
        //byte[] abc = File.ReadAllBytes(name);
        //        byte[] abc = files;
        //        // var headers = new Dictionary<string, string>() {
        ////            { "Ocp-Apim-Subscription-Key", VISIONKEY },
        ////            { "Content-Type", "application/octet-stream" }
        // //       };
        var client = new HttpClient();
        //var queryString = HttpUtility.ParseQueryString(string.Empty);

        // Request headers
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", VISIONKEY);

        //// Request parameters
        //queryString["visualFeatures"] = "Categories";
        //queryString["details"] = "{string}";
        //queryString["language"] = "en";
        var uri = "https://eastus2.api.cognitive.microsoft.com/vision/v1.0/analyze?visualFeatures=Categories&language=en";

        HttpResponseMessage response;

        // Request body
        //byte[] byteData = Encoding.UTF8.GetBytes("{body}");

        using (var content = new ByteArrayContent(image))
        {
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response = client.PostAsync(uri, content).Result;
        }

        //HttpClient client = new HttpClient();
        //Uri uri = new Uri(visionUrl);
        //HttpResponseMessage responsemessage = null;
        //var responsedata = "";


        //using (HttpRequestMessage requestmessage = new HttpRequestMessage())
        //{
        //    requestmessage.Headers.Add("Ocp-Apim-Subscription-Key", VISIONKEY);
        //    requestmessage.Headers.Add("Content - Type", "application / octet - stream");
        //    requestmessage.Method = new HttpMethod("post");
        //    requestmessage.Content = new ByteArrayContent(image);
        //    responsemessage = client.SendAsync(requestmessage).Result;
        //    HttpContent httpcontent = responsemessage.Content;

        //    responsedata = httpcontent.ReadAsStringAsync().Result;
        //    if (responsedata !="")
        //    {
        //        GetComponent<ParseComputerVisionResponse>().ParseJSONData(responsedata);
        //    }
        //    else
        //    {
        //        System.Diagnostics.Debug.WriteLine("UGH");
        //    }
        //}
        //GetComponent<ParseComputerVisionResponse>().ParseJSONData(responsedata);
        yield return response;
    }


}