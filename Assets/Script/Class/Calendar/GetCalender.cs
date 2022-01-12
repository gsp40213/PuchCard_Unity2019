using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCalender : CalendarClass
{
    public GetCalender(int year, int month, int day) : base (year, month, day) { }

    DateTime dateTime;

    public override List<Data_date> calendarData()
    {
        List<Data_date> classExcels = new List<Data_date>();
        classExcels.Clear();

        for(int i = 1; i <= DateTime.DaysInMonth(dateTime.Year, dateTime.Month); i++)
        {
            dateTime = new DateTime(year, month, i);

            classExcels.Add(new Data_date(yearConversion(dateTime.Year).ToString(), dateTime.Month.ToString(), i.ToString(),
                weekEngToChin(dateTime.DayOfWeek.ToString())));
        }

        return classExcels;
    }

    public override int dayNumber()
    {
        int dayNum = 0;

        for (int x = 1; x <= DateTime.DaysInMonth(dateTime.Year, dateTime.Month); x++)
            dayNum = x;

        return dayNum;
    }

    // 西元轉民國(公式)
    int yearConversion(int inVid)
    {
        return inVid - 1911;
    }

    // 取得當月日期天數
    string weekEngToChin(string dayOfWeek)
    {
        string chinWeek = "";

        if (dayOfWeek.ToString().Equals("Monday"))
            chinWeek = "一";
        if (dayOfWeek.ToString().Equals("Tuesday"))
            chinWeek = "二";
        if (dayOfWeek.ToString().Equals("Wednesday"))
            chinWeek = "三";
        if (dayOfWeek.ToString().Equals("Thursday"))
            chinWeek = "四";
        if (dayOfWeek.ToString().Equals("Friday"))
            chinWeek = "五";
        if (dayOfWeek.ToString().Equals("Saturday"))
            chinWeek = "六";
        if (dayOfWeek.ToString().Equals("Sunday"))
            chinWeek = "日";

        return chinWeek;
    }
}
