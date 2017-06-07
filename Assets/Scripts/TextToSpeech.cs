using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextToSpeech : MonoBehaviour {
    TextToSpeechManager tsm;
	// Use this for initialization
	void Start () {
        var soundManager = gameObject;
        tsm = soundManager.GetComponent<TextToSpeechManager>();

        tsm.SpeakText("Welcome to the Holographic App ! You can use Gaze, Gesture and Voice Command to interact with it!");
        tsm.SpeakText("this is a test!");

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void hiThere()
    {
        tsm.AudioSource = gameObject.GetComponentInChildren<AudioSource>();
        tsm.SpeakText("hi there");
    }
}
