using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresetLayout : MonoBehaviour
{
    public Image breakGroud_Image;
    ImageSetting breakGroud;

    public Text year_Text, month_Text;
    TextSetting year, month;
    public InputField yearInput_InputField, monthInput_InputField;
    InputFieldSetting yearInput, monthInput;

    public Text companyName_Text, unit_Text;
    TextSetting companyName, unit;
    public InputField companyNameInput_InputField, unitInput_InputField;
    InputFieldSetting companyNameInput, unitInput;

    public Text staffNum_Text;
    TextSetting staffNum;
    public InputField staffNumInput_InputField;
    InputFieldSetting staffNumInput;

    public Text error_Text;
    TextSetting error;

    // 按鈕
    public Button input_btn, cancel_btn, quit_btn;
    ButtonSetting PresetInput, cancel, quit;

    public Font font;

    private void Start()
    {
        breakGroud = new ImageSetting(breakGroud_Image, 1.24f, 1, 1.28f, 1.56f);
        breakGroud.function(null);

        year = new TextSetting(year_Text, 0.75f, 1.58f, 0.22f, 0.1f);
        year.function(font, FontStyle.Normal, "年分(西元)", TextAnchor.MiddleLeft, Color.white, 22);
        yearInput = new InputFieldSetting(yearInput_InputField, 0.95f, 1.6f, 0.18f, 0.13f);
        yearInput.function(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black, 30);

        month = new TextSetting(month_Text, 1.15f, 1.58f, 0.1f, 0.1f);
        month.function(font, FontStyle.Normal, "月份", TextAnchor.MiddleLeft, Color.white, 22);
        monthInput = new InputFieldSetting(monthInput_InputField, 1.3f, 1.6f, 0.18f, 0.13f);
        monthInput.function(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black, 30);

        companyName = new TextSetting(companyName_Text, 0.73f, 1.3f, 0.2f, 0.1f);
        companyName.function(font, FontStyle.Normal, "公司名稱", TextAnchor.MiddleLeft, Color.white, 22);
        companyNameInput = new InputFieldSetting(companyNameInput_InputField, 1, 1.32f, 0.34f, 0.13f);
        companyNameInput.function(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black, 30);

        unit = new TextSetting(unit_Text, 1.26f, 1.31f, 0.1f, 0.1f);
        unit.function(font, FontStyle.Normal, "單位", TextAnchor.MiddleLeft, Color.white, 22);
        unitInput = new InputFieldSetting(unitInput_InputField, 1.48f, 1.32f, 0.34f, 0.13f);
        unitInput.function(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black, 30);

        staffNum = new TextSetting(staffNum_Text, 0.73f, 1, 0.2f, 0.1f);
        staffNum.function(font, FontStyle.Normal, "員工數量", TextAnchor.MiddleLeft, Color.white, 22);
        staffNumInput = new InputFieldSetting(staffNumInput_InputField, 0.92f, 1.01f, 0.18f, 0.13f);
        staffNumInput.function(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black, 30);

        PresetInput = new ButtonSetting(input_btn, 1.34f, 0.43f, 0.25f, 0.21f, new PresetInputOnClick().onClick);
        PresetInput.function(font, FontStyle.Normal, "輸入完成", TextAnchor.MiddleCenter, Color.black, 28);

        cancel = new ButtonSetting(cancel_btn, 1.65f, 0.43f, 0.25f, 0.21f, new CancelOnClick().onClick);
        cancel.function(font, FontStyle.Normal, "回上一頁", TextAnchor.MiddleCenter, Color.black, 28);

        quit = new ButtonSetting(quit_btn, 0.25f, 0.3f, 0.3f, 0.21f, new ExitOnClick().onClick);
        quit.function(font, FontStyle.Normal, "離開程式", TextAnchor.MiddleCenter, Color.black, 28);
    }

    private void FixedUpdate()
    {
        error = new TextSetting(error_Text, 1.95f, 1.6f, errorMessage().Length * 0.1f, 0.1f);
        error.function(font, FontStyle.Normal, errorMessage(), TextAnchor.MiddleLeft, Color.red, 27);
        PresetInput.setInteracTable(inputButtonActive());

        try
        {
            PresetClassData.YEAR_MESSAGE = Int32.Parse(yearInput.getMessage());
            PresetClassData.MONTH_MESSAGE = Int32.Parse(monthInput.getMessage());
            PresetClassData.STAFFNUMBER_MESSAGE = Int32.Parse(staffNumInput.getMessage());

            PresetClassData.COMPANYNAME_MESSAGE = companyNameInput.getMessage();
            PresetClassData.UNIT_MESSAGE = unitInput.getMessage();
        }
        catch { }


    }


    private bool inputButtonActive()
    {
        return (yearInput.getMessage() != "" && monthInput.getMessage() != "" && companyNameInput.getMessage() != "" &&
            unitInput.getMessage() != "" && staffNumInput.getMessage() != "" && errorMessage() != "") ? true : false;
    }

    private string errorMessage()
    {
        string str = "";

        try
        {
            str = (Int32.Parse(monthInput.getMessage()) == 0 || Int32.Parse(monthInput.getMessage()) > 12) ? "錯誤: 月份格式錯誤" : " ";
        }
        catch { }

        return str;
    }
}
