using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Credits - Harjot Singh Gill 
 * NSCC - Game Programming Student
 * This script handles logic for on / off switch state for an image component for a game object.
*/
public class NewBehaviourScript : MonoBehaviour
{
    public bool bState = false; //set to public for initial state
    private UnityEngine.UI.Image imageComponent = null; //self attach
   
    public Sprite activeSprite = null;
    public Sprite inactiveSprite = null;
    void Start()
    {
        imageComponent = GetComponent<UnityEngine.UI.Image>();

        if (!activeSprite)
            activeSprite = imageComponent.sprite;

        if (!inactiveSprite)
            inactiveSprite = activeSprite;

        UpdateState(bState); // Set sprite according to initial state of the image
    }

    public bool GetState()
    {
        return bState;
    }
    public void UpdateState(bool newState)
    {
        bState = newState;

        if (imageComponent)
            imageComponent.sprite = activeSprite ? activeSprite : null;
        else
            imageComponent.sprite = inactiveSprite ? inactiveSprite : null;
    }

}
