using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hideMenu : MonoBehaviour
{

    public Image canvasGUI, canvasGUI1, canvasGUI2, canvasGUI3, canvasGUI4, canvasGUI5;
    public Text text1, text2, text3, text4;
    public MeshRenderer GUI3D1;
    public MeshRenderer GUI3D2;
    public MeshRenderer GUI3D3;
    public MeshRenderer GUI3D4;
    public BoxCollider Light;
    public BoxCollider LightBlink;
    public BoxCollider ColorBu;
    public BoxCollider Rims;


    Material mat;
    bool hide = false;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKeyDown("h"))
        {

            if (hide)
            {
                canvasGUI.enabled = true;
                canvasGUI1.enabled = true;
                canvasGUI2.enabled = true;
                canvasGUI3.enabled = true;
                canvasGUI4.enabled = true;
                canvasGUI5.enabled = true;

                text1.enabled = true;
                text2.enabled = true;
                text3.enabled = true;
                text4.enabled = true;

                GUI3D1.enabled = true;
                GUI3D2.enabled = true;
                GUI3D3.enabled = true;
                GUI3D4.enabled = true;

                Light.enabled = true;
                LightBlink.enabled = true;
                Rims.enabled = true;
                ColorBu.enabled = true;

                hide = false;
            }
            else
            {
                canvasGUI.enabled = false;
                canvasGUI1.enabled = false;
                canvasGUI2.enabled = false;
                canvasGUI3.enabled = false;
                canvasGUI4.enabled = false;
                canvasGUI5.enabled = false;


                text1.enabled = false;
                text2.enabled = false;
                text3.enabled = false;
                text4.enabled = false;

                GUI3D1.enabled = false;
                GUI3D2.enabled = false;
                GUI3D3.enabled = false;
                GUI3D4.enabled = false;

                Light.enabled = false;
                LightBlink.enabled = false;
                Rims.enabled = true;
                ColorBu.enabled = true;


                hide = true;
            }
            
        }
 
    }
}

