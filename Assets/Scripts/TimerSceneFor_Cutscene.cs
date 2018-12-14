using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSceneFor_Cutscene : MonoBehaviour {

    public string levelToLoad;
    public float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            Application.LoadLevel(levelToLoad);
        }
		
	}
}
