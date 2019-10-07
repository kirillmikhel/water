using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveWellCover : MonoBehaviour
{
    public GameObject hintObject;
    private Inventory _inventory;

    void Move()
    {
        GameManager.Instance.GetComponent<SoundController>().wellCoverMovingSource.Play();

        GameObject.FindGameObjectWithTag("Well").GetComponent<Well>().lidOpened = true;


        gameObject.SetActive(false);

        hintObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        hintObject.SetActive(true);

        if (Input.GetAxisRaw("Use") == 1)
        {
            Move();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        hintObject.SetActive(false);
    }
}