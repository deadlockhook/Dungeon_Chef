using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GeneralPopup : MonoBehaviour
{
    // Start is called before the first frame update
    private IngameUIManager ingameUIManager;
    private List<ImageWithState> popupImages;
    public int popupElementSize = 50;
    public int widthPerElement = 2;
    public int maxElementsPerRow = 3;
    public int maxColumns = 3;

    public Sprite TestSpriteActive;
    public Sprite TestSpriteInactive;

    private int rowSize = 0;
    private int columnSize = 0;
    void Start()
    {
        rowSize = ((popupElementSize + widthPerElement) + widthPerElement) * maxElementsPerRow;
        columnSize = ((popupElementSize + widthPerElement) + widthPerElement) * maxColumns;
        ingameUIManager = FindAnyObjectByType<IngameUIManager>();
        popupImages = new List<ImageWithState>();
        PushElement(TestSpriteActive, TestSpriteInactive);
        PushElement(TestSpriteActive, TestSpriteInactive);
        PushElement(TestSpriteActive, TestSpriteInactive);
        PushElement(TestSpriteActive, TestSpriteInactive);
        PushElement(TestSpriteActive, TestSpriteInactive);
        PushElement(TestSpriteActive, TestSpriteInactive);
        PushElement(TestSpriteActive, TestSpriteInactive);


        RectTransform backgroundImageRectTransform = transform.Find("BG").GetComponent<RectTransform>();
        RectTransform parentRectTransform = this.gameObject.GetComponent<RectTransform>();
   //     backgroundImageRectTransform.anchoredPosition = parentRectTransform.anchoredPosition;
        backgroundImageRectTransform.position = parentRectTransform.position;

        backgroundImageRectTransform.sizeDelta = new Vector2(rowSize/ 2.0f, columnSize / 2.0f);
    }

    public void PushElement(Sprite activeSprite,Sprite inactiveSprite)
    {
        ImageWithState imageObj = ingameUIManager.CreateImageWithStateEx(this.gameObject.transform, activeSprite, inactiveSprite, false, new Vector2(popupElementSize, popupElementSize));

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
        int currentElementInRow = 0;
        int currentColumn = 0;

        int currentElementIndex = 0;

        Vector2 thisObjectRectTransformPosition = this.gameObject.GetComponent<RectTransform>().position;

        foreach (var currentItem in popupImages)
        {
            if (currentElementIndex == maxElementsPerRow)
            {
                currentColumn++;
                currentElementIndex = 0;
            }

            RectTransform currentItemRectTransform = currentItem.GetComponent<RectTransform>();
            Vector2 currentItemRectTransformPosition = currentItemRectTransform.position;
            Vector2 currentItemRectTransformSize = currentItemRectTransform.sizeDelta;
            currentItemRectTransform.position = new Vector2(thisObjectRectTransformPosition.x + ((widthPerElement + currentItemRectTransformSize.x) * currentElementIndex), thisObjectRectTransformPosition.y + ((widthPerElement + (currentItemRectTransformSize.y * -1)) * currentColumn));

            ++currentElementIndex;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
