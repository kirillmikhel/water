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
    private AudioSource _audioSource;
    private Vision _vision;


    // Start is called before the first frame update
    void Start()
    {
        _vision = GetComponent<Vision>();
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();

        if (Camera.main != null)
            _cameraRotation = Quaternion.AngleAxis(Camera.main.transform.rotation.eulerAngles.y, Vector3.up);
    }

    private void Update()
    {
        var direction = _cameraRotation *
                        new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;


        if (_vision.isOn)
        {
            direction = Vector3.zero;
        }

        var velocity = direction * speed * Time.deltaTime;


        _rigidbody.velocity = new Vector3(velocity.x, _rigidbody.velocity.y, velocity.z);


        _animator.SetFloat("Velocity", _rigidbody.velocity.magnitude);

        _audioSource.enabled = direction != Vector3.zero;

        if (direction != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(direction);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}