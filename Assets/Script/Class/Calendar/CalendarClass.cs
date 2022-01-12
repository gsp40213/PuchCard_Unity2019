using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  CalendarClass
{
    public int year, month, day;
    public CalendarClass(int year, int month, int day)
    {
        this.year = year;
        this.month = month;
        this.day = day;
    }

    public abstract List<Data_date> calendarData();
    public abstract int dayNumber();
}

// 站存用
public class Data_date
{
    public string year;
    public string month;
    public string day;
    public string week;

    public Data_date(string year, string month, string day, string week)
    {
        this.year = year;
        this.month = month;
        this.day = day;
        this.week = week;
    }
}
