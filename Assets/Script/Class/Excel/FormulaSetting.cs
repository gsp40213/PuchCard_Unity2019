using System.IO;

public class FormulaSetting : ExcelClass.Formula
{
    public FormulaSetting(int year, int month, int staffNumber, int operAtingHours, string companyName, string unit, bool dayShift,
        bool night, bool bigNight) : base(year, month, staffNumber, operAtingHours, companyName, unit, dayShift, night, bigNight) { }

    // 檔案類別
    FileInfo fileInfo;

    // Excel 固定格式 (資料寫入縱)
    int dataExcelNum = 4;

    PresetSetting presetClass;

    public override void createClass()
    {
        presetClass = new PresetSetting(year, month, staffNumber, companyName, unit);
        presetClass.fixedClass();

        int checkExcelNum = dataExcelNum + staffNumber;
        int classStateNum = 0;

        string className1 = "D";
        string className2 = "E";
        string className3 = "N";

        int dayShiftAdd = 0;
        int nightAdd = 0;
        int bigNightAdd = 0;

        // 營業時數
        PresetSetting.WORKSHEET.Cells[checkExcelNum + 1, 1].Value = "營業時間 ( " + operAtingHours + "小時 )";
        PresetSetting.TABLE_COLOR(checkExcelNum + 1, 1, System.Drawing.Color.Red);
        PresetSetting.WORKSHEET.Cells[checkExcelNum + 1, 1].AutoFitColumns(50);

        // 狀態1: 3班都選擇(三班制)
        if (dayShift == true && night == true && bigNight == true)
        {
            // 白班
            for (int x = 2; x <= 6; x++)
            {
                classState(checkExcelNum, x, toggleMessage(dayShift, className1 + classTable(dayShiftAdd)), dayShiftAdd);
                dayShiftAdd += 1;
            }

            // 小夜班(晚班)
            for (int x = 7; x <= 11; x++)
            {
                classState(checkExcelNum, x, toggleMessage(night, className2 + classTable(nightAdd)), nightAdd);
                nightAdd += 1;
            }

            // 大夜班(夜班)
            for (int x = 12; x <= 16; x++)
            {
                classState(checkExcelNum, x, toggleMessage(bigNight, className3 + classTable(bigNightAdd)), bigNightAdd);
                bigNightAdd += 1;
            }

            classStateNum = 1;
        }

        // 狀態2: 2班都選擇 - 白班，晚班(二班制)
        if (dayShift == true && bigNight == true && night != true)
        {
            // 白班
            for (int x = 2; x <= 6; x++)
            {
                classState(checkExcelNum, x, toggleMessage(dayShift, className1 + classTable(dayShiftAdd)), dayShiftAdd);
                dayShiftAdd += 1;
            }

            // 大夜班(夜班)
            for (int x = 7; x <= 11; x++)
            {
                classState(checkExcelNum, x, toggleMessage(bigNight, className3 + classTable(bigNightAdd)), bigNightAdd);
                bigNightAdd += 1;
            }

            classStateNum = 2;
        }

        if (dayShift == true && night != true && bigNight != true)
        {
            // 白班
            for (int x = 2; x <= 6; x++)
            {
                classState(checkExcelNum, x, toggleMessage(dayShift, className1 + classTable(dayShiftAdd)), dayShiftAdd);
                dayShiftAdd += 1;
            }

            classStateNum = 3;
        }

        // 加班公式
        overtimeFormula(checkExcelNum, classStateNum);
    }

    // 加班公式
    void overtimeFormula(int checkExcelNum, int classStateNum)
    {
        for (int x = 0; x < staffNumber; x++)
        {
            // 加班
            PresetSetting.WORKSHEET.Cells[dataExcelNum + x, PresetSetting.GET_Data.Count + 3].Formula = formulaHorizontal(1, dataExcelNum + x, 2);
            PresetSetting.WORKSHEET.Cells[dataExcelNum + x, PresetSetting.GET_Data.Count + 2].Formula = formulaHorizontal(2, dataExcelNum + x, 2);
        }

        for (int x = 0; x < PresetSetting.GET_Data.Count; x++)
        {
            // 3班
            if (classStateNum == 1)
            {
                // 檢查營業時間
                PresetSetting.WORKSHEET.Cells[checkExcelNum + 1, x + 2].Formula = formula_vertical_openBusiness(checkExcelNum, x + 2, classStateNum);
                var cont = PresetSetting.WORKSHEET.ConditionalFormatting.AddGreaterThan(PresetSetting.WORKSHEET.Cells[checkExcelNum + 1, x + 2]);
                cont.Style.Font.Color.Color = System.Drawing.Color.Red;
                cont.Formula = operAtingHours.ToString();

                int dayShiftTable = 0;
                int nightTable = 0;
                int bigNightTable = 0;

                // D班含加班
                for (int i = 2; i <= 6; i++)
                {
                    PresetSetting.WORKSHEET.Cells[checkExcelNum + i, x + 2].Formula = formulaVerticalClassName(dataExcelNum, x + 2, "\"D"
                        + classTable(dayShiftTable) + "\"", "\"D" + classTable(dayShiftTable) + "\"", staffNumber);

                    dayShiftTable += 1;
                }

                // E班含加班
                for (int i = 7; i <= 11; i++)
                {
                    PresetSetting.WORKSHEET.Cells[checkExcelNum + i, x + 2].Formula = formulaVerticalClassName(dataExcelNum, x + 2, "\"E"
                        + classTable(nightTable) + "\"", "\"E" + classTable(nightTable) + "\"", staffNumber);

                    nightTable += 1;
                }

                // N班含加班
                for (int i = 12; i <= 16; i++)
                {
                    PresetSetting.WORKSHEET.Cells[checkExcelNum + i, x + 2].Formula = formulaVerticalClassName(dataExcelNum, x + 2, "\"N"
                        + classTable(bigNightTable) + "\"", "\"N" + classTable(bigNightTable) + "\"", staffNumber);

                    bigNightTable += 1;
                }

                // 畫線
                PresetSetting.EXCEL_STYLE(checkExcelNum + 1, 1, checkExcelNum + 16, PresetSetting.GET_Data.Count + 1);
            }

            // 2班
            if (classStateNum == 2)
            {
                // 檢查營業時間
                PresetSetting.WORKSHEET.Cells[checkExcelNum + 1, x + 2].Formula = formula_vertical_openBusiness(checkExcelNum, x + 2, classStateNum);
                var cont = PresetSetting.WORKSHEET.ConditionalFormatting.AddGreaterThan(PresetSetting.WORKSHEET.Cells[checkExcelNum + 1, x + 2]);
                cont.Style.Font.Color.Color = System.Drawing.Color.Red;
                cont.Formula = operAtingHours.ToString();

                int dayShiftTable = 0;
                int bigNightTable = 0;

                // D班含加班
                for (int i = 2; i <= 6; i++)
                {
                    PresetSetting.WORKSHEET.Cells[checkExcelNum + i, x + 2].Formula = formulaVerticalClassName(dataExcelNum, x + 2, "\"D"
                        + classTable(dayShiftTable) + "\"", "\"D" + classTable(dayShiftTable) + "\"", staffNumber);

                    dayShiftTable += 1;
                }

                // N班含加班
                for (int i = 7; i <= 11; i++)
                {
                    PresetSetting.WORKSHEET.Cells[checkExcelNum + i, x + 2].Formula = formulaVerticalClassName(dataExcelNum, x + 2, "\"N"
                        + classTable(bigNightTable) + "\"", "\"N" + classTable(bigNightTable) + "\"", staffNumber);

                    bigNightTable += 1;
                }

                // 畫線
                PresetSetting.EXCEL_STYLE(checkExcelNum + 1, 1, checkExcelNum + 11, PresetSetting.GET_Data.Count + 1);
            }

            if (classStateNum == 3)
            {
                // 檢查營業時間
                PresetSetting.WORKSHEET.Cells[checkExcelNum + 1, x + 2].Formula = formula_vertical_openBusiness(checkExcelNum, x + 2, classStateNum);
                var cont = PresetSetting.WORKSHEET.ConditionalFormatting.AddGreaterThan(PresetSetting.WORKSHEET.Cells[checkExcelNum + 1, x + 2]);
                cont.Style.Font.Color.Color = System.Drawing.Color.Red;
                cont.Formula = operAtingHours.ToString();

                int dayShiftTable = 0;

                // D班含加班
                for (int i = 2; i <= 6; i++)
                {
                    PresetSetting.WORKSHEET.Cells[checkExcelNum + i, x + 2].Formula = formulaVerticalClassName(dataExcelNum, x + 2, "\"D"
                        + classTable(dayShiftTable) + "\"", "\"D" + classTable(dayShiftTable) + "\"", staffNumber);

                    dayShiftTable += 1;
                }

                // 畫線
                PresetSetting.EXCEL_STYLE(checkExcelNum + 1, 1, checkExcelNum + 6, PresetSetting.GET_Data.Count + 1);
            }
        }
    }

