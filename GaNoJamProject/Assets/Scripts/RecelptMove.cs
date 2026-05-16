using UnityEngine;

public class RecelptMove : MonoBehaviour
{
    private GameManager gamemanager;
    public GameObject MovePivot;
    public float MoveBaskTime;
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager.GameSequence == 2)
        {
            Vector3 Velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, MovePivot.transform.position, ref Velocity, MoveBaskTime * 3);
        }
    }
}
