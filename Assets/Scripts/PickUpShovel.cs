using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpShovel : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        _gameObject = GameObject.FindGameObjectWithTag("Player");
        _inventory = _gameObject.GetComponent<Inventory>();
        _drop = GetComponent<Drop>();
    }

    public GameObject hintObject;
    private GameObject _gameObject;
    private Inventory _inventory;
    private Drop _drop;

    public void PickUp()
    {
        _inventory.AddItem(ItemType.Shovel);

        _drop.DoDrop();

        gameObject.SetActive(false);

        hintObject.SetActive(false);
    }

    private void OnCollisionStay(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        hintObject.SetActive(true);

        if (Input.GetAxisRaw("Use") == 1)
        {
            PickUp();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        hintObject.SetActive(false);
    }
}
