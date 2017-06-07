using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System.IO;

public class click : MonoBehaviour, IInputClickHandler  {

    public GameObject go;

	// Use this for initialization
    void Start()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void DisplayImage()
    {
        Texture2D imageTxtr = new Texture2D(2, 2);
        
        string fileName = go.GetComponent<ImageToComputerVisionAPI>().fileName;
        byte[] fileData = UnityEngine.Windows.File.ReadAllBytes(fileName);
        imageTxtr.LoadImage(fileData);
        gameObject.GetComponent<Renderer>().material.mainTexture = imageTxtr;
        ImageToComputerVisionAPI.files = fileData;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        //     gameObject.GetComponent<Rigidbody>().useGravity=true;   
        DisplayImage();
    }
}
