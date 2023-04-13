using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartBall : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabBall;

    [SerializeField]
    private GameObject _projectile;

    private void Update()
    {
        LaunchBall();
    }

    private void LaunchBall()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _projectile == null)
        {
                _projectile = Instantiate(_prefabBall, transform.position, transform.rotation) as GameObject;
        }
    }
}
