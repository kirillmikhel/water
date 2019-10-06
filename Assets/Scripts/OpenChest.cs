using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public bool opened = false;

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

    public void Open()
    {
        _inventory.AddItem(ItemType.Shovel);

        opened = true;
        
        _drop.DoDrop();

        gameObject.SetActive(false);

        hintObject.SetActive(false);
    }

    private void OnCollisionStay(Collision other)
    {
        if (!other.gameObject.CompareTag("Player") || opened) return;

        hintObject.SetActive(true);

        if (Input.GetAxisRaw("Use") == 1)
        {
            Open();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (!other.gameObject.CompareTag("Player") || opened) return;

        hintObject.SetActive(false);
    }
}