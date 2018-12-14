
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class halftrigger21 : MonoBehaviour
{

    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    void OnTriggerEnter()
    {
        LapCompleteTrig.SetActive(false);
        HalfLapTrig.SetActive(true);
    }
}