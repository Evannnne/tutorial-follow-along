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

    private void Handle_Look()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        float rotationX = mouseX * ViewRotationSensitivty;
        float rotationY = mouseY * ViewRotationSensitivty;

        Vector3 euler = m_camera.transform.localEulerAngles;
        euler.x += rotationY * -1;

        if (euler.x > 180) euler.x -= 360;
        if (euler.x < -180) euler.x += 360;
        euler.x = Mathf.Clamp(euler.x, -90, 90);

        m_camera.transform.localEulerAngles = euler;

        transform.Rotate(Vector3.up * rotationX);
    }
    private void Handle_Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized;
        movement *= MoveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement *= SprintModifier;
        }

        movement = transform.TransformVector(movement);

        movement.y = m_rigidbody.velocity.y;

        m_rigidbody.velocity = movement;
    }
    private void Handle_Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(m_camera.transform.position, m_camera.transform.forward, out hit, 1000))
            {
                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForceAtPosition(m_camera.transform.forward * ShootingForce, hit.point, ForceMode.Impulse);
                }

                hit.collider.gameObject.BroadcastMessage("Hit", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    private void Handle_Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float checkRange = m_collider.bounds.extents.y + 0.25f;

            if(Physics.Raycast(transform.position, Vector3.down, out _, checkRange))
            {
                Vector3 v = m_rigidbody.velocity;
                v.y = JumpVelocity;
                m_rigidbody.velocity = v;
            }
        }
    }

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
