using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PresetClassOnClick : OnClick
{
    public void onClick()
    {
        SceneManager.LoadScene("PresetClass");        
    }
}
