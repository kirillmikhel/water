using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class DuneGenerator : MonoBehaviour
{
    public GameObject sandCubePrefab;
    public int width = 12;
    public int depth = 12;
    public int height = 12;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    void Generate()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                for (int y = 0; y < height; y++)
                {
                    var temp = 2000 * F(x, z, width / 2, depth / 2, 10);
                    Debug.Log(temp);
                    Debug.Log(y);
                    
                    if (temp > y)
                    {
                        var sandCube = Instantiate(sandCubePrefab, new Vector3(x, y, z),
                            Quaternion.identity);

                        sandCube.transform.SetParent(transform);
                    }
                }
            }
        }
        
        CombineMeshes();
    }

    private float F(float x, float y, float meanX, float meanY, float dev)
    {
        //return (float) (one_over_2pi * Mathf.Exp(-(x - mean) * (x - mean) / (2 * var)));

        return (1 / (2 * Mathf.PI * Mathf.Pow(dev, 2))) *
               Mathf.Exp(-(1 / (2 * Mathf.Pow(dev, 2))) * (Mathf.Pow(x - meanX, 2) + Mathf.Pow(y - meanY, 2)));
    }

    void CombineMeshes()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        Material sandMaterial = meshFilters[1].GetComponent<MeshRenderer>().material;

        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;

            if (meshFilters[i].gameObject != gameObject)
            {
                Destroy(meshFilters[i].gameObject);
            }

            i++;
        }

        GetComponent<MeshFilter>().mesh = new Mesh();
        GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        
        GetComponent<MeshRenderer>().material = sandMaterial;
        GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().mesh;        
        
        gameObject.SetActive(true);
    }
}