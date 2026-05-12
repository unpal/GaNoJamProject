using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveFruits : MonoBehaviour
{
    float distance = 10;
    public bool isDrag = false;
    public bool isPacking;
    public GameObject Basket;

    private void Start()
    {
        isPacking = false;
        Basket = GameObject.FindGameObjectWithTag("Basket");
    }

    void Update()
    {
        //if(isPacking)
        //{
        //    if (Basket != null)
        //    {
        //        Vector3 tempPosition = new Vector3(Basket.transform.position.x - transform.position.x, Basket.transform.position.y - transform.position.y, Basket.transform.position.z);
        //        transform.position = tempPosition; 
        //    }
        //}

        if (isDrag)
        {
            //print("Drag!!");
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector3 mousePosition = new Vector3(mousePos.x, mousePos.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
        if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            if (!isPacking)
                Destroy(gameObject);
            else
            {
                if(Basket != null)
                {
                    if (isDrag)
                    {
                        Fruits_Sort tempfruits = Basket.GetComponent<Fruits_Sort>();
                        tempfruits.PackingObject.Add(gameObject);
                        tempfruits.PackingObjectOffSet.Add(gameObject.transform.position - Basket.transform.position);
                        isDrag = false;
                    }
                }
            }
        }
    }
    //void OnMouseDrag()
    //{

    //}

    //private void OnMouseDown()
    //{
    //}
    //private void OnMouseUp()
    //{
    //}
}
