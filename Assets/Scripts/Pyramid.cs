using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pyramid : MonoBehaviour
{
    public bool used = false;

    public GameObject hintObject;
    public GameObject oasis;
    public GameObject openedPyramid;

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

        oasis.SetActive(true);
        openedPyramid.SetActive(true);
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        gameObject.GetComponentInChildren<MeshCollider>().enabled = false;

        GameManager.Instance.GetComponent<SoundController>().pyramidDoorSource.Play();
        
        hintObject.GetComponentInChildren<Text>().text =
            "The door is open!\n";

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
