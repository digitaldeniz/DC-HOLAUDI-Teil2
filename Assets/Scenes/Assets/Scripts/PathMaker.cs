using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PathShape
{
    public Vector3[] shape = new Vector3[] { -Vector3.up, Vector3.up, -Vector3.up };
}

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class PathMaker : MonoBehaviour {

    public Transform[] path;
    public PathShape pathShape;

	void Update () {
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
        MeshBuilder mb = new MeshBuilder(6);

        Vector3[] prevShape = TranslateShape(
            path[path.Length - 1].transform.position,
            (path[0].transform.position - path[path.Length - 1].transform.position).normalized,
            pathShape
            );

        for (int i = 0; i < path.Length; i++)
        {
            Vector3[] nextShape = TranslateShape(
                path[i].transform.position,
                (path[(i + 1) % path.Length].transform.position - path[i].transform.position).normalized,
                pathShape
                );

            for (int j = 0; j < nextShape.Length - 1; j++)
            {
                mb.BuildTriangle(prevShape[j], nextShape[j], nextShape[j + 1], 0);
                mb.BuildTriangle(prevShape[j + 1], prevShape[j], nextShape[j + 1], 0);
            }

            prevShape = nextShape;
        }


        meshFilter.mesh = mb.CreateMesh();
    }

    private Vector3[] TranslateShape (Vector3 point, Vector3 forward, PathShape shape)
    {

        Vector3[] translatedShape = new Vector3[pathShape.shape.Length];

        //create rotation using forward
        Quaternion forwardRot = Quaternion.LookRotation(forward);

        for (int i = 0; i < pathShape.shape.Length; i++)
        {
            translatedShape[i] = (forwardRot * pathShape.shape[i]) + point;
        }

        return translatedShape;
    }
}
