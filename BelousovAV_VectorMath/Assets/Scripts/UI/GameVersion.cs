using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameVersion : MonoBehaviour
{

    private string _versionName = "ver:";
    private TMP_Text _versionNumber;

    private void Start()
    {
        _versionNumber = GetComponent<TMP_Text>();
        _versionNumber.text = _versionName + Application.version;
    }
}
