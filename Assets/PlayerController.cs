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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
