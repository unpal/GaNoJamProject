using TMPro;
using UnityEngine;
using UnityEngine.U2D;

public class GameManager : MonoBehaviour
{
    public int GameSequence;
    private CameraMove MoveCame;
    private Fruits_Sort Basket;
    public GameObject BasketSelectCanvasObj;
    public GameObject FruitsSelectCanvasObj;
    public GameObject DeliveryObj;
    public Sprite[] sprites;
    public GameObject MainWindowCanvas;
    public GameObject RecelptCanvas;
    void Start()
    {
        MoveCame = GameObject.Find("Main Camera").GetComponent<CameraMove>();
        Basket = GameObject.Find("Basket").GetComponent<Fruits_Sort>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickNextImage()
    {
        GameSequence++; 
        switch(GameSequence)
        {
            case 1:
                {
                    MoveCame.ImageType = 1;
                    MainWindowCanvas.SetActive(false);
                }
                break;
            case 3:
                {
                    MoveCame.ImageType = 2;
                    RecelptCanvas.SetActive(false);
                    GameSequence++;
                }
                break;
            case 5:
                {
                    for (int i = 0; i < Basket.PackingObject.Count; i++)
                    {
                        Basket.PackingObject[i].gameObject.SetActive(false);
                    }
                    Basket.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
                    BasketSelectCanvasObj.SetActive(true);
                    FruitsSelectCanvasObj.SetActive(false);
                }
                break;
            case 6:
                {
                    MoveCame.ImageType = 1;
                    DeliveryObj.SetActive(true);
                }
                break;

            default:
                break;
        }
        
    }
    public void OnClickSelectBasket(int index)
    {
        Basket.BasketNum = index;
        switch (Basket.BasketNum)
        {
            case 0:
                {
                    Basket.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
                }
                break;
            case 1:
                {
                    Basket.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
                }
                break;
            case 2:
                {
                    Basket.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
                }
                break;
            default:
                break;
        }
    }
    public void OnClickReceiptButton()
    {
        int ReceiptValue = Random.Range(0, 4);
        switch (ReceiptValue)
        {
            case 0:
                {

                }
                break;
            case 1:
                {

                }
                break;
            case 2:
                {

                }
                break;
            case 3:
                {

                }
                break;
                default:
                {

                }
                break;
        }
    }
}
