using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CancelOnClick : OnClick
{
    public void onClick()
    {
        SceneManager.LoadScene("Main");
    }
}
