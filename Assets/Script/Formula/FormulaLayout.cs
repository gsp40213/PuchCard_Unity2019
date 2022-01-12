using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FormulaLayout : MonoBehaviour
{
    // 背景
    public Image breakGroud_Image;
    ImageSetting breakGroud;

    // 年月
    public Text year_Text, month_Text;
    TextSetting year, month;
    public InputField year_InputField, month_InputField;
    InputFieldSetting yearInput, monthInput;

    // 公司與單位
    public Text companyNameMessage_Text, unitMessage_Text;
    TextSetting companyNameMessage, unitMessage;
    public InputField companyNameInput_InputField, unitMessageInput_InputField;
    InputFieldSetting companyNameInput, unitMessageInput;

    // 員工數量
    public Text staffNum_Text;
    TextSetting staffNum;
    public InputField staffNumInput_InputField;
    InputFieldSetting staffNumInput;

    // 營業時間上限
    public Text operationHorMaxMessage_Text, operationHorRemindMessage_Text;
    TextSetting operationHorMaxMessage, operationHorRemindMessage;
    public InputField operationHorMaxInput_Input;
    InputFieldSetting operationHorMaxInput;

    // 班別制
    public Text classNameNumMessage_Text;
    TextSetting classNameNumMessage;
    public Toggle dayShift_Toggle, night_Toggle, bigNight_Toggle;
    ToggleSetting dayShift, night, bigNight;
    public Sprite toggleBreakGroud;

    public Button input_Button, cancel_Button, quit_Button;
    ButtonSetting input, cancel, quit;

    public Text errorMessage_Text;
    TextSetting errorMessage;

    public Font font;

    public int textSize;

    private void Start()
    {
        breakGroud = new ImageSetting(breakGroud_Image, 1.24f, 1, 1.28f, 1.56f);
        breakGroud.function(null);

        year = new TextSetting(year_Text, 0.75f, 1.58f, 0.22f, 0.1f);
        year.function(font, FontStyle.Normal, "年分(西元)", TextAnchor.MiddleLeft, Color.white, 23);
        yearInput = new InputFieldSetting(year_InputField, 0.95f, 1.6f, 0.18f, 0.13f);
        yearInput.function(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black, 30);

        month = new TextSetting(month_Text, 1.15f, 1.58f, 0.1f, 0.1f);
        month.function(font, FontStyle.Normal, "月份", TextAnchor.MiddleLeft, Color.white, 23);
        monthInput = new InputFieldSetting(month_InputField, 1.3f, 1.6f, 0.18f, 0.13f);
        monthInput.function(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black, 30);

        companyNameMessage = new TextSetting(companyNameMessage_Text, 0.73f, 1.3f, 0.18f, 0.1f);
        companyNameMessage.function(font, FontStyle.Normal, "公司名稱", TextAnchor.MiddleLeft, Color.white, 23);
        companyNameInput = new InputFieldSetting(companyNameInput_InputField, 1, 1.32f, 0.34f, 0.13f);
        companyNameInput.function(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black, 30);

        unitMessage = new TextSetting(unitMessage_Text, 1.26f, 1.31f, 0.1f, 0.1f);
        unitMessage.function(font, FontStyle.Normal, "單位", TextAnchor.MiddleLeft, Color.white, 23);
        unitMessageInput = new InputFieldSetting(unitMessageInput_InputField, 1.48f, 1.32f, 0.34f, 0.13f);
        unitMessageInput.function(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black, 30);

        staffNum = new TextSetting(staffNum_Text, 0.73f, 0.77f, 0.18f, 0.1f);
        staffNum.function(font, FontStyle.Normal, "員工數量", TextAnchor.MiddleLeft, Color.white, 23);
        staffNumInput = new InputFieldSetting(staffNumInput_InputField, 0.92f, 0.78f, 0.18f, 0.13f);
        staffNumInput.function(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black, 30);

        operationHorMaxMessage = new TextSetting(operationHorMaxMessage_Text, 0.9f, 1.05f, 0.52f, 0.1f);
        operationHorMaxMessage.function(font, FontStyle.Normal, "營業時間", TextAnchor.MiddleLeft, Color.white, 23);
        operationHorMaxInput = new InputFieldSetting(operationHorMaxInput_Input, 1f, 1.06f, 0.18f, 0.13f);
        operationHorMaxInput.function(font, FontStyle.Normal, TextAnchor.MiddleLeft, Color.black, 30);
        operationHorRemindMessage = new TextSetting(operationHorRemindMessage_Text, 1.55f, 1.06f, 0.8f, 0.1f);
        operationHorRemindMessage.function(font, FontStyle.Normal, "注意: 營業時間勿超過當天24小時", TextAnchor.MiddleLeft, Color.red, 23);

        classNameNumMessage = new TextSetting(classNameNumMessage_Text, 1.12f, 0.77f, 0.14f, 0.1f);
        classNameNumMessage.function(font, FontStyle.Normal, "班別", TextAnchor.MiddleLeft, Color.white, 23);
        dayShift = new ToggleSetting(dayShift_Toggle, toggleBreakGroud, 1.33f, 0.44f);
        dayShift.function(font, FontStyle.Normal, "白班(D)", TextAnchor.MiddleLeft, Color.white, 34);
        dayShift.setBool(false);
        night = new ToggleSetting(night_Toggle, toggleBreakGroud, 1.55f, 0.44f);
        night.function(font, FontStyle.Normal, "晚班(E)", TextAnchor.MiddleLeft, Color.white, 34);
        night.setBool(false);
        bigNight = new ToggleSetting(bigNight_Toggle, toggleBreakGroud, 1.78f, 0.44f);
        bigNight.function(font, FontStyle.Normal, "夜班(N)", TextAnchor.MiddleLeft, Color.white, 34);
        bigNight.setBool(false);

        input = new ButtonSetting(input_Button, 1.34f, 0.43f, 0.25f, 0.21f, new InputOnClick().onClick);
        input.function(font, FontStyle.Normal, "輸入完成", TextAnchor.MiddleCenter, Color.black, 28);
        cancel = new ButtonSetting(cancel_Button, 1.65f, 0.43f, 0.25f, 0.21f, new CancelOnClick().onClick);
        cancel.function(font, FontStyle.Normal, "回上一頁", TextAnchor.MiddleCenter, Color.black, 28);
        quit = new ButtonSetting(quit_Button, 0.25f, 0.32f, 0.3f, 0.21f, new ExitOnClick().onClick);
        quit.function(font, FontStyle.Normal, "離開程式", TextAnchor.MiddleCenter, Color.black, 28);       
    }


    private void FixedUpdate()
    {
        errorMessage = new TextSetting(errorMessage_Text, 2.1f, 1.6f, error().Length * 0.1f, 0.1f);
        errorMessage.function(font, FontStyle.Normal, error(), TextAnchor.MiddleLeft, Color.red, 27);
        input.setInteracTable(inputButtonActive());

        try
        {
            FormulaClassData.YEAR_MESSAGE = Int32.Parse(yearInput.getMessage());
            FormulaClassData.MONTH_MESSAGE = Int32.Parse(monthInput.getMessage());
            FormulaClassData.STAFFNUMBER_MESSAGE = Int32.Parse(staffNumInput.getMessage());
            FormulaClassData.OPERATINGHOURS_MESSAGE = Int32.Parse(operationHorMaxInput.getMessage());

            FormulaClassData.COMPANYNAME_MESSAGE = companyNameInput.getMessage();
            FormulaClassData.UNIT_MESSAGE = unitMessageInput.getMessage();

            FormulaClassData.DAYSHIFT_MESSAGE = dayShift.getBool();
            FormulaClassData.NIGHT_MESSAGE = night.getBool();
            FormulaClassData.BIGNIGHT_MESSAGE = bigNight.getBool();

        }
        catch { }

    }

    // 按鈕激活
    private bool inputButtonActive()
    {
        return (yearInput.getMessage() != "" && companyNameInput.getMessage() != "" && monthInput.getMessage() != "" &&
            unitMessageInput.getMessage() != "" && operationHorMaxInput.getMessage() != "" && staffNumInput.getMessage() != "" &&
            dayShift.getBool() == true && errorMessage.getMessage() == " ") ? true : false;
    }

    // 錯誤訊息
    private string error()
    {
        string str = "";

        try
        {
            str =  (Int32.Parse(monthInput.getMessage()) == 0 || Int32.Parse(monthInput.getMessage()) > 12 ||
                Int32.Parse(operationHorMaxInput.getMessage()) > 24) ? "錯誤: 月份或營業時數錯誤" :
                (night.getBool() == true && bigNight.getBool() != true) ? "錯誤: 2班制只能白班與夜班" : " ";

        }catch{ }

        return str;
    }

    ~FormulaLayout()
    {
        FormulaClassData.YEAR_MESSAGE = 0;
        FormulaClassData.MONTH_MESSAGE = 0;
        FormulaClassData.STAFFNUMBER_MESSAGE = 0;
        FormulaClassData.OPERATINGHOURS_MESSAGE = 0;

        FormulaClassData.COMPANYNAME_MESSAGE = "";
        FormulaClassData.UNIT_MESSAGE = "";

        FormulaClassData.DAYSHIFT_MESSAGE = false;
        FormulaClassData.NIGHT_MESSAGE = false;
        FormulaClassData.BIGNIGHT_MESSAGE = false;
    }
}