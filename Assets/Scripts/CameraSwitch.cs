using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour {

	Camera my_mainCamera;
	public Camera camera_Nav;
    public Image myImage;
    public Image myImage1;
    public Image myImage2;
    public Image myImage3;

    // Use this for initialization
    void Start () 
	{
		
		//Here i do define my main camera as Main camera
		my_mainCamera = Camera.main;
		//Here i do activate my main Camera
		my_mainCamera.enabled = true;
		//Here i do unebale the second camera;
		camera_Nav.enabled = false;

	}
	
	// Update is called once per frame
	void Update ()
	{
		//Here i am about to give the input meaning when i press the button c is does switch
		if (Input.GetKeyDown (KeyCode.C)) 
		{	
			if (my_mainCamera.enabled) {

				camera_Nav.enabled = true;
				my_mainCamera.enabled = false;
       
            } 

			else if (!my_mainCamera.enabled)
			
			{
				camera_Nav.enabled = false;
				my_mainCamera.enabled = true;
                myImage.enabled = false;
                myImage1.enabled = false;
                myImage2.enabled = false;
                myImage3.enabled = false;

            }
		}
		
	}
}
