using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FormulaClassOnClick : OnClick
{
    public void onClick()
    {
        SceneManager.LoadScene("FormulaClass");
        // Application.LoadLevel("FormulaClass");
    }
}
