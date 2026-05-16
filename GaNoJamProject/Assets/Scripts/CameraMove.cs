using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject FruitsChoiceMain;
    public GameObject MainImage;
    public GameObject MainTitle;
    public int ImageType;
    private Vector3 velocity = Vector3.zero;
    public float speed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 tempPosition;
        switch (ImageType)
        {
            case 0:
                {
                    tempPosition = MainTitle.transform.position;
                    tempPosition.z = transform.position.z;
                }
                break;
            case 1:
                {
                    tempPosition = MainImage.transform.position;
                    tempPosition.z = transform.position.z;


                }
                break;
            case 2:
                {
                    tempPosition = FruitsChoiceMain.transform.position;
                    tempPosition.z = transform.position.z;
                }
                break;
            default:
                {
                    tempPosition = MainImage.transform.position;
                    tempPosition.z = transform.position.z;
                }
                break;
        }
       transform.position = Vector3.SmoothDamp(gameObject.transform.position, tempPosition, ref velocity, speed);
    }
}
