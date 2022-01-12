using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSetting : UIOBJ.Text_Setting
{
    public TextSetting(Text text, float pointX, float pointY, float sizeX, float sizeY) :
        base(text, pointX, pointY, sizeX, sizeY)
    { }

    public TextSetting(Text text, float sizeX, float sizeY) : base(text, sizeX, sizeY) { }

    public override Text function(Font font, FontStyle fontStyle, string message, TextAnchor textAnchor, Color color, int textSize)
    {
        text.font = font;
        text.fontStyle = fontStyle;
        text.text = message;
        text.alignment = textAnchor;
        text.color = color;
        text.fontSize = Screen.width / 2 / textSize;

        text.transform.position = new Vector2(Screen.width / 2 * pointX, Screen.height / 2 * pointY);
        text.rectTransform.sizeDelta = new Vector2(Screen.width / 2 * sizeX, Screen.height / 2 * sizeY);

        return text;
    }

    public override Text function(int fontsize, Vector2 pivot)
    {
        text.horizontalOverflow = HorizontalWrapMode.Overflow;
        text.verticalOverflow = VerticalWrapMode.Truncate;

        text.fontSize = Screen.width / 2 / fontsize;

        RectTransform rectTransform = text.GetComponent<RectTransform>();
        rectTransform.pivot = pivot;

        text.rectTransform.sizeDelta = new Vector2(Screen.width / 2 * sizeX, Screen.height / 2 * sizeY);


        return text;
    }

    public void setMessage(string message)
    {
        text.text = message;
    }

    public string getMessage()
    {
        return text.text;
    }
}