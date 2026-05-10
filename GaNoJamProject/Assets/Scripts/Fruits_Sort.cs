using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Fruits_Sort : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created\\

    float distance = 10;
    public List<GameObject> PackingObject = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDrag()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 mousePosition = new Vector3(mousePos.x, mousePos.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
        if (PackingObject != null)
        {
            for(int i = 0; i < PackingObject.Count; i++)
            {
                Vector3 PackingObjectPosition = new Vector3(objPosition.x - PackingObject[i].transform.position.x, objPosition.y - PackingObject[i].transform.position.y, objPosition.z);
                PackingObject[i].transform.position = PackingObjectPosition;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("트리거 충돌");
        if (collision == null) return;

        if (collision.CompareTag("Fruits"))
        {
            MoveFruits move = collision.gameObject.GetComponent<MoveFruits>();
            if (move != null)
            {
                if (move.isDrag == false && move.isPacking == false)
                {
                    move.isPacking = true;
                    PackingObject.Add(move.gameObject);
                }
            }
        }
    }
}
