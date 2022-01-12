using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitOnClick : OnClick
{
    public void onClick()
    {
        Application.Quit();
    }   
}
