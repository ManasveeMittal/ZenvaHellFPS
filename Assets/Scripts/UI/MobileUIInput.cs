using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DitzeGames.MobileJoystick;

public class MobileUIInput : MonoBehaviour
{
    protected TouchField TouchField;

    void Start()
    {
        TouchField = FindObjectOfType<TouchField>();
    }

    void Update()
    {
        TouchFieldInput();
    }

    void TouchFieldInput()
    {
        transform.Rotate(Vector3.up, TouchField.TouchDist.x);
        transform.Rotate(Vector3.left, TouchField.TouchDist.y);
    }
}
