using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSetting : UIOBJ.Image_Setting
{
    public ImageSetting(Image image, float pointX, float pointY, float sizeX, float sizeY) :
        base(image, pointX, pointY, sizeX, sizeY)
    { }
    public override Image function(Sprite sprite)
    {
        image.sprite = sprite;

        image.rectTransform.position = new Vector2(Screen.width / 2 * pointX, Screen.height / 2 * pointY);
        image.rectTransform.sizeDelta = new Vector2(Screen.width / 2 * sizeX, Screen.height / 2 * sizeY);

        return image;
    }

    public override Image function(Sprite sprite, bool horizontal, bool vertical, RectTransform content)
    {

        image.sprite = sprite;

        image.rectTransform.position = new Vector2(Screen.width / 2 * pointX, Screen.height / 2 * pointY);
        image.rectTransform.sizeDelta = new Vector2(Screen.width / 2 * sizeX, Screen.height / 2 * sizeY);

        ScrollRect scrollRect = image.gameObject.AddComponent<ScrollRect>();
        scrollRect.content = content;
        scrollRect.horizontal = horizontal;
        scrollRect.vertical = vertical;

        Mask mask = image.gameObject.AddComponent<Mask>();
        mask.showMaskGraphic = true;

        return image;
    }
}