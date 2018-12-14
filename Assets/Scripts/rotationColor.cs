using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationColor : MonoBehaviour
{

    float smooth = 0.6f;
    //float tiltAngle = 60.0f;
    bool isRed;

    /* void Start()
     {
         Quaternion target = Quaternion.Euler(30, 0, 30);

         // Dampen towards the target rotation
         transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
     }*/

    /*private void OnMouseUpAsButton()
    {

        transform.Rotate(0,180,0);
        smooth = 3f;
    }*/

    void Update()
    {
        /*// Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);*/

        if (Input.GetMouseButtonDown(1))
        {
            transform.Rotate(0, 180, 0);
            smooth = 3f;
        }

        Quaternion target = Quaternion.Euler(180, 0, 0);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
