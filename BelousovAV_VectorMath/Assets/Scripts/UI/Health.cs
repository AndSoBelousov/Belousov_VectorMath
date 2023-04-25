using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : GameManager
{
    [SerializeField]
    private GameObject[] _hearts;
    private int _deltaHealth;
    private void Start()
    {
        for(int i = 0; i <= (_numberOfLives -1); i++)
        {
            _hearts[i].SetActive(true);
        }
        _deltaHealth = GameManager._numberOfLives;
    }

    private void FixedUpdate()
    {
        if(_deltaHealth > GameManager._numberOfLives)
        {
            _hearts[_deltaHealth - 1].SetActive(false);
            _deltaHealth--;
        }
    }
}
