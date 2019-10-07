using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Well : MonoBehaviour
{
    public bool lidOpened = false;
    public bool triedWater = false;

    public GameObject hintObject;
    public GameObject hintFailObject;

    private void Start()
    {
        _gameObject = GameObject.FindGameObjectWithTag("Player");
        _inventory = _gameObject.GetComponent<Inventory>();
    }

    private GameObject _gameObject;
    private Inventory _inventory;
    private Drop _drop;

    IEnumerator DrawWater()
    {
        triedWater = true;

        hintObject.GetComponentInChildren<Text>().text =
            "The well is dried out.\n Maybe I can find another source of water.";

        _inventory.RemoveItem(ItemType.Rope);
        _inventory.RemoveItem(ItemType.Bucket);

        yield return new WaitForSeconds(5f);


        hintObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") || !lidOpened || triedWater) return;


        if (_inventory.Contains(ItemType.Rope) && _inventory.Contains(ItemType.Bucket))
        {
            hintObject.SetActive(true);

            if (Input.GetAxisRaw("Use") == 1)
            {
                StartCoroutine(DrawWater());
            }
        }
        else
        {
            hintFailObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        hintObject.SetActive(false);
        hintFailObject.SetActive(false);
    }
}