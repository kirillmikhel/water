using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject itemToDrop;


    public void DoDrop()
    {
        Instantiate(itemToDrop, transform.position, Quaternion.identity);
        
        GameManager.Instance.GetComponent<SoundController>().discoverySource.Play();
    }
}
