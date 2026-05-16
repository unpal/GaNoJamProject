using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Fruits_Sort : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created\\

    float distance = 10;
    public bool isDrag = false;
    private GameObject MainCamera;
    private GameManager gamemanager;
    public List<GameObject> PackingObject = new List<GameObject>();
    public List<Vector3> PackingObjectOffSet = new List<Vector3>();
    public float UpBaskDistan;
    public float DownBaskDistan;
    public float MoveBaskTime;
    public GameObject MovePivotDown;
    public GameObject MovePivotUp;
    public GameObject SelectMovePivot;
    public GameObject MovePivot;
    public GameObject DeliveryPivot;
    public int BasketNum;
    void Start()
    {
        isDrag = false;
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        BasketNum = 0;
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
        else if (gamemanager.GameSequence == 6)
        {
            Vector3 Velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, DeliveryPivot.transform.position, ref Velocity, MoveBaskTime * 3);
        }
        else if (gamemanager.GameSequence == 5)
        {
            Vector3 Velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, SelectMovePivot.transform.position, ref Velocity, MoveBaskTime * 3);
        }
        else
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector3 mousePosition = new Vector3(mousePos.x, mousePos.y, distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            float Distan = Vector3.Distance(objPosition, MovePivotDown.transform.position);
            Vector3 tempPosition;
            Vector3 Velocity = Vector3.zero;
            if (Distan < UpBaskDistan)
            {
                tempPosition = new Vector3(MovePivotUp.transform.position.x, MovePivotUp.transform.position.y, MovePivotUp.transform.position.z);
            }
            else if (Distan > DownBaskDistan)
            {
                tempPosition = new Vector3(MovePivotDown.transform.position.x, MovePivotDown.transform.position.y, MovePivotDown.transform.position.z);
            }
            else
            {
                tempPosition = transform.position;
            }
            transform.position = Vector3.SmoothDamp(transform.position, tempPosition, ref Velocity, MoveBaskTime);

            if (PackingObject != null)
            {
                for (int i = 0; i < PackingObject.Count; i++)
                {
                    if (PackingObject[i] != null)
                    {
                        Vector3 PackingObjectPosition = new Vector3(transform.position.x + PackingObjectOffSet[i].x, transform.position.y + PackingObjectOffSet[i].y, transform.position.z);

                        PackingObject[i].transform.position = PackingObjectPosition;
                    }
                }
            }
        }

    }
    private void OnMouseUp()
    {
        if(gamemanager.GameSequence == 6)
            isDrag = false;

    }

    private void OnMouseDown()
    {
        if (gamemanager.GameSequence == 6)
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
