using TMPro;
using UnityEngine;

public class CashDesk : MonoBehaviour
{
    public Sprite sprite;
    private GameManager gameManager;
    public GameObject RecelptCanvas;
    public TextMeshProUGUI RecelptText;
    public TextMeshProUGUI RecelptCheckText;
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
            int ReceiptValue = Random.Range(0, 3);
            gameManager.RecelptNum = ReceiptValue;
            switch (ReceiptValue)
            {
                case 0:
                    {
                        RecelptText.text = "배달 요청사항: \r\n저는 어떤 무엇이든지 중립을 지킵니다. \r\n그러니 빨간과일 두종류와 파란과일 두종류를 \r\n각각 3개씩 담아주세요. \r\n\r\n아니, 2개? 아니다. \r\n그냥 3개씩 담아주세요.";
                        RecelptCheckText.text = "배달 요청사항: \r\n저는 어떤 무엇이든지 중립을 지킵니다. \r\n그러니 빨간과일 두종류와 파란과일 두종류를 \r\n각각 3개씩 담아주세요. \r\n\r\n아니, 2개? 아니다. \r\n그냥 3개씩 담아주세요.";
                    }
                    break;
                case 1:
                    {
                        RecelptText.text = "배달 요청사항: \r\n사장님!!! 저 지금 시간 없으니까\r\n대충 아무거나 빨리빨리 줘요!\r\n\r\n근데 빨간건 빼고!!!\r\n달달하고 노란 것 위주로!!\r\n바구니 터지게 여러종류로 꽉꽉 채워줘요!\r\n대충 딱 7개만 주면 되나?!";
                        RecelptCheckText.text = "배달 요청사항: \r\n사장님!!! 저 지금 시간 없으니까\r\n대충 아무거나 빨리빨리 줘요!\r\n\r\n근데 빨간건 빼고!!!\r\n달달하고 노란 것 위주로!!\r\n바구니 터지게 여러종류로 꽉꽉 채워줘요!\r\n대충 딱 7개만 주면 되나?!";
                    }
                    break;
                case 2:
                    {
                        RecelptText.text = "배달 요청사항: \r\n\"사장님~ 제 피드 컨셉이 '오렌지 스타'라\r\n바구니를 주황색 과일로 꽉꽉! 채워야 해요!\r\n\r\n근데 제가 제일 좋아하는 복숭아는\r\n핑크색이어도 무조건 꼭 껴주셔야 하구요!\r\n대신 칙칙하고 어두운 파란색 과일들은\r\n주황빛을 망치니까 절대 넣지 마세요!\r\n\r\n대충 다 합쳐서 딱 5개면\r\n사진 찍었을 때 구도가 완벽할 것 같네요.\"";
                        RecelptCheckText.text = "배달 요청사항: \r\n\"사장님~ 제 피드 컨셉이 '오렌지 스타'라\r\n바구니를 주황색 과일로 꽉꽉! 채워야 해요!\r\n\r\n근데 제가 제일 좋아하는 복숭아는\r\n핑크색이어도 무조건 꼭 껴주셔야 하구요!\r\n대신 칙칙하고 어두운 파란색 과일들은\r\n주황빛을 망치니까 절대 넣지 마세요!\r\n\r\n대충 다 합쳐서 딱 5개면\r\n사진 찍었을 때 구도가 완벽할 것 같네요.\"";
                    }
                    break;
                default:
                    {

                    }
                    break;
            }
        }
    }
}
