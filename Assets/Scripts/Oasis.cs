using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oasis : MonoBehaviour
{
    public GameObject credits;

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") || isTriggered) return;

        isTriggered = true;
        
        GameManager.Instance.GetComponent<SoundController>().outroSource.Play();
        
        credits.SetActive(true);
    }
}
