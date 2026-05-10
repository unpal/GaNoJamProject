using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveFruits : MonoBehaviour
{
    float distance = 10;
    public bool isDrag = false;
    public bool isPacking;

    private void Start()
    {
        isPacking = false;
    }

    void Update()
    {
    }
    void OnMouseDrag()
    {
        if (!isPacking)
        {
            //print("Drag!!");
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector3 mousePosition = new Vector3(mousePos.x, mousePos.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
            isDrag = true;
        }
    }
    private void OnMouseUp()
    {
        isDrag = false;
    }
}
