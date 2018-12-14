using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNavigator : MonoBehaviour {

	public Transform[] views;
	public float transitionSpeed;
    Transform currentView;



	// Use this for initialization
	void Start () {
        // I had a problem here (Fehler Meldung ) component zuweisung missing to resolve it i just attached currentview to a created array
        currentView = views[0];
		
	}

	// Update is called once per frame
	 void Update(){
		
        // when i do press a key down(same for all of them)
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			currentView = views [1];

		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			currentView = views [2];

		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) 
		{
			currentView = views [3];

		}

		if (Input.GetKeyDown (KeyCode.Alpha4)) 
		{
			currentView = views [4];
			

		}

		/*if (Input.GetKeyDown (KeyCode.Alpha5)) 
		{
			currentView = views [5];

		}*/
		
	}
	

	void LateUpdate () 
	{

		//this is where i do use the lerp (linear interpolation ) for this interpolation i have been looking for many tutorials to see how it does work
        // ´the first one is simply a translation and the second one is a rotation on differents axes 

		transform.position = Vector3.Lerp (transform.position, currentView.position, Time.deltaTime * transitionSpeed);
		//Debug.Log ("Camera is moving");
		Vector3 currentAngle = new Vector3(
				Mathf.LerpAngle (transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime*transitionSpeed),
			    Mathf.LerpAngle (transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime*transitionSpeed),
		    	Mathf.LerpAngle (transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime*transitionSpeed));
				
		transform.eulerAngles = currentAngle;
		
	}
}
