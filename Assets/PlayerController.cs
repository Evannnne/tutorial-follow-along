using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CapsuleCollider m_collider;
    private Rigidbody m_rigidbody;
    private Camera m_camera;
    private Animator m_animator;

    private void Awake()
    {
        m_collider = GetComponentInChildren<CapsuleCollider>();
        m_rigidbody = GetComponentInChildren<Rigidbody>();
        m_camera = GetComponentInChildren<Camera>();
        m_animator = GetComponent<Animator>();
    }

    private void Handle_Look() { }
    private void Handle_Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
    }
    private void Handle_Shooting() { }
    private void Handle_Jumping() { }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        Handle_Movement();    
    }

    // Update is called once per frame
    void Update()
    {
        Handle_Look();
        Handle_Jumping();
        Handle_Shooting();
    }
}
