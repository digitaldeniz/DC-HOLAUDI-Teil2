using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLightR8 : MonoBehaviour {

	public Renderer frontLight;
	public Material frontLightOff;
	public Material frontLightOn;


	public Renderer backLight;
	public Material backLightOff;
	public Material backLightOn;


	public Renderer signalsLight;
	public Material signalsLightOff;
	public Material signalsLightOn;

	public Light spotLightLeft;
	public Light spotLightRight;

	private bool lightSignals = false;


	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	public void Update ()
	{
		if (Input.GetKey (KeyCode.UpArrow) ) 
			// here i can turn on the front light of the car but i am gonna change and put a button
		{
			frontLight.material = frontLightOn;
			spotLightLeft.intensity = 8f;
			spotLightRight.intensity = 8f;


		} 
		else if(Input.GetKey(KeyCode.UpArrow))
			// And here is simply turn off the front light also here change the function and use a button

		{
			frontLight.material = frontLightOff;
			spotLightLeft.intensity = 0f;
			spotLightRight.intensity= 0f;

	
		}


		if (Input.GetKey (KeyCode.DownArrow)) 

		{
			backLight.material = backLightOn;


		} 

		else
		{
			backLight.material = backLightOff;
		
		}


		if (Input.GetKey (KeyCode.LeftArrow)) 

		{
			signalsLight.material = signalsLightOn;
			lightSignals = true;

		} 
		else
		{
			signalsLight.material = signalsLightOff;
			lightSignals = false;
		}

		if (lightSignals) 
		{

			float ping = 0f;
			float pong = 3f;
			float emission = ping + Mathf.PingPong (Time.time * 5f, pong - ping);
			signalsLight.material.SetColor ("_EmissionColor", new Color (8f, 8f, 1f) * emission);


		}



	}
}
