using UnityEngine;
using System.Collections;
using UnityEngine.Windows;
using HoloToolkit.Unity.InputModule;
using System;
using System.IO;

public class ShowImageOnPanel : MonoBehaviour, IInputClickHandler
{

    public GameObject ImageFrameObject; // The object to place the image on

    // Use this for initialization
    public string fileName { get; private set; }
    void Start () {
        fileName = Path.Combine(Application.streamingAssetsPath, "headshot.jpg"); // Replace with your file     
    }

    // Update is called once per frame
    void Update () {

        // Replace this block of code with how you plan to call your image display
	    //if(Input.GetKeyDown(KeyCode.P))
     //   {
     //       DisplayImage();
     //   }
	}
    public void OnInputClicked(InputClickedEventData eventData)
    {
        //     gameObject.GetComponent<Rigidbody>().useGravity=true;   
        if(gameObject.tag == "MainImage")
        {

            DisplayImage();


        }
     }
    void DisplayImage()
    {
        Texture2D imageTxtr = new Texture2D(2, 2);
        string fileName = gameObject.GetComponent<ImageToComputerVisionAPI>().fileName;
        //string fileName = Path.Combine(Application.streamingAssetsPath, "headshot.jpg");
        byte[] fileData = System.IO.File.ReadAllBytes(fileName);
        imageTxtr.LoadImage(fileData);
        ImageFrameObject.GetComponent<Renderer>().material.mainTexture = imageTxtr;
        ImageToComputerVisionAPI.files = fileData;
    }


}
