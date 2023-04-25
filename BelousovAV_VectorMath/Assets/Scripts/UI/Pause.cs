using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject _pausePanel;

    [SerializeField]
    private GameObject _optionsPanel;

   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickEscape();
        }
    }
    public void OnClickEscape()
    {
        if(_pausePanel.activeInHierarchy == false)
        {
            OnPause();
        }
        else if(_pausePanel.activeInHierarchy == true && _optionsPanel.activeInHierarchy == true)
        {
            OnPause();
        }
        else if (_pausePanel.activeInHierarchy == true && _optionsPanel.activeInHierarchy == false)
        {
            OnPlay();
        }
    }

    public void OnPlay()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void OnPause()
    {
        _optionsPanel.SetActive(false);
        _pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void OnOptions()
    {
        _optionsPanel.SetActive(true);
    }
}
