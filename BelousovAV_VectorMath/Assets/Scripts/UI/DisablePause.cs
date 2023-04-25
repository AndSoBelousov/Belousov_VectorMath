using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePause : MonoBehaviour
{
    public void ResumeTime()
    {
        Time.timeScale = 1.0f;
    }

}
