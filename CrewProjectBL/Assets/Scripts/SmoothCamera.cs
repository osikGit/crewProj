using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothCamera : MonoBehaviour
{
    public Transform player;
    [Range(3,30)]
    public float cameraHeight = 11f;
    void Start()
    {
        
    }
    
    void Update()
    {
        Vector3 velocity = Vector3.zero;
        Vector3 forward = player.transform.forward * 10.0f;
        Vector3 needPos = player.transform.position - forward;
        needPos.y = cameraHeight;
        if (!PlayerController.instance.teleporting)
        {
            transform.position = Vector3.SmoothDamp(transform.position, needPos,
                                                    ref velocity, 0.05f);
        }
        else
        {
            transform.position = needPos;
        }
        transform.LookAt(player.transform);
    }

    public void ChangeSpeed(Scrollbar value)
    {
        cameraHeight = value.value * 30;
    }
}
