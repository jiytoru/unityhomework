using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRot : MonoBehaviour
{

    public Transform door;
    public bool isOpen;
    public float speedRot;
    private Transform _player;  
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(_player!= null)
        {
            Vector3 stepDir = Vector3.RotateTowards(door.forward, Vector3.back, speedRot*Time.fixedDeltaTime, 0f);
            door.rotation = Quaternion.LookRotation(stepDir);
        }
        else
        {
            Vector3 stepDir = Vector3.RotateTowards(door.forward, Vector3.forward, speedRot * Time.fixedDeltaTime, 0f);
            door.rotation = Quaternion.LookRotation(stepDir);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _player = other.transform;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _player = null;
    }
}
