using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pyramid : MonoBehaviour
{
    public bool used = false;

    public GameObject hintObject;

    private void Start()
    {
        _gameObject = GameObject.FindGameObjectWithTag("Player");
        _inventory = _gameObject.GetComponent<Inventory>();
    }

    private GameObject _gameObject;
    private Inventory _inventory;
    private Drop _drop;

    IEnumerator Use()
    {
        used = true;

        hintObject.GetComponentInChildren<Text>().text =
            "The door is open!\n I see something...";

        _inventory.RemoveItem(ItemType.Artifact);

        yield return new WaitForSeconds(5f);

        hintObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") || used) return;

        
        if (_inventory.Contains(ItemType.Artifact))
        {
            hintObject.SetActive(true);

            if (Input.GetAxisRaw("Use") == 1)
            {
                StartCoroutine(Use());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        hintObject.SetActive(false);
    }
}
