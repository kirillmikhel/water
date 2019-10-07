using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanctuary : MonoBehaviour
{
    public bool activated = false;

    public GameObject hintObject;
    public GameObject hintFailObject;
    public GameObject activatedSanctuary;
    public GameObject pyramid;
    public GameObject oasis;

    private void Start()
    {
        _gameObject = GameObject.FindGameObjectWithTag("Player");
        _inventory = _gameObject.GetComponent<Inventory>();
    }

    private GameObject _gameObject;
    private Inventory _inventory;    

    IEnumerator Activate()
    {
        activated = true;

        activatedSanctuary.SetActive(true);
        pyramid.SetActive(true);
        oasis.SetActive(true);

        hintObject.GetComponentInChildren<Text>().text =
            "I hear something on the North...";

        _inventory.RemoveItem(ItemType.Mineral);
        _inventory.RemoveItem(ItemType.Stone);

        yield return new WaitForSeconds(5f);

        hintObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") || activated) return;


        if (_inventory.Contains(ItemType.Mineral) && _inventory.Contains(ItemType.Stone))
        {
            hintObject.SetActive(true);

            if (Input.GetAxisRaw("Use") == 1)
            {
                StartCoroutine(Activate());
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