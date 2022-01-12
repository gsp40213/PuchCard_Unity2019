using System.IO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;

public class PresetSetting : ExcelClass.Preset
{
    public PresetSetting (int year, int month, int staffNumber, string companyName, string unit) :
        base (year, month, staffNumber, companyName, unit) { }

    // 建立資料位置
    private string folderPath = @"D:\班表\";
    private string filePath;

    // 檔案
    FileInfo fileInfo;
    // 行事曆
    GetCalender getCalender;

    // excel 組件
    public static ExcelPackage EXCEL_PACKAGE;
    public static ExcelWorksheet WORKSHEET;

    // Excel 固定格式 (年、職位、天、資料寫入縱)
    int companyNameYear = 1;
    int positionNumber = 2;
    int dayExcelNuber = 3;
    int dataExcelNum = 4;

    public static List<Data_date> GET_Data = new List<Data_date>();

    public override void fixedClass()
    {
        getCalender = new GetCalender(year, month, 1);

        GET_Data.Clear();
        GET_Data = getCalender.calendarData();

        if (!Directory.Exists(folderPath + @"\" + unit))
            Directory.CreateDirectory(folderPath + @"\" + unit);

        // 判斷檔案是否存在
        if (fileExist(unit, year, month))
        {
            fileInfo.Delete();
            fileInfo = new FileInfo(filePath);
        }

        EXCEL_PACKAGE = new ExcelPackage(fileInfo);
        WORKSHEET = EXCEL_PACKAGE.Workbook.Worksheets.Add(getCalender.calendarData()[0].month  + "月");

        // 寫入公司名稱
        WORKSHEET.Cells[companyNameYear, 1].Value = GET_Data[0].year + "年" + GET_Data[0].month + "月 " + companyName + " (" + "單位: " + unit + ")";
        WORKSHEET.Cells[companyNameYear, 1, 1, GET_Data.Count + 3].Merge = true;

        // 寫入部分(單位)
        WORKSHEET.Cells[positionNumber, 1].Value = unit;
        WORKSHEET.Cells[positionNumber, 1, positionNumber, GET_Data.Count + 3].Merge = true;

        // 表格上色
        TABLE_COLOR(positionNumber, 1, Color.Yellow);

        foreach (var dayweekData in GET_Data)
        {
            WORKSHEET.Cells[dayExcelNuber, 1].Value = "員工";
            // 天與週次
            WORKSHEET.Cells[dayExcelNuber, Int32.Parse(dayweekData.day) + 1].Value = dayweekData.week + dayweekData.day;

            //　休假
            WORKSHEET.Cells[dayExcelNuber, Int32.Parse(dayweekData.day) + 2].Value = "休假";
            // 表格上色
            TABLE_COLOR(dayExcelNuber, GET_Data.Count + 2, Color.Red);

            //加班
            WORKSHEET.Cells[dayExcelNuber, Int32.Parse(dayweekData.day) + 3].Value = "加班";

            // 輸入員工姓名
            for (int x = 0; x < staffNumber; x++)
                WORKSHEET.Cells[dataExcelNum + x, 1].Value = "輸入姓名";

            // 自動調整距離
            WORKSHEET.Cells[WORKSHEET.Dimension.Address].AutoFitColumns();
        }

    }

    // 判斷檔案是否存在
    bool fileExist(string unit, int year, int month)
    {
        filePath = folderPath + @"\" + unit + @"\" + year.ToString() + "年" + month.ToString() + "月" + ".xlsx";
        fileInfo = new FileInfo(filePath);

        bool fileExist = fileInfo.Exists;

        return fileExist;
    }

    // 表格顏色
    public static void TABLE_COLOR(int fromRow, int fromCol, Color color)
    {
        WORKSHEET.Cells[fromRow, fromCol].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        WORKSHEET.Cells[fromRow, fromCol].Style.Fill.BackgroundColor.SetColor(color);
    }

    public override void excelSave()
    {
        EXCEL_STYLE(1, 1, staffNumber + 3, GET_Data.Count + 3);
        EXCEL_PACKAGE.Save();
    }

    public static void EXCEL_STYLE(int fromRow, int fromCol, int toRow, int toCol)
    {
        // 字形
        WORKSHEET.Cells.Style.Font.Name = "標楷體";
        // 文字大小
        WORKSHEET.Cells.Style.Font.Size = 14;
        // 水平置中
        WORKSHEET.Cells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        // 垂直中
        WORKSHEET.Cells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
        // 表格框線
        WORKSHEET.Cells[fromRow, fromCol, toRow, toCol].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
        WORKSHEET.Cells[fromRow, fromCol, toRow, toCol].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
        WORKSHEET.Cells[fromRow, fromCol, toRow, toCol].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
        WORKSHEET.Cells[fromRow, fromCol, toRow, toCol].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
    }
}
