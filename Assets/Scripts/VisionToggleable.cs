using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionToggleable : MonoBehaviour
{
    public GameObject past;
    public GameObject present;
        
    // Start is called before the first frame update
    void Start()
    {
        present.SetActive(true);
        past.SetActive(false);
    }

    public void SwitchToPresent()
    {
        Debug.Log("Switching to present");
        present.SetActive(true);
        past.SetActive(false);
    }

    public void SwitchToPast()
    {
        Debug.Log("Switching to past");
        present.SetActive(false);
        past.SetActive(true);
    }
}
