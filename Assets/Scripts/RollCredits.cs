using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RollCredits : MonoBehaviour
{
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
