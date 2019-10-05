using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 1.0f;

    private Rigidbody _rigidbody;
    private Quaternion _cameraRotation;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();

        if (Camera.main != null)
            _cameraRotation = Quaternion.AngleAxis(Camera.main.transform.rotation.eulerAngles.y, Vector3.up);
    }

    private void Update()
    {
        var direction = _cameraRotation *
                        new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;


        var velocity = direction * speed * Time.deltaTime;

        _rigidbody.velocity = velocity;
        
        _animator.SetFloat("Velocity", velocity.magnitude);

        if (direction != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(direction);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}