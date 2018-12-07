using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarLight : MonoBehaviour {

	public Renderer frontLightOne;
    public Renderer frontLightOne_1;

    public Renderer frontLightTwo;
    public Renderer frontLightTwo_2;

    public Material frontLightOff;
	public Material frontLightOn;


	public Renderer backLightOne;
	public Renderer backLightTwo;

    public Material backLightOff;
	public Material backLightOn;


	/*public Renderer signalsLightOne;
	public Renderer signalsLightTwo;
	public Material signalsLightOff;
	public Material signalsLightOn;

	public Light spotLightLeft;
	public Light spotLightRight;*/

    public Image theImage;

    private bool lightSignals = true;

	// Use this for initialization
	void Start ()
	{
            //theImage.color = Color.black;
    }

    public void OnMouseDown()
    {
        

        if (!lightSignals)
        {
            frontLightOne.material = frontLightOn;
            frontLightOne_1.material = frontLightOn;

            frontLightTwo.material = frontLightOn;
            frontLightTwo_2.material = frontLightOn;

            backLightOne.material = backLightOn;
            backLightTwo.material = backLightOn;
            lightSignals = true;

            theImage.enabled = true;
            theImage.color = Color.white;

        }
        else
        {
            frontLightOne.material = frontLightOff;
            frontLightOne_1.material = frontLightOff;

            frontLightTwo.material = frontLightOff;
            frontLightTwo_2.material = frontLightOff;

            backLightOne.material = backLightOff;
            backLightTwo.material = backLightOff;

            lightSignals = false;

            //myImage.enabled = false;
            theImage.color = Color.black;
        }
        
        //spotLightLeft.intensity = 12f;
        //spotLightRight.intensity = 12f;
        
    }

    // Update is called once per frame
    /*public void Update ()
	{
		if (Input.GetKey (KeyCode.UpArrow)) 
		// here i can turn on the front light of the car
		{
			frontLightOne.material = frontLightOn;
            frontLightOne_1.material = frontLightOn;
            frontLightTwo.material = frontLightOn;
            frontLightTwo_2.material = frontLightOn;
            backLightOne.material = backLightOn;
            backLightTwo.material = backLightOn;
            spotLightLeft.intensity = 12f;
			spotLightRight.intensity = 12f;

		} 


		else if (Input.GetKey(KeyCode.DownArrow))
			// And here is simply turn off the front light
		{
			frontLightOne.material = frontLightOff;
            frontLightOne_1.material = frontLightOff;
            frontLightTwo.material = frontLightOff;
            frontLightTwo_2.material = frontLightOff;
            backLightOne.material = backLightOff;
            backLightTwo.material = backLightOff;
            spotLightLeft.intensity = 0f;
			spotLightRight.intensity = 0f;
		}


		


		if (Input.GetKey (KeyCode.LeftArrow)) 
			
		{
			signalsLightOne.material = signalsLightOn;
			signalsLightTwo.material = signalsLightOn;
			lightSignals = true;

		} 
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			signalsLightOne.material = signalsLightOff;
			signalsLightTwo.material = signalsLightOff;
			lightSignals = false;
		}

		if (lightSignals) 
		{
			
			float ping = 0f;
			float pong = 3f;
			float emission = ping + Mathf.PingPong (Time.time * 7f, pong - ping);
			signalsLightOne.material.SetColor ("_EmissionColor", new Color (5f, 5f, 1f) * emission);
			signalsLightTwo.material.SetColor ("_EmissionColor", new Color (5f, 5f, 1f) * emission);

		}



	}*/
}
