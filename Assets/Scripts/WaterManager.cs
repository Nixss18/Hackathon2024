using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    private MeshFilter waterMeshFilter;

    private void Awake()
    {
        waterMeshFilter = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        Vector3[] vertices = waterMeshFilter.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = WaveManager.instance.GetWaveHeight(transform.position.x + vertices[i].x);

        }
        waterMeshFilter.mesh.vertices = vertices;
        waterMeshFilter.mesh.RecalculateNormals();
    }
}