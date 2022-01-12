using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOnClick : OnClick
{

    FormulaSetting formulaSetting;

    public void onClick()
    {
        Debug.Log(FormulaClassData.YEAR_MESSAGE);

        formulaSetting = new FormulaSetting(FormulaClassData.YEAR_MESSAGE, FormulaClassData.MONTH_MESSAGE,
            FormulaClassData.STAFFNUMBER_MESSAGE, FormulaClassData.OPERATINGHOURS_MESSAGE, FormulaClassData.COMPANYNAME_MESSAGE,
            FormulaClassData.UNIT_MESSAGE, FormulaClassData.DAYSHIFT_MESSAGE, FormulaClassData.NIGHT_MESSAGE, 
            FormulaClassData.BIGNIGHT_MESSAGE);

        formulaSetting.createClass();
        formulaSetting.excelSave();
    }
}
