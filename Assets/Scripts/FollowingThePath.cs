using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class FollowingThePath : MonoBehaviour
{
    public GameObject route;
    public float speed = 5.0f;
    public float rotationSpeed = 1.0f;
    public bool loop = false;

    private List<Vector3> _travelPath;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _travelPath = new List<Vector3>();

        foreach (var waypoint in route.GetComponentsInChildren<Transform>())
        {
            if (waypoint != route.transform)
                _travelPath.Add(new Vector3(waypoint.position.x, transform.position.y, waypoint.position.z));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_travelPath.Count == 0)
        {
            Stop();
            return;
        }

        var nextWaypoint = _travelPath[0];

        if (IsCloseTo(nextWaypoint))
        {
            if (loop)
            {
                _travelPath.Add(nextWaypoint);
            }
            
            _travelPath.RemoveAt(0);
        }
        else
        {
            MoveTo(nextWaypoint);
        }
    }

    private bool IsCloseTo(Vector3 position)
    {
        return Vector3.Distance(position, transform.position) < 1.0f;
    }

    private void MoveTo(Vector3 position)
    {
        var direction = (position - transform.position).normalized;

        var velocity = direction * speed * Time.deltaTime;

        _rigidbody.velocity = velocity;

        //_animator.SetFloat("Velocity", _rigidbody.velocity.magnitude);

        if (direction != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(direction);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void Stop()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}