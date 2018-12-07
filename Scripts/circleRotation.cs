using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleRotation : MonoBehaviour {

    public Renderer circle;
    bool chScale = true;
    Vector3 onto = new Vector3(1,1,1);
	// Use this for initialization
	void Start () {
        circle.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
        circle.transform.Rotate(onto);
        if (circle.transform.localScale.x < 90f && chScale)
            circle.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);

        else if (circle.transform.localScale.x > 90f)
        {
            chScale = false;
            circle.transform.localScale = new Vector3(89.9f, 89.9f, 89.9f);
        }


        else if (circle.transform.localScale.x > 40f && chScale == false)
            circle.transform.localScale += new Vector3(-0.1f, -0.1f, -0.1f);

        else if (circle.transform.localScale.x < 40f)
        {
            chScale = true;
            circle.transform.localScale = new Vector3(40.01f, 40.01f, 40.01f);
        }

    }
}
