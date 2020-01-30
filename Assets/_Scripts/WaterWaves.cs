using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWaves : MonoBehaviour
{
    public float scale = 0.1f;
    public float speed = 1f;
    public float noiseStrength = 1f;
    public float noiseWalk = 1f;

    

    private Vector3[] baseHeight;
    Mesh mesh;
    // Start is called before the first frame update
    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void Update()
    {
        if (baseHeight == null)
            baseHeight = mesh.vertices;

        Vector3[] vertices = new Vector3[baseHeight.Length];
        for (int i=0;i<vertices.Length;i++)
        {
            Vector3 vertex = baseHeight[i];
            vertex.y += Mathf.Sin(Time.time * speed + baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;

            vertex.y += Mathf.PerlinNoise(baseHeight[i].x + noiseWalk, this.mesh.vertices[i].y + Mathf.Sin(Time.time * 0.1f)) * noiseStrength;

            vertices[i] = vertex;
        }
        //mesh.vertices = ve
    }
}
