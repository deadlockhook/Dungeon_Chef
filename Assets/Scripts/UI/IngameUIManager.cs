using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ImageWithStatePrf;
    public GameObject CreateImageWithState(Transform parent, Sprite activeSprite, Sprite inactiveSprite, bool initialState)
    {
        GameObject prefab = Resources.Load<GameObject>($"Prefabs/UI/ImageWithStatePrf");

        if (ImageWithStatePrf == null)
        {
            Debug.LogError("ImageWithStatePrf is not assigned in the Inspector!");
            return null;
        }

        GameObject newImageObject = Instantiate(ImageWithStatePrf, parent);

        ImageWithState imageWithStateScript = newImageObject.GetComponent<ImageWithState>();

        if (imageWithStateScript == null)
        {
            Debug.LogError("Prefab does not have the ImageWithState script attached!");
            return null;
        }

        // Set the active and inactive sprites
        imageWithStateScript.SetActiveSprite(activeSprite);
        imageWithStateScript.SetInActiveSprite(inactiveSprite);
        imageWithStateScript.UpdateState(initialState);
        // Return the created GameObject
        return newImageObject;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
