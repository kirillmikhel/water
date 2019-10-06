using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float force = 10f;

    private bool _isLanded = true;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Jump") == 1 && _isLanded)
        {
            StartCoroutine(Jump());
        }
    }

    private IEnumerator Jump()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, force, _rigidbody.velocity.z);

        _isLanded = false;

        yield return new WaitForSeconds(1f);

        _isLanded = true;
    }
}