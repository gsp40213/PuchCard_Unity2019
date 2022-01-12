using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonSetting : UIOBJ.ButtonSetting
{
    public ButtonSetting(Button button, float pointX, float pointY, float sizeX, float sizeY, UnityAction onClick) :
     base(button, pointX, pointY, sizeX, sizeY, onClick)
    { }

    public override Button function(Font font, FontStyle fontStyle, string message, TextAnchor textAnchor,
        Color color, int textSize)
    {
        button.transform.position = new Vector2(Screen.width / 2 * pointX, Screen.height / 2 * pointY);
        button.image.rectTransform.sizeDelta = new Vector2(Screen.width / 2 * sizeX, Screen.height / 2 * sizeY);

        text(font, fontStyle, message, textAnchor, color, textSize);
        button.onClick.AddListener(onClick);

        return button;
    }

    private Text text(Font font, FontStyle fontStyle, string message, TextAnchor textAnchor, Color color,
        int textSize)
    {
        Text text = button.transform.GetChild(0).GetComponent<Text>();
        text.font = font;
        text.fontStyle = fontStyle;
        text.text = message;
        text.alignment = textAnchor;
        text.color = color;
        text.fontSize = Screen.width / 2 / textSize;

        return text;
    }

    public void setInteracTable(bool sw)
    {
        button.interactable = sw;
    }

    public bool getIntercaTable()
    {
        return button.interactable;
    }
}