    // 班別區分顏色
    void classState(int checkExcelNum, int frequency, string message, int addClassTable)
    {
        PresetSetting.WORKSHEET.Cells[checkExcelNum + frequency, 1].Value = message;

        if (addClassTable.Equals(0))
            PresetSetting.TABLE_COLOR(checkExcelNum + frequency, 1, System.Drawing.Color.Orange);
        else
            PresetSetting.TABLE_COLOR(checkExcelNum + frequency, 1, System.Drawing.Color.Yellow);
    }

    // toggle 布林為訊息
    string toggleMessage(bool toggleBool, string message)
    {
        return (toggleBool == true) ? message : "";
    }

    // 加班訊息表示
    string classTable(int table)
    {
        return (table.Equals(0)) ? "" : table.ToString();
    }


    // 公式: Excel 橫向
    string formulaHorizontal(int state, int rol, int col)
    {
        string result = "";

        // 加班狀態 
        for (int x = 0; x < PresetSetting.GET_Data.Count; x++)
        {
            if (state == 1)
            {
                string str = "IF(OR(" + PresetSetting.WORKSHEET.Cells[rol, col + x] + "= \"D1\"," + PresetSetting.WORKSHEET.Cells[rol, col + x] + "= \"E1\","
                    + PresetSetting.WORKSHEET.Cells[rol, col + x] + "= \"N1\"), 1) + IF(OR(" + PresetSetting.WORKSHEET.Cells[rol, col + x] + "= \"D2\","
                    + PresetSetting.WORKSHEET.Cells[rol, col + x] + "= \"E2\"," + PresetSetting.WORKSHEET.Cells[rol, col + x] + "= \"N2\"), 2) + IF(OR("
                    + PresetSetting.WORKSHEET.Cells[rol, col + x] + "= \"D3\"," + PresetSetting.WORKSHEET.Cells[rol, col + x] + "= \"E3\","
                    + PresetSetting.WORKSHEET.Cells[rol, col + x] + "= \"N3\"), 3) + IF(OR(" + PresetSetting.WORKSHEET.Cells[rol, col + x] + "= \"D4\","
                    + PresetSetting.WORKSHEET.Cells[rol, col + x] + "= \"E4\"," + PresetSetting.WORKSHEET.Cells[rol, col + x] + "= \"N4\"), 4) +";

                result += str;
            }

            // 假別
            if (state == 2)
            {
                string str = "IF(OR(" + PresetSetting.WORKSHEET.Cells[rol, col + x] + "=\"休\"," + PresetSetting.WORKSHEET.Cells[rol, col + x] + "=\"特\","
                    + PresetSetting.WORKSHEET.Cells[rol, col + x] + "=\"病\", " + PresetSetting.WORKSHEET.Cells[rol, col + x] + "=\"公\","
                    + PresetSetting.WORKSHEET.Cells[rol, col + x] + "=\"喪\"," + PresetSetting.WORKSHEET.Cells[rol, col + x] + "=\"婚\","
                    + PresetSetting.WORKSHEET.Cells[rol, col + x] + "=\"公病\"," + PresetSetting.WORKSHEET.Cells[rol, col + x] + "=\"事\","
                    + PresetSetting.WORKSHEET.Cells[rol, col + x] + "=\"災\",),1)+";

                result += str;
            }
        }

        result = result.Remove(result.LastIndexOf("+"), 1);

        return result;
    }

