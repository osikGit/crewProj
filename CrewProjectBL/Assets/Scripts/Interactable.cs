using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    [SerializeField]
    private float maxWidth = 1.5f;
    [SerializeField]
    private float minWidth = 1f;

    public float interactDelay = 0.5f;

    private float lastTime;
    [SerializeField]
    private float koef = 3f;

    public float MaxWidth
    {
        get
        {
            return maxWidth;
        }
    }
    

    public virtual void Interact()
    {
        print("Interacting with "+gameObject.name);
    }
    public virtual void SetOutline(float distance, float maxRange, float minRange)
    {
        float width = koef*maxWidth*(1-(Mathf.Clamp(distance-minRange, minRange, maxRange-minRange) /maxRange));
        if(width < minWidth)
        {
            width = 0;
        }
        GetComponent<Outline>().OutlineWidth = width;
    }
    public virtual void SetOutline(float value)
    {
        if (value < minWidth)
        {
            value = 0;
        }
        GetComponent<Outline>().OutlineWidth = value;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, PlayerController.instance.maxRange);
    }

    public virtual void OnMouseDown()
    {
        return;
        if (Time.time - lastTime > interactDelay)
        {
            if (GetComponent<Outline>().OutlineWidth > 1)
                Interact();
        }
        else
        {
            print("Wait "+(interactDelay-(Time.time - lastTime)).ToString()+" seconds to continue");
        }
        lastTime = Time.time;
    }
}
