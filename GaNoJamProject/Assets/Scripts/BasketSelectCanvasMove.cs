using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasketSelectCanvasMove : MonoBehaviour
{
    float distance = 10;
    public float UpBaskDistan;
    public float DownBaskDistan;
    public float MoveBaskTime;
    public GameObject MovePivotDown;
    public GameObject MovePivotUp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         Vector2 mousePos = Mouse.current.position.ReadValue();
         Vector3 mousePosition = new Vector3(mousePos.x, mousePos.y, distance);
         Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
         float Distan = objPosition.y - MovePivotDown.transform.position.y;
        if (Distan < 0)
            Distan *= -1;
         //float Distan = Vector3.Distance(objPosition, MovePivotDown.transform.position);
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
    }
}
