using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetInputOnClick : OnClick
{
    PresetSetting presetSetting;

    public void onClick()
    {
        presetSetting = new PresetSetting(PresetClassData.YEAR_MESSAGE, PresetClassData.MONTH_MESSAGE,
            PresetClassData.STAFFNUMBER_MESSAGE, PresetClassData.COMPANYNAME_MESSAGE, PresetClassData.UNIT_MESSAGE);

        presetSetting.fixedClass();
        presetSetting.excelSave();
    }
}