    // 公式 Excel 縱向(班別名稱)
    string formula_vertical_openBusiness(int rol, int col, int classState)
    {
        string result = "";

        string dayShiftResult = "";
        string nightResult = "";
        string bigNightResult = "";

        int dayShiftNum = 8;
        int nightNum = 8;
        int bigNightNum = 8;

        int dayShiftNum1 = 12;
        int bigNightNum1 = 12;

        // 3班制
        if (classState == 1)
        {
            // 白班
            for (int x = 2; x <= 6; x++)
            {
                dayShiftResult += "IF(" + PresetSetting.WORKSHEET.Cells[rol + x, col] + "<> 0, " + dayShiftNum + ",0) +";
                dayShiftNum += 1;
            }

            // 小夜(晚班)
            for (int x = 7; x <= 11; x++)
            {
                nightResult += "IF(" + PresetSetting.WORKSHEET.Cells[rol + x, col] + "<> 0, " + nightNum + ",0) +";
                nightNum += 1;
            }

            // 大夜(夜班)
            for (int x = 12; x <= 16; x++)
            {
                bigNightResult += "IF(" + PresetSetting.WORKSHEET.Cells[rol + x, col] + "<> 0," + bigNightNum + " ,0) +";
                bigNightNum += 1;
            }

            result = dayShiftResult + nightResult + bigNightResult;
        }

        // 兩班制
        if (classState == 2)
        {
            // 白班
            for (int x = 2; x <= 6; x++)
            {
                dayShiftResult += "IF(" + PresetSetting.WORKSHEET.Cells[rol + x, col] + "<> 0," + dayShiftNum1 + " ,0) +";
                dayShiftNum1 += 1;
            }

            // 大夜(夜班)
            for (int x = 7; x <= 11; x++)
            {
                bigNightResult += "IF(" + PresetSetting.WORKSHEET.Cells[rol + x, col] + "<> 0," + bigNightNum1 + " ,0) +";
                bigNightNum1 += 1;
            }

            result = dayShiftResult + bigNightResult;
        }

        // 一班制
        if (classState == 3)
        {

            // 白斑
            for (int x = 2; x <= 6; x++)
            {
                dayShiftResult += "IF(" + PresetSetting.WORKSHEET.Cells[rol + x, col] + "<> 0," + dayShiftNum + ",0) +";
                dayShiftNum += 1;
            }

            result = dayShiftResult;

        }

        result = result.Remove(result.LastIndexOf("+"), 1);

        return result;
    }

    // 公式: Excel 縱向(班別名稱)
    string formulaVerticalClassName(int rol, int col, string className, string className2, int staffNumber)
    {
        string result = "";

        for (int x = 0; x < staffNumber; x++)
        {
            string str = "IF(OR(" + PresetSetting.WORKSHEET.Cells[rol + x, col] + "=" + className + ", +"
                + PresetSetting.WORKSHEET.Cells[rol + x, col] + "=" + className2 + "), 1, 0) + ";
            result += str;
        }

        result = result.Remove(result.LastIndexOf("+"), 1);

        return result;
    }

    public override void excelSave()
    {
        PresetSetting.EXCEL_STYLE(1, 1, staffNumber + 3, PresetSetting.GET_Data.Count + 3);
        PresetSetting.EXCEL_PACKAGE.Save();
    }
}