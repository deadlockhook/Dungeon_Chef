using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TipsPopup : MonoBehaviour
{

    public TextMeshProUGUI textBox;  // Reference to the TextMeshPro object
    public Image image;  // Reference to the Image that you want to resize

    public float paddingX = 10f;  // Padding for width (optional)
    public float paddingY = 10f;  // Padding for height (optional)

    void Start()
    {
        // Ensure references are assigned
        if (textBox == null || image == null)
        {
            Debug.LogError("Please assign both TextMeshPro and Image in the Inspector.");
            return;
        }

        SetText(textBox.text);
    }

    public void SetText(string newText)
    {
        textBox.text = newText;

        // Force the layout to update immediately
        LayoutRebuilder.ForceRebuildLayoutImmediate(textBox.rectTransform);

        // Adjust image size to fit the text size
        AdjustImageSize();
    }

    void AdjustImageSize()
    {
        // Get the preferred width and height of the text box
        float textWidth = textBox.preferredWidth * 2;
        float textHeight = textBox.preferredHeight* 2;

        // Adjust the size of the image (with padding)
        RectTransform imageRect = image.GetComponent<RectTransform>();

        // Set the image size based on text size, plus any padding
        imageRect.sizeDelta = new Vector2(textWidth + paddingX, textHeight + paddingY);

        // Optionally ensure the image is centered with respect to the text
        imageRect.anchoredPosition = new Vector2(0, 0);  // Adjust this as needed for your layout
    }
}

