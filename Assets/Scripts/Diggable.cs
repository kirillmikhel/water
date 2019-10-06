using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diggable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        if (!other.gameObject.GetComponent<Digger>().IsDigging()) return;

        Destroy(gameObject);
    }
}