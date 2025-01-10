using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GeneralPopup : MonoBehaviour
{
    // Start is called before the first frame update
    private IngameUIManager ingameUIManager;
    private List<ImageWithState> popupImages;
    public int popupElementSize = 50;
    private int widthPerElement = 5;
    public int maxElementsPerRow = 3;
    public int maxColumns = 3;

    public Sprite TestSpriteActive;
    public Sprite TestSpriteInactive;

    private int rowSize = 0;
    private int columnSize = 0;
    void Start()
    {
        rowSize = ((popupElementSize + widthPerElement)) * maxElementsPerRow;
        columnSize = ((popupElementSize + widthPerElement)) * maxColumns;
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
        RectTransform backgroundImageOutlineRectTransform = transform.Find("BGOutline").GetComponent<RectTransform>();
        TextMeshProUGUI tmpText = backgroundImageRectTransform.transform.Find("Title").GetComponent<TextMeshProUGUI>();
       
        Button exitButton = backgroundImageRectTransform.transform.Find("ExitButton").GetComponent<Button>();
      
        Button actionButton = backgroundImageRectTransform.transform.Find("ActionButton").GetComponent<Button>();
        TextMeshProUGUI actionButtonTmpText = actionButton.transform.Find("Title").GetComponent<TextMeshProUGUI>();

        backgroundImageRectTransform.sizeDelta = new Vector2(rowSize, (columnSize + (tmpText.fontSize * 2)) + (actionButtonTmpText.fontSize + 5));
        backgroundImageRectTransform.anchoredPosition = new Vector2(0, -(actionButtonTmpText.fontSize + 5));
        backgroundImageRectTransform.pivot = new Vector2(0, 0);
        backgroundImageRectTransform.anchorMin = new Vector2(0, 0); 
        backgroundImageRectTransform.anchorMax = new Vector2(0, 0);

        backgroundImageOutlineRectTransform.sizeDelta = new Vector2(rowSize + 4, ((columnSize + (tmpText.fontSize * 2)) + 4) + (actionButtonTmpText.fontSize + 5));
        backgroundImageOutlineRectTransform.anchoredPosition = new Vector2(-3, -2 - (actionButtonTmpText.fontSize + 5));
        backgroundImageOutlineRectTransform.pivot = new Vector2(0, 0);
        backgroundImageOutlineRectTransform.anchorMin = new Vector2(0, 0);
        backgroundImageOutlineRectTransform.anchorMax = new Vector2(0, 0);

        exitButton.onClick.AddListener(OnExitButton);
    }

    public void AddActionButtonListener(UnityAction callBack)
    {
        RectTransform backgroundImageRectTransform = transform.Find("BG").GetComponent<RectTransform>();
        Button actionButton = backgroundImageRectTransform.transform.Find("ActionButton").GetComponent<Button>();
        actionButton.onClick.AddListener(callBack);
    }

    public void PushElement(Sprite activeSprite,Sprite inactiveSprite)
    {
        ImageWithState imageObj = ingameUIManager.CreateImageWithStateEx(this.gameObject.transform, activeSprite, inactiveSprite, false, new Vector2(popupElementSize, popupElementSize));

        if (imageObj)
        {
            popupImages.Add(imageObj);
            SetupPositions();
        }
    }
    void RemoveElement(ImageWithState state)
    {
        popupImages.Remove(state);
        SetupPositions();
    }
    private void SetupPositions()
    {
        int currentElementInRow = 0;
        int currentColumn = 0;

        int currentElementIndex = 0;

        Vector2 thisObjectRectTransformPosition =new Vector2(widthPerElement / 2.0F, widthPerElement / 2.0F);

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
            currentItemRectTransform.pivot = new Vector2(0, 0);
            currentItemRectTransform.anchorMin = new Vector2(0, 0); 
            currentItemRectTransform.anchorMax = new Vector2(0, 0); 
            currentItemRectTransform.anchoredPosition = new Vector2(thisObjectRectTransformPosition.x + ((widthPerElement + currentItemRectTransformSize.x) * currentElementIndex), thisObjectRectTransformPosition.y + ((widthPerElement + (currentItemRectTransformSize.y )) * currentColumn));

            ++currentElementIndex;
        }
    }
    private void OnExitButton()
    {
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
