using UnityEngine;

public class RecelptMove : MonoBehaviour
{
    private GameManager gamemanager;
    public GameObject MovePivot;
    public float MoveBaskTime;
    public Vector3 FirstVec;

    private void Awake()
    {
        FirstVec = gameObject.transform.position;
    }
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnEnable()
    {
        gameObject.transform.position = FirstVec;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 Velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, MovePivot.transform.position, ref Velocity, MoveBaskTime * 3);
    }
}
