using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite TestSprite;

    void Start()
    {

    }

    void Update()
    {

    }

    public ImageWithState CreateImageWithState(Transform parent, Sprite activeSprite, Sprite inactiveSprite)
    {
        return CreateImageWithStateEx(this.gameObject.transform, activeSprite, inactiveSprite, false, new Vector2(50, 50)); ;
    }

    public ImageWithState CreateImageWithStateEx(Transform parent, Sprite activeSprite, Sprite inactiveSprite, bool initialState, Vector2 scale)
    {
        GameObject prefab = Resources.Load<GameObject>($"Prefabs/UI/ImageWithStatePrf");

        if (prefab == null)
        
            return null;

        GameObject newImageObject = Instantiate(prefab, parent);

        ImageWithState imageWithStateScript = newImageObject.GetComponent<ImageWithState>();

        if (imageWithStateScript == null)
            return null;

        imageWithStateScript.SetActiveSprite(activeSprite);
        imageWithStateScript.SetInActiveSprite(inactiveSprite);
        imageWithStateScript.UpdateState(initialState);

        newImageObject.GetComponent<RectTransform>().sizeDelta = scale;

        return imageWithStateScript;
    }
}
