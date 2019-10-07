using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryContent : MonoBehaviour
{
    private Text _text;
    private Inventory _inventory;

    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        var text = "";

        foreach (var item in _inventory.items)
        {
            text +=  item.ToString();
            
            switch (item)
            {
                case ItemType.Artifact:
                    text += "  (Hold Tab)";
                    break;
                case ItemType.Shovel:
                    text += "  (Z)";
                    break;
            }

            text += "\n";
        }

        _text.text = text;
    }
}