using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
public class TipsPopup : MonoBehaviour
{

    private TMP_Text text; 

    void Start()
    {
        text = transform.Find("Text").GetComponent<TMP_Text>();
        SetText(text.text);

        SetText("Lolol\n" +
            "LOLFLASDGA\n" +
            "alfdjlsdjf\n" +
            "dfdfadfasf");
    }

    public void SetText(string newText)
    {
        text.text = newText;
  //      LayoutRebuilder.ForceRebuildLayoutImmediate(text.rectTransform);

    }
}

