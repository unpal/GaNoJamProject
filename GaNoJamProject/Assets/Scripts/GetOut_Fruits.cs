using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GetOut_Fruits : MonoBehaviour
{

    public GameObject Fruit;
    MoveFruits movefruits;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        GameObject game = Instantiate(Fruit);
        game.transform.position = transform.position;
        MoveFruits Move = game.gameObject.GetComponent<MoveFruits>();
        if(Move != null)
        {
            Move.isDrag = true;
        }
    }

}
