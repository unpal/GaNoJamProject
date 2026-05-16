using NUnit.Framework;
using System;
using UnityEditor.VersionControl;
using UnityEngine;

public class Delivery_HandOver : MonoBehaviour
{
    bool isDisapear;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isDisapear)
        {
            SpriteRenderer tempsprite = GetComponent<SpriteRenderer>();
            if (tempsprite.color.a > 0)
            {
                Color tempColor = tempsprite.color;
                tempColor.a -= 0.002f;
                tempsprite.color = tempColor;
                print("³»·Á°¡¿ê");
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("Trigger!!");
        if (collision == null) return;

        if (collision.CompareTag("Basket"))
        {
            Fruits_Sort Basket = collision.gameObject.GetComponent<Fruits_Sort>();
            if(!Basket.isDrag)
            {
                for(int i = 0; i < Basket.PackingObject.Count;i++)
                {
                    if (Basket.PackingObject[i])
                    {

                    }
                }
                Basket.gameObject.SetActive(false);
                isDisapear = true;
            }
        }
    }
}
