using UnityEngine;

public class CashDesk : MonoBehaviour
{
    public Sprite sprite;
    private GameManager gameManager;
    public GameObject RecelptCanvas;
    bool isClick;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        if (!isClick)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
            gameManager.GameSequence++;
            isClick = true;
            RecelptCanvas.SetActive(true);
        }
    }
}
