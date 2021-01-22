using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed = 0.5f;
    public float rotationSpeed = 0.5f;

    private Transform meshTransform;

    public NavMeshAgent agent;
    private Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        meshTransform = GetComponentInChildren<Collider>().transform;

        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement();
        CheckJoystickMovement();
        CheckRotation();
    }

    private void CheckRotation()
    {
        Vector2 direction = joystick.Direction;

        Vector3 result = new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        if (result != Vector3.zero)
        {
            meshTransform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(result), rotationSpeed*Time.deltaTime);
        }
    }

    public void CheckJoystickMovement()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 destination = new Vector3(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);

        agent.Move(destination);
    }
    public void CheckMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
            Vector3 destination = new Vector3(horizontal*speed*Time.deltaTime, 0, vertical*speed * Time.deltaTime);

            agent.Move(destination);

        Vector2 direction = joystick.Direction;

        Vector3 result = new Vector3(horizontal, 0, vertical);

        if (result != Vector3.zero)
        {
            meshTransform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(result), rotationSpeed * Time.deltaTime);
        }

    }
    public void ChangeSpeed(Scrollbar value)
    {
        speed = value.value*30;
    }
    public Quaternion GetRotation(Vector2 direction)
    {
        Vector3 resultVector = new Vector3();
        resultVector.x = direction.x;
        resultVector.z = direction.y;
        Quaternion quaternion = Quaternion.Euler(resultVector);
        return quaternion;
    }
}
