using UnityEngine;
using System.Collections;

public class RimChoice : MonoBehaviour
{
    
    public MeshRenderer rimone1;
    public MeshRenderer rimone2;
    public MeshRenderer rimone3;
    public MeshRenderer rimone4;

    public MeshRenderer rimtwo1;
    public MeshRenderer rimtwo2;
    public MeshRenderer rimtwo3;
    public MeshRenderer rimtwo4;

    public Material matnew;
    Material mat;
    bool rimStat = true;
    static bool felge1 = true;

    void Start()
    {
        if (felge1)
        {
            rimtwo1.enabled = false;
            rimtwo2.enabled = false;
            rimtwo3.enabled = false;
            rimtwo4.enabled = false;

            rimone1.enabled = true;
            rimone2.enabled = true;
            rimone3.enabled = true;
            rimone4.enabled = true;

            felge1 = true;
            rimStat = true;
        }
        else
        {
            rimone1.enabled = false;
            rimone2.enabled = false;
            rimone3.enabled = false;
            rimone4.enabled = false;


            rimtwo1.enabled = true;
            rimtwo2.enabled = true;
            rimtwo3.enabled = true;
            rimtwo4.enabled = true;

            felge1 = false;
            rimStat = false;
        }

    }

    public void OnMouseDown()
    {
        
        if (!rimStat)
        {

            /*rimtwo1[0].SetActive(false);
            rimtwo1[1].SetActive(false);
            rimtwo1[2].SetActive(false);
            rimtwo1[3].SetActive(false);*/

            rimtwo1.enabled = false;
            rimtwo2.enabled = false;
            rimtwo3.enabled = false;
            rimtwo4.enabled = false;

            rimone1.enabled = true;
            rimone2.enabled = true;
            rimone3.enabled = true;
            rimone4.enabled = true;

            //rimone1.materials[1] = matnew;


            //GameObject.FindGameObjectWithTag("rim one").SetActive(true);
            rimStat = true;
            felge1 = true;
            Debug.Log("off");
        }
        else
        {
            //GameObject.FindGameObjectWithTag("rim one").SetActive(false);
            /*rimtwo1 = GameObject.FindGameObjectsWithTag("rim two");
            rimtwo1[0].SetActive(true);
            rimtwo1[1].SetActive(true);
            rimtwo1[2].SetActive(true);
            rimtwo1[3].SetActive(true);*/

            rimone1.enabled = false;
            rimone2.enabled = false;
            rimone3.enabled = false;
            rimone4.enabled = false;


            rimtwo1.enabled = true;
            rimtwo2.enabled = true;
            rimtwo3.enabled = true;
            rimtwo4.enabled = true;

            rimStat = false;
            felge1 = false;
            Debug.Log("on");
        }
    }
}

