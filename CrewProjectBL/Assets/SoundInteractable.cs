using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInteractable : Interactable
{
    public AudioSource source;
    public override void Interact()
    {
        source.Play(); 
        base.Interact();
    }
}
