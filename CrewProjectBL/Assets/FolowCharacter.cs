using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowCharacter : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        player = FindObjectOfType<Movement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }
}
