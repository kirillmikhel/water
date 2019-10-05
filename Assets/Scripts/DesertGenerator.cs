using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertGenerator : MonoBehaviour
{
    public GameObject sandCudePrefab;
    public int size = 10;
    public int depth = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Generate()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < depth; k++)
                {
                    Instantiate(sandCudePrefab, new Vector3(i, k - 5, j), Quaternion.identity);
                }
            }
        }
    }
}
