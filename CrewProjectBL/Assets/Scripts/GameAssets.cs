using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;

    public GameAssets()
    {
        instance = this;
    }

    public Image blackOutSquare;
    public Transform interactButton;
    public Color outlineColor;

}
