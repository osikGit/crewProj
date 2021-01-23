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

    private Interactable nearestInteractable;

    public bool teleporting;
    private float lastTime;

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
        if (hitColliders.Where(x => x.GetComponent<Interactable>() != null).Count() == 0)
        {
            nearestInteractable = null;
            SetInteractableButtonEnabled(false);
        }
        else
        {
            nearestInteractable = hitColliders.Where(x => x.GetComponent<Interactable>() != null).FirstOrDefault().GetComponent<Interactable>();
        }
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitColliders[i].GetComponent<Interactable>();
                if (interactable != null)
                {
                    if (Vector3.Distance(interactable.transform.position, transform.position) < Vector3.Distance(nearestInteractable.transform.position, transform.position))
                    {
                        nearestInteractable = interactable;
                    }
                    interactable.SetOutline(Vector3.Distance(hitColliders[i].transform.position, transform.position), maxRange, minRange);
                    SetInteractableButtonEnabled(true);
                }
            }
        }
    }
    void SetInteractableButtonEnabled(bool enabled)
    {
        GameAssets.instance.interactButton.gameObject.SetActive(enabled);
    }
    public void Interact()
    {
        if (nearestInteractable != null)
        {
            if (Time.time - lastTime > nearestInteractable.interactDelay)
            {
                if (nearestInteractable.GetComponent<Outline>().OutlineWidth > 1)
                    nearestInteractable.Interact();
                lastTime = Time.time;
            }
            else
            {
                print("Wait " + (nearestInteractable.interactDelay - (Time.time - lastTime)).ToString() + " seconds to continue");
            }
        }
    }
}