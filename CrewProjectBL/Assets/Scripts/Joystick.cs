using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public Camera mainCamera;

    public float speed = 0.5f;
    public NavMeshAgent agent;

    private Vector2 pointA;
    private Vector2 pointB;

    private bool touchStart = false;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,mainCamera.transform.position.z));
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 destination = Vector2.ClampMagnitude(offset,1.0f);
            MoveCharacter(destination * (-1));

        }
    }
    void MoveCharacter(Vector2 direction)
    {
        Vector3 destination = Vector3.zero;

        destination.x = direction.x * speed * Time.deltaTime;
        destination.z = direction.y * speed * Time.deltaTime;
        destination.y = player.transform.position.y;

        agent.Move(destination);
    }
}
