using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    private bool _isGrounded;
    public bool isGrounded => _isGrounded;
    private float _groundDistance = 0.55f;

    void Update()
    {
        GroundControl();
    }

    private void GroundControl()
    {
        if (Physics.Raycast(transform.position, Vector3.down, _groundDistance))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }
}
