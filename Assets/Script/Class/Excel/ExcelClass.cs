using System.IO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;

public abstract class ExcelClass
{
    public abstract class Preset
    {
        protected int year, month, staffNumber;
        protected string companyName, unit;

        public Preset(int year, int month, int staffNumber, string companyName, string unit)
        {
            this.year = year;
            this.month = month;
            this.staffNumber = staffNumber;

            this.companyName = companyName;
            this.unit = unit;
        }

        public abstract void fixedClass();
        public abstract void excelSave();
    }

    public abstract class Formula
    {
        protected int year, month, staffNumber, operAtingHours;
        protected string companyName, unit;
        protected bool dayShift, night, bigNight;

        public Formula(int year, int month, int staffNumber, int operAtingHours, string companyName, string unit, bool dayShift,
            bool night, bool bigNight)
        {
            this.year = year;
            this.month = month;
            this.staffNumber = staffNumber;

            this.companyName = companyName;
            this.unit = unit;

            this.dayShift = dayShift;
            this.night = night;
            this.bigNight = bigNight;
        }

        public abstract void createClass();
        public abstract void excelSave();
    }
}
