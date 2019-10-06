using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHint : MonoBehaviour
{
    public ItemType itemToHave;
    private GameObject _gameObject;
    private Inventory _inventory;
    private Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
        _gameObject = GameObject.FindGameObjectWithTag("Player");
        _inventory = _gameObject.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.enabled = _inventory.Contains(itemToHave);
    }
}
