using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarLightBlink : MonoBehaviour {


	public Renderer signalsLightOne;
	public Renderer signalsLightTwo;
	public Material signalsLightOff;
	public Material signalsLightOn;

    public Image myImage;

    private bool lightSignals = false;

	// Use this for initialization
	void Start ()
	{
        myImage.color = Color.black;
    }

    public void OnMouseDown()
    {
        if (!lightSignals)
        {
            signalsLightOne.material = signalsLightOn;
            signalsLightTwo.material = signalsLightOn;
            lightSignals = true;

            //myImage.enabled = true;
            myImage.color = Color.white;
        }
        else
        {
            signalsLightOne.material = signalsLightOff;
            signalsLightTwo.material = signalsLightOff;
            lightSignals = false;

            //myImage.enabled = false;
            myImage.color = Color.black;
        }

        
    }

    // Update is called once per frame
    public void Update ()
	{
        if (Input.GetKey (KeyCode.LeftArrow)) 
			
		{
            signalsLightOne.material = signalsLightOn;
            signalsLightTwo.material = signalsLightOn;
            lightSignals = true;

            myImage.enabled = true;
            myImage.color = Color.white;

        } 
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			signalsLightOne.material = signalsLightOff;
			signalsLightTwo.material = signalsLightOff;
			lightSignals = false;

            //myImage.enabled = false;
            myImage.color = Color.black;
        }

		if (lightSignals) 
		{
			
			float ping = 0f;
			float pong = 3f;
			float emission = ping + Mathf.PingPong (Time.time * 7f, pong - ping);
			signalsLightOne.material.SetColor ("_EmissionColor", new Color (5f, 5f, 1f) * emission);
			signalsLightTwo.material.SetColor ("_EmissionColor", new Color (5f, 5f, 1f) * emission);

		}
    }
}
