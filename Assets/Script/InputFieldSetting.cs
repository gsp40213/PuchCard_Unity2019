using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldSetting : UIOBJ.InputField_Setting
{
    public InputFieldSetting(InputField inputField, float pointX, float pointY, float sizeX, float sizeY) :
        base(inputField, pointX, pointY, sizeX, sizeY)
    { }

    public override InputField function(Font font, FontStyle fontStyle, TextAnchor textAnchor,
        Color color, int textSize)
    {
        inputField.transform.position = new Vector2(Screen.width / 2 * pointX, Screen.height / 2 * pointY);
        inputField.image.rectTransform.sizeDelta = new Vector2(Screen.width / 2 * sizeX, Screen.height / 2 * sizeY);

        text(font, fontStyle, textAnchor, color, textSize);

        return inputField;
    }

    private Text text(Font font, FontStyle fontStyle, TextAnchor textAnchor, Color color, int textSize)
    {
        Text text = inputField.transform.GetChild(1).GetComponent<Text>();

        text.font = font;
        text.fontStyle = fontStyle;
        text.alignment = textAnchor;
        text.color = color;
        text.fontSize = Screen.width / 2 / textSize;

        return text;
    }

    public string getMessage()
    {
        return inputField.text;
    }

    public void setMessage(string message)
    {
        inputField.text = message;
    }
}