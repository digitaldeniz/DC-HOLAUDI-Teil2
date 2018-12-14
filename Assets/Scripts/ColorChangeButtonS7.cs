using UnityEngine;
using System.Collections;

public class ColorChangeButtonS7 : MonoBehaviour
{
    public Renderer render;
    public Material[] materials;

    static public int index = 0;
    static public int ausgewählt;

    void Start()
    {
        render = GetComponent<Renderer>();
        index = ausgewählt + 1;
    }

    public void Update()
    {

        if (materials.Length == 0)
        {
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {

            render.sharedMaterial = materials[index % 6];
            ausgewählt = index;
            index += 1;

        }
        render.material = materials[ausgewählt % 6];
    }
}