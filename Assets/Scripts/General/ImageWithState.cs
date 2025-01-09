using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Credits - Harjot Singh Gill 
 * NSCC - Game Programming Student
 * This script handles logic for on / off switch state for an image component for a game object.
*/
public class ImageWithState : MonoBehaviour
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

    public void SetActiveSprite(Sprite _activeSprite)
    {
        activeSprite = _activeSprite;
    }

    public void SetInActiveSprite(Sprite _inactiveSprite)
    {
        inactiveSprite = _inactiveSprite;
    }
    public void UpdateState(bool newState)
    {
        bState = newState;

        // Had to use GetComponent<UnityEngine.UI.Image>() due to unity's null exception bug

        if (bState)
            GetComponent<UnityEngine.UI.Image>().sprite = activeSprite;
        else
            GetComponent<UnityEngine.UI.Image>().sprite = inactiveSprite;
    }

}
