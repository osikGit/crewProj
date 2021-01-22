using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float maxRange;

    public float minRange;

    public static PlayerController instance;

    public PlayerController()
    {
        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckRange();
    }

    private void CheckRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, maxRange);
        for(int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].GetComponent<Interactable>()!=null)
            {
                Interactable interactable = hitColliders[i].GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.SetOutline(Vector3.Distance(hitColliders[i].transform.position, transform.position), maxRange, minRange);
                }
            }
        }
    }
}
