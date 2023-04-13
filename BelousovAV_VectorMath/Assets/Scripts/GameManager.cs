using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
 
    public static int _countOfPoints = 0;

    private int _healthPlayerOne;
    private int _healthPlayerTwo;

    [SerializeField]
    private Text _textPoints;

   
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        UpdateGUI();
    }

    private void UpdateGUI()
    {
        _textPoints.text = "Количиство очков: " + _countOfPoints;
    }
}

public enum GameMode
{
    twoPlayers,
    OnePlayer,
    bonusLevel
}