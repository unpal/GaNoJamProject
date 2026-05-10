using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Fruits_Sort : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created\\

    float distance = 10;
    bool isDrag = false;
    public List<GameObject> PackingObject = new List<GameObject>();
    public List<Vector3> PackingObjectOffSet = new List<Vector3>();
    void Start()
    {
        isDrag = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(isDrag)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector3 mousePosition = new Vector3(mousePos.x, mousePos.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
            if (PackingObject != null)
            {
                for (int i = 0; i < PackingObject.Count; i++)
                {
                    if (PackingObject[i] != null)
                    {
                        Vector3 PackingObjectPosition = new Vector3(objPosition.x + PackingObjectOffSet[i].x, objPosition.y + PackingObjectOffSet[i].y, objPosition.z);

                        PackingObject[i].transform.position = PackingObjectPosition;
                    }
                }
            }
        }
    }
    void OnMouseDrag()
    {

    }
    private void OnMouseUp()
    {
        isDrag = false;

    }

    private void OnMouseDown()
    {
        isDrag = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;

        if (collision.CompareTag("Fruits"))
        {
            MoveFruits move = collision.gameObject.GetComponent<MoveFruits>();
            if (move != null)
            {
                move.isPacking = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Fruits"))
        {
            MoveFruits move = collision.gameObject.GetComponent<MoveFruits>();
            if (move != null)
            {
                move.isPacking = false;
            }
        }
    }
}
