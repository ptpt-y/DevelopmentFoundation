﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBtn : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
