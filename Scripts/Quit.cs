using UnityEngine;
using System.Collections;

// Quits the player when the user hits escape

public class Quit : MonoBehaviour
{
    public void exitApp()
    {
        
            Debug.Log("Hello");
            Application.Quit();


    }
    void Update()
    {
        /*if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Hello");
            Application.Quit();
            
        }*/
        
    }
}