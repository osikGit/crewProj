using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed = 0.5f;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMovement(); 
    }
    public void CheckMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
            Vector3 destination = new Vector3(horizontal*speed*Time.deltaTime, 0, vertical*speed * Time.deltaTime);

            agent.Move(destination);
        
    }
    public void ChangeSpeed(Scrollbar value)
    {
        speed = value.value*30;
    }
}
