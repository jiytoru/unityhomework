using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedP;
    [SerializeField]
    public float speedR;
    [SerializeField] private Vector3 direction;
    [SerializeField]  private Rigidbody rb;
    [SerializeField] private CapsuleCollider _collider;
    Quaternion p_Rot = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        dir();
        Movement();
    }

    void dir()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction.Set(direction.x, 0f, direction.z);
        var _speed = direction * speedP * Time.fixedDeltaTime;
        transform.Translate(_speed);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, direction, speedR * Time.deltaTime, 0f);
        p_Rot = Quaternion.LookRotation(desiredForward);

    }

    private void Movement()
    {
        rb.MovePosition(rb.position + direction * Time.deltaTime);
        rb.MoveRotation(p_Rot);
    }




}
