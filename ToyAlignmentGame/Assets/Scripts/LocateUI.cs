using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocateUI : MonoBehaviour
{
    public enum PositionEnum{ Bottom, Top, Right, Left, BottomRight, BottomLeft, TopRight, TopLeft }
    public float widthRatio=0.1f, heightRatio=0.1f;
    public PositionEnum posType = PositionEnum.Bottom;
    public float fontSizeRatio = 0.08f;

    private RectTransform rectTransform;
    private TMP_Text childText;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        childText = GetComponentInChildren<TMP_Text>();

        rectTransform.sizeDelta = new Vector2(Screen.width * widthRatio, Screen.height * heightRatio);

        double posX=0, posY=0;
        rectTransform.anchoredPosition = new Vector2(0, -(Screen.height / 2 - rectTransform.sizeDelta.y / 2));

        switch(posType){
            case PositionEnum.Bottom:
            posY = -(Screen.height / 2 - rectTransform.sizeDelta.y / 2);
            break;
            case PositionEnum.Top:
            posY = (Screen.height / 2 - rectTransform.sizeDelta.y / 2);
            break;
            case PositionEnum.Right:
            posX = (Screen.width / 2 - rectTransform.sizeDelta.x / 2);
            break;
            case PositionEnum.Left:
            posX = -(Screen.width / 2 - rectTransform.sizeDelta.x / 2);
            break;
            case PositionEnum.BottomRight:
            posY = -(Screen.height / 2 - rectTransform.sizeDelta.y / 2);
            posX = (Screen.width / 2 - rectTransform.sizeDelta.x / 2);
            break;
            case PositionEnum.BottomLeft:
            posY = -(Screen.height / 2 - rectTransform.sizeDelta.y / 2);
            posX = -(Screen.width / 2 - rectTransform.sizeDelta.x / 2);
            break;
            case PositionEnum.TopRight:
            posY = (Screen.height / 2 - rectTransform.sizeDelta.y / 2);
            posX = (Screen.width / 2 - rectTransform.sizeDelta.x / 2);
            break;
            case PositionEnum.TopLeft:
            posY = (Screen.height / 2 - rectTransform.sizeDelta.y / 2);
            posX = -(Screen.width / 2 - rectTransform.sizeDelta.x / 2);
            break;
        }
        rectTransform.anchoredPosition = new Vector2((float)posX, (float)posY);

        if(childText){
            childText.rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x * 0.9f, rectTransform.sizeDelta.y * 0.9f);
            childText.rectTransform.anchoredPosition=Vector2.zero;
            childText.fontSize = Screen.height * fontSizeRatio;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
