using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digger : MonoBehaviour
{
    public float cooldown;
    
    private float _currentCooldown;
    private bool _isDigging = false;
    private SphereCollider _sphereCollider;
    private Inventory _inventory;

    // Start is called before the first frame update
    void Start()
    {
        _inventory = GetComponent<Inventory>();
        _sphereCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Cooldown();
        
        if (CanDig() && Input.GetAxisRaw("Dig") == 1 && _currentCooldown <= 0)
        {
            StartCoroutine(StartDigging());
        }
    }

    private bool CanDig()
    {
        return _inventory.Contains(ItemType.Shovel);
    }

    private IEnumerator StartDigging()
    {
        _isDigging = true;
        
        _sphereCollider.enabled = true;

        yield return new WaitForSeconds(0.1f);

        _sphereCollider.enabled = false;

        _currentCooldown = cooldown;

        _isDigging = false;
    }

    private void Cooldown()
    {
        if (_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }
    }

    public bool IsDigging()
    {
        return _isDigging;
    }
}