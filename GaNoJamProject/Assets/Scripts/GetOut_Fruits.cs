using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GetOut_Fruits : MonoBehaviour
{

    public GameObject Fruit;
    MoveFruits movefruits;
    public GameManager gamemanager;
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        if (gamemanager.GameSequence == 4)
        {
            GameObject game = Instantiate(Fruit);
            game.transform.position = transform.position;
            MoveFruits Move = game.gameObject.GetComponent<MoveFruits>();
            if (Move != null)
            {
                Move.isDrag = true;
            }
        }
    }

}
