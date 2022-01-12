using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSetting : UIOBJ.Toggle_Setting
{
    public ToggleSetting(Toggle toggle, Sprite breakGroud, float pointX, float pointY):
        base (toggle, breakGroud, pointX, pointY) { }

    public override Toggle function(Font font, FontStyle fontStyle, string message, TextAnchor textAnchor, Color color, int textSize)
    {
        toggle.transform.position = new Vector2(Screen.width / 2 * pointX, Screen.width / 2 * pointY);
        breakGroud();
        text(font, fontStyle, message, textAnchor, color, textSize);

        return toggle;
    }

    public void setBool(bool active)
    {
        toggle.isOn = active;
    }

    public bool getBool()
    {
        return toggle.isOn;
    }

    private Image breakGroud()
    {
        Image image = toggle.transform.GetChild(0).GetComponent<Image>();
        image.sprite = breakGourd;

        return image;
    }

    private Text text(Font font, FontStyle fontStyle, string message, TextAnchor textAnchor, Color color, int textSize)
    {
        Text text = toggle.transform.GetChild(1).GetComponent<Text>();
        
        text.font = font;
        text.fontStyle = fontStyle;
        text.text = message;
        text.alignment = textAnchor;
        text.color = color;
        text.fontSize = Screen.width / 2 / textSize;

        return text;
    }
}
