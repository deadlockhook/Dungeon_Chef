using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;

public class GeneralPopup : MonoBehaviour
{
    // Start is called before the first frame update
    private IngameUIManager ingameUIManager;
    private List<ImageWithState> popupImages;
    public Sprite TestSprite;
    void Start()
    {
        ingameUIManager = FindAnyObjectByType<IngameUIManager>();
        popupImages = new List<ImageWithState>();
        PushElement(TestSprite,TestSprite);
        PushElement(TestSprite, TestSprite);
        PushElement(TestSprite, TestSprite);
    }

    public void PushElement(Sprite activeSprite,Sprite inactiveSprite)
    {
        ImageWithState imageObj = ingameUIManager.CreateImageWithState(this.gameObject.transform, activeSprite, inactiveSprite);

        if (imageObj)
        {
            popupImages.Add(imageObj);
            SetupPositions();
            Debug.Log("Add success ");
        }
    }
    void RemoveElement(ImageWithState state)
    {
        Debug.Log("Remove success " + popupImages.Remove(state));
        SetupPositions();
        //Recalculate all new positions of the popupImages
    }
    void SetupPositions()
    {
        ImageWithState prevItem = null;
        foreach (var currentItem in popupImages)
        {
            RectTransform currentItemRectTransform = currentItem.GetComponent<RectTransform>();

            if (prevItem == null)
            {
                currentItemRectTransform.position = this.gameObject.GetComponent<RectTransform>().position;
            }
            else
            {
                RectTransform prevItemRectTransform = prevItem.GetComponent<RectTransform>();

                Vector2 prevItemRectTransformPosition = prevItemRectTransform.position;
                Vector2 prevItemRectTransformSize = prevItemRectTransform.sizeDelta;

                currentItemRectTransform.GetComponent<RectTransform>().position = new Vector2(prevItemRectTransformPosition.x + prevItemRectTransformSize.x, prevItemRectTransformPosition.y + prevItemRectTransformSize.x);
            }

            prevItem = currentItem;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
