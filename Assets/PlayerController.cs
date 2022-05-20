using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Health = 100;
    public float GunDamage = 20;
    public float ViewRotationSensitivty = 4;
    public float MoveSpeed = 4;
    public float SprintModifier = 2;
    public float JumpVelocity = 5;
    public float ShootingForce = 100;

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
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized;
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
