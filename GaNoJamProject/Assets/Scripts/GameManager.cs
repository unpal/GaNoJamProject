using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int GameSequence;
    private CameraMove MoveCame;
    private Fruits_Sort Basket;
    public GameObject BasketSelectCanvasObj;
    public GameObject BasketSelectNextCanvasObj;
    public GameObject FruitsSelectCanvasObj;
    public GameObject DeliveryObj;
    public Sprite[] sprites;
    public GameObject MainWindowCanvas;
    public GameObject RecelptCanvas;
    public GameObject RecelptCheckCanvas;
    public GameObject ResultCanvas;
    public Sprite SmartPhonesprites;
    public GameObject SmartPhoneButton;
    public int RecelptNum;
    public int StarValue;
    public Sprite[] starSprites;
    public GameObject StarIamge;
    public TextMeshProUGUI ResultText;
    public TextMeshProUGUI ResultPriceText;
    public CashDesk cashdesk;
    public Sprite CashDeskSprite;
    public int Price;
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
        switch (GameSequence)
        {
            case 1:
                {
                    MoveCame.ImageType = 1;
                    MainWindowCanvas.SetActive(false);
                    StartCoroutine(NewOrder());

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
                    BasketSelectNextCanvasObj.SetActive(true);
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

    }
    public void OnClickReciptCheckButton()
    {
        RecelptCheckCanvas.SetActive(true);
    }
    public void OnClickReciptCheckBackButton()
    {
        RecelptCheckCanvas.SetActive(false);
    }
    public void OnClickPhoneCheckButton()
    {
        SmartPhoneButton.GetComponent<Image>().sprite = SmartPhonesprites;
        if (StarValue > 0 && StarValue < 5)
            StarIamge.GetComponent<Image>().sprite = starSprites[StarValue];
        else
            StarIamge.GetComponent<Image>().sprite = starSprites[0];
        ResultCanvas.SetActive(true);
        switch (RecelptNum)
        {
            case 0:
                {
                    switch (StarValue)
                    {
                        case 0:
                            {
                                ResultText.text = "당신은 중립적이지 않군요, 잘 알겠습니다.";
                            }
                            break;
                        case 1:
                            {
                                ResultText.text = "주문을 제대로 이해하신 게 맞습니까? 중립의 가치가 훼손된 바구니를 보니 상당히 실망스럽군요.";
                            }
                            break;
                        case 2:
                            {
                                ResultText.text = "중립을 지키려 노력은 하셨으나 결과가 아쉽습니다. 어느 한 쪽으로도 기울어지지 않았으면 했는데요.";
                            }
                            break;
                        case 3:
                            {
                                ResultText.text = "매우 훌륭합니다, 하지만 미세하게 균형이 깨져 있군요. 제 마음이 완전히 편안해지지는 않지만, 그래도 괜찮습니다.";
                            }
                            break;
                        case 4:
                            {
                                ResultText.text = "완벽한 대칭입니다. 빨강과 파랑의 개수가\r\n정확히 일치하는군요. 마음이 편안해집니다.\r\n진정한 중립의 가치를 아시는 분이네요.";
                            }
                            break;
                        default:
                            break;
                    }
                }
                break;
            case 1:
                {
                    switch (StarValue)
                    {
                        case 0:
                            {
                                ResultText.text = "당신은 제 말을 하나도 안 들었군요, 몇대맞을래.";
                            }
                            break;
                        case 1:
                            {
                                ResultText.text = "주문을 제대로 이해하신 게 맞습니까? 엉망진창인 바구니를 보니 화가 치밀어 오르는군요.";
                            }
                            break;
                        case 2:
                            {
                                ResultText.text = "바구니를 채우려 노력을 하신건 보이나, 결과가 아쉽습니다. 제 취향에 딱 맞진 않군요.";
                            }
                            break;
                        case 3:
                            {
                                ResultText.text = "매우 훌륭합니다, 하지만 제가 원하지 않는 게 섞여 있거나 종류가 좀 심심하네요. 그래도 이정도면 만족합니다.";
                            }
                            break;
                        case 4:
                            {
                                ResultText.text = "아주 좋습니다! 여러 종류가 골고루 들어있고 아주 달달하네요. 속도도 마음에 듭니다!";
                            }
                            break;
                        default:
                            break;
                    }
                }
                break;
            case 2:
                switch (StarValue)
                {
                    case 0:
                        {
                            ResultText.text = "감성을 전혀 모르는 우매한 가게네요. 색 조합이 엉망이라 사진 다 버렸습니다.";
                        }
                        break;
                    case 1:
                        {
                            ResultText.text = "제 컨셉을 전혀 이해 못 하신 것 같아요. 과일 개수도 안 맞고 구도가 안 살아서 올리기 어렵겠네요.";
                        }
                        break;
                    case 2:
                        {
                            ResultText.text = "피드에 올리기엔 색감이 좀 애매하네요. 복숭아랑 주황색 과일 비중을 좀 더 맞춰주셨으면 좋았을 텐데요.";
                        }
                        break;
                    case 3:
                        {
                            ResultText.text = "사진은 예쁘게 잘 나오네요! 근데 제가 생각한 주황 느낌보다는 살짝 아쉬워요. 그래도 이 정도면 피드에 올리기 좋네요.";
                        }
                        break;
                    case 4:
                        {
                            ResultText.text = "피드에 올렸더니 다들 어디 과일가게냐고 DM문의가 폭발하네요! 복숭아랑 주황색 조합이 아주 인스타 저격이에요.";
                        }
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        ResultPriceText.text = "판매 가격 : " + Price.ToString() + "￦";
        if (StarValue == 4)
            ResultPriceText.color = Color.yellow;
        else
            ResultPriceText.color = Color.red;
    }
    public void OnClickPhoneCheckBackButton()
    {
        ResultCanvas.SetActive(false);
    }
    IEnumerator NewOrder()
    {
        yield return new WaitForSeconds(3);
        cashdesk.isNewOrder = true;
        cashdesk.GetComponent<SpriteRenderer>().sprite = CashDeskSprite;
    }
    public void OnClickReStartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
