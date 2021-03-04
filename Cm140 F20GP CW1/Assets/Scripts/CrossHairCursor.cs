using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairCursor : MonoBehaviour
{

    void Awake()
    {
        //disables windows cursor on game start
        Cursor.visible = false; 
    }

    void Update()
    {
        //sets crosshair on mouse position
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPos;
    }
}
