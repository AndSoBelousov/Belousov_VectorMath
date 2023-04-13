using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(5, 30)]
    private float _firstPlayerSpeed = 15f;

    private Rigidbody _rb;

    [SerializeField] private WhichInput _whichInputHorizontal;
    [SerializeField] private WhichInput _whichInputVertical;

  

    private Dictionary<WhichInput, string> _input = new Dictionary<WhichInput, string>()
    {
        {WhichInput.FirstPlayerVertical, "Vertical" },
        {WhichInput.FirstPlayerHorizontal, "Horizontal" },
        {WhichInput.SecondPlayerVertical, "VerticalTwo" },
        {WhichInput.SecondPlayerHorizontal, "HorizontalTwo" }
    };
    
    private float _deltaHorizontal;
    private float _deltaVertical;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovementLogic();
    }


    private void MovementLogic()
        {
            _deltaHorizontal = Input.GetAxis(_input[_whichInputHorizontal]) ;
            _deltaVertical = Input.GetAxis(_input[_whichInputVertical]) ;

            // инвертируем ввод для второго игрока
            if(_input[_whichInputHorizontal] == _input[WhichInput.SecondPlayerHorizontal])
            {
                _deltaHorizontal = -_deltaHorizontal;
            }

            Vector3 movement = new Vector3(_deltaHorizontal, _deltaVertical, 0);
            _rb.AddForce(movement * _firstPlayerSpeed);
    }

}
public enum WhichInput
{
    FirstPlayerHorizontal,
    FirstPlayerVertical,
    SecondPlayerHorizontal,
    SecondPlayerVertical
}
