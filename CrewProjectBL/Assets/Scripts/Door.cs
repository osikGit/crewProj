using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Door : Interactable
{

    public AudioSource audioSource;

    [SerializeField]
    private Transform teleportPosition;
    
    
    public override void Interact()
    {
        PlaySound();
        PlayerController.instance.teleporting = true;
        UIManager.instance.FadeIn();
        UIManager.instance.screenSetBlack += Instance_screenSetBlack;

        base.Interact();
    }

    private void Instance_screenSetBlack(object sender, System.EventArgs e)
    {
        StartCoroutine(TeleportTo(teleportPosition));
        UIManager.instance.screenSetBlack -= Instance_screenSetBlack;
        UIManager.instance.FadeOut();
    }

    public IEnumerator TeleportTo(Transform position)
    {
        SetOutline(0);
        PlayerController.instance.GetComponent<NavMeshAgent>().enabled = false;
        PlayerController.instance.transform.position = position.position;
        PlayerController.instance.GetComponent<NavMeshAgent>().enabled = true;
        yield return new WaitForSeconds(0.4f);
        PlayerController.instance.teleporting = false;

    }
    public void PlaySound()
    {
        audioSource.Play();
    }
}
