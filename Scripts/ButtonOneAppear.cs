using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOneAppear : MonoBehaviour
{


    [SerializeField] private Image myImage;
 

    // Use this for initialization
    void Start()
    {
   
       
    }


    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("CameraNav"))
        {
            myImage.enabled = true;
            
        }
       
        Debug.Log("It does work normally");
    }

    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("CameraNav"))
        {
            myImage.enabled = false;
           
        }
       
        Debug.Log("It did stop");

    }


   
   
}

