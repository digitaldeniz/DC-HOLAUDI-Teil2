using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class RoadMaker : MonoBehaviour {

    public float radius = 30f;
    public float segments = 300f;

    public GameObject car;

    public float lineWidth = 0.3f;
    public float roadWidth = 8f;
    public float edgeWidth = 1f;
    public float edgeHeight = 1f;

    public float wavyness = 5f;
    public float waveScale = .1f;

    public int[] random_space = new int[] { 300, 600, 900, 1200};

    public Vector2 waveOffset;
    public Vector2 waveStep = new Vector2(0.01f, 0.01f);

    private bool stripeCheck = true;

    List<Vector3> roadsegment = new List<Vector3>();

    public GameObject[] objectToPlace = new GameObject[4]; // GameObject to place

    public Transform target;

    void Start () {
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
        MeshCollider meshCollider = this.GetComponent<MeshCollider>();
        MeshBuilder mb = new MeshBuilder(6);

        float segmentDegrees = 360f / segments;

        List<Vector3> points = new List<Vector3>();
        

        for (float degrees = 0; degrees < 360f; degrees += segmentDegrees)
        {
            Vector3 point = Quaternion.AngleAxis(degrees, Vector3.up) * Vector3.forward * radius;
            points.Add(point);
        }

        Vector2 wave = this.waveOffset;

        for (int i = 0; i < points.Count; i++)
        {
            wave += waveStep;

            Vector3 p0 = points[i];
            Vector3 centerDir = p0.normalized;

            float sample = Mathf.PerlinNoise(wave.x * waveScale, wave.y * waveScale);
            sample *= wavyness;

            float control = Mathf.PingPong(i, points.Count / 2f) / (points.Count / 2f);

            points[i] += centerDir * sample * control;

        }



        for (int i = 1; i < points.Count + 1; i++)
        {
            Vector3 pPrev = points[i - 1];
            Vector3 p0 = points[i % points.Count];
            Vector3 p1 = points[(i + 1) % points.Count];

            ExtrudeRoad(mb, pPrev, p0, p1);
        }

        car.transform.position = points[0];
        car.transform.LookAt(points[1]);

        meshFilter.mesh = mb.CreateMesh();
        meshCollider.sharedMesh = meshFilter.mesh;

        int einszahl = Random.Range(0, 3);
        int erscheinsegmentArray = Random.Range(0,3);
        int erscheinsegmentRoad = random_space[erscheinsegmentArray];
        Vector3 relativePos = roadsegment[erscheinsegmentRoad+1] - roadsegment[erscheinsegmentRoad];

        GameObject newObject = (GameObject)Instantiate(objectToPlace[einszahl], roadsegment[erscheinsegmentRoad], Quaternion.LookRotation(relativePos, new Vector3(0,1,0)));
        newObject.transform.Rotate(new Vector3(0, 1, 0), 90.0f);

        einszahl = Random.Range(0, 3);
        erscheinsegmentArray = Random.Range(0,3);
        erscheinsegmentRoad = random_space[erscheinsegmentArray]-100;
        relativePos = roadsegment[erscheinsegmentRoad+1] - roadsegment[erscheinsegmentRoad];
        GameObject newObject1 = (GameObject)Instantiate(objectToPlace[einszahl], roadsegment[erscheinsegmentRoad], Quaternion.LookRotation(relativePos, new Vector3(0, 1, 0)));
        newObject1.transform.Rotate(new Vector3(0, 1, 0),  90.0f);

        einszahl = Random.Range(0, 3);
        erscheinsegmentArray = Random.Range(0,3);
        erscheinsegmentRoad = random_space[erscheinsegmentArray]+200;
        relativePos = roadsegment[erscheinsegmentRoad + 1] - roadsegment[erscheinsegmentRoad];
        GameObject newObject2 = (GameObject)Instantiate(objectToPlace[einszahl], roadsegment[erscheinsegmentRoad], Quaternion.LookRotation(relativePos, new Vector3(0, 1, 0)));
        newObject2.transform.Rotate(new Vector3(0, 1, 0), 90.0f);

    }
     
    private Vector3 Direct (Vector3 p1, Vector3 p2)
    {
        return p2 - p1;
    }

    private void ExtrudeRoad (MeshBuilder mb, Vector3 pPrev, Vector3 p0, Vector3 p1)
    {
        //Roadline
        Vector3 offset = Vector3.zero;
        Vector3 target = Vector3.forward * lineWidth;

        MakeRoadQuad(mb, pPrev, p0, p1, offset, target, 0);

        //Road
        offset += target;
        target = Vector3.forward * roadWidth;

        MakeRoadQuad(mb, pPrev, p0, p1, offset, target, 1);

        int stripeSubmesh = 2;

        if (stripeCheck)
            stripeSubmesh = 3;

        stripeCheck = !stripeCheck;


        //edge
        offset += target;
        target = Vector3.up * edgeHeight;

        MakeRoadQuad(mb, pPrev, p0, p1, offset, target, stripeSubmesh);

        //edge top
        offset += target;
        target = Vector3.forward * edgeWidth;

        MakeRoadQuad(mb, pPrev, p0, p1, offset, target, stripeSubmesh);

        //edge
        offset += target;
        target = -Vector3.up * edgeHeight;

        MakeRoadQuad(mb, pPrev, p0, p1, offset, target, stripeSubmesh);

       

    }

    private void MakeRoadQuad (MeshBuilder mb, Vector3 pPrev, Vector3 p0, Vector3 p1, Vector3 offset, Vector3 targetOffset, int submesh)
    {
        Vector3 forward = (p1 - p0).normalized;
        Vector3 forwardPrev = (p0 - pPrev).normalized;
        //Build Outer
        Quaternion perp = Quaternion.LookRotation(
            Vector3.Cross(forward, Vector3.up)
            );
        Quaternion perpPrev = Quaternion.LookRotation(
            Vector3.Cross(forwardPrev, Vector3.up)
            );

        Vector3 tl = p0 + (perpPrev * offset);
        Vector3 tr = p0 + (perpPrev * (offset + targetOffset));

        Vector3 bl = p1 + (perp * offset);
        Vector3 br = p1 + (perp * (offset + targetOffset));

        mb.BuildTriangle(tl, tr, bl, submesh);
        mb.BuildTriangle(tr, br, bl, submesh);
        roadsegment.Add(tl);
        Debug.Log(roadsegment[0]);

        //Build Inner
        perp = Quaternion.LookRotation(
            Vector3.Cross(-forward, Vector3.up)
            );
        perpPrev = Quaternion.LookRotation(
            Vector3.Cross(-forwardPrev, Vector3.up)
            );

        tl = p0 + (perpPrev * offset);
        tr = p0 + (perpPrev * (offset + targetOffset));

        bl = p1 + (perp * offset);
        br = p1 + (perp * (offset + targetOffset));

        mb.BuildTriangle(bl, br, tl, submesh);
        mb.BuildTriangle(br, tr, tl, submesh);


        
            // generate random x position
            //int posx = (int)Random.Range(offset.x, targetOffset.x);
            // generate random z position
            //int posz = (int)Random.Range(offset.x, targetOffset.x);
            // get the terrain height at the random position
            //float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));
            // create new gameObject on random position
            
            
    }

}
