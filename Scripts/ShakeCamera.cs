using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour {

    public float power;
    public float duration;
    public Transform camera;
    public float slowDownAmount;
    public bool shouldShake = false;

    Vector3 startposition;
    float initialDuration;


	// Use this for initialization
	void Start () {

        camera = Camera.main.transform;
        startposition = camera.localPosition;
        initialDuration = duration;
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(shouldShake)
        {
            if(duration>0)
            {
                camera.localPosition = startposition + Random.insideUnitSphere*power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                camera.localPosition = startposition;
            }
        }
	}
}
