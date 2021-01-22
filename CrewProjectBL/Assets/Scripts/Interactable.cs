using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    [SerializeField]
    private float maxWidth = 1.5f;
    
    [SerializeField]
    private float interactDelay = 0.5f;

    private float lastTime;
    [SerializeField]
    private float koef;

    public float MaxWidth
    {
        get
        {
            return maxWidth;
        }
    }


    public void Awake()
    {
        //GetComponent<Outline>().OutlineColor = GameAssets.instance.outlineColor;
        //GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineVisible;
        //GetComponent<Outline>().OutlineWidth = 0;
    }

    public virtual void Interact()
    {
        print("Interacting with "+gameObject.name);
    }
    public virtual void SetOutline(float distance, float maxRange, float minRange)
    {
        float width = koef*maxWidth*(1-(Mathf.Clamp(distance-minRange, minRange, maxRange-minRange) /maxRange));
        if(width < 1)
        {
            width = 0;
        }
        GetComponent<Outline>().OutlineWidth = width;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, PlayerController.instance.maxRange);
    }

    public virtual void OnMouseDown()
    {
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
