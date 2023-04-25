using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int _countOfPoints = 0;
    public const int _maxOfHealth = 10;
    [SerializeField, Range(1, _maxOfHealth)]
    public static int _numberOfLives = 10;
   
}

