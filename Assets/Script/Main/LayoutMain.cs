using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutMain : MonoBehaviour
{
    public Button createClass_btn;
    ButtonSetting createClass;

    public Button exit_btn;
    ButtonSetting exit;

    public Button formulaClass_btn;
    ButtonSetting formulaClass;

    public Image instructionBackGroud_imag;
    ImageSetting instructionBackGroud;

    public Text message_text;
    TextSetting message;

    public Font font;

    private void Start()
    {
        createClass = new ButtonSetting(createClass_btn, 0.25f, 1.6f, 0.3f, 0.21f, new PresetClassOnClick().onClick);
        createClass.function(font, FontStyle.Normal, "預設班表", TextAnchor.MiddleCenter, Color.black, 28);

        formulaClass = new ButtonSetting(formulaClass_btn, 0.25f, 1.32f, 0.3f, 0.21f, new FormulaClassOnClick().onClick);
        formulaClass.function(font, FontStyle.Normal, "計算班表", TextAnchor.MiddleCenter, Color.black, 28);

        exit = new ButtonSetting(exit_btn, 0.25f, 0.3f, 0.3f, 0.21f, new ExitOnClick().onClick);
        exit.function(font, FontStyle.Normal, "關閉程式", TextAnchor.MiddleCenter, Color.black, 28);

        instructionBackGroud = new ImageSetting(instructionBackGroud_imag, 1.24f, 1, 1.28f, 1.76f);
        instructionBackGroud.function(null, false, true, message_text.rectTransform);

        message = new TextSetting(message_text, 0, 0.5f);
        message.function(26, new Vector2(0.5f, 1));
        message.setMessage(message_content());
    }

    string message_content()
    {
        string str = "\n 注意事項: \n\n" +
            "  本系統會自動建立檔案至D槽底下，建立班表資料夾 \n" +
            "  每個檔案名稱: 使用者設定年份與月份 (xlsx檔案) \n" +
            "    ※預設班表: 沒有任何公式計算。 \n" +
            "    ※公式班表: \n" +
            "        * 班別輸入: D 白班、E 晚班 N 夜班 \n" +
            "        * 假別輸入: 休、特、病、公、喪、婚、公病、事、災 \n" +
            "        * 加班顯示: D4/4D: 白班加4小時，也可以輸入小寫 \n" +
            "        * 當天營業時段只提供每班8小時與12小時檢查 \n";

        return str;
    }
}
