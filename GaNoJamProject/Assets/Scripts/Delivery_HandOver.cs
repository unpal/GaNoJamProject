using NUnit.Framework;
using System;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class Delivery_HandOver : MonoBehaviour
{
    bool isDisapear;
    public GameObject SmartPhoneCanvas;
    public TextMeshProUGUI ResultText;
    public GameManager gameManager;
    public int AppleNum;
    public bool isApple;
    public int BananaNum;
    public bool isBanana;
    public int BlueberryNum;
    public bool isBlueberry;
    public int GrapeNum;
    public bool isGrape;
    public int KoreanMelonNum;
    public bool isKoreanMelon;
    public int LemonNum;
    public bool isLemon;
    public int MangoNum;
    public bool isMango;
    public int OrangeNum;
    public bool isOrange;
    public int PeachNum;
    public bool isPeach;
    public int PersimmonNum;
    public bool isPersimmon;
    public int PomegranateNum;
    public bool isPomegranate;
    public int StrawberryNum;
    public bool isStrawberry;
    public int TomatoNum;
    public bool isTomato;
    public int FruitsNum;
    public bool isNoRedOrBlue;
    public bool isRed;
    public int YellowNum;
    public int AllFruitsNum;
    public bool isBlue;
    public int OrangeColorNum;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDisapear)
        {
            SpriteRenderer tempsprite = GetComponent<SpriteRenderer>();
            if (tempsprite.color.a > 0)
            {
                Color tempColor = tempsprite.color;
                tempColor.a -= 0.002f;
                tempsprite.color = tempColor;
                print("³»·Á°¡¿ê");
            }
            else
            {
                SmartPhoneCanvas.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("Trigger!!");
        if (collision == null) return;

        if (collision.CompareTag("Basket"))
        {
            Fruits_Sort Basket = collision.gameObject.GetComponent<Fruits_Sort>();
            if(!Basket.isDrag)
            {
                for(int i = 0; i < Basket.PackingObject.Count;i++)
                {
                    if (Basket.PackingObject[i])
                    {
                        switch(Basket.PackingObject[i].name)
                        {
                            case "Apple(Clone)":
                                {
                                    AppleNum++;
                                    if(!isApple)
                                    {
                                        FruitsNum++;
                                    }
                                    isApple = true;
                                    isRed = true;
                                }
                                break;
                            case "Banana(Clone)":
                                {
                                    BananaNum++;
                                    if (!isBanana)
                                    {
                                        FruitsNum++;
                                    }
                                    isBanana = true;
                                    isNoRedOrBlue = true;
                                }
                                break;
                            case "Blueberry(Clone)":
                                {
                                    BlueberryNum++;
                                    if (!isBlueberry)
                                    {
                                        FruitsNum++;
                                    }
                                    isBlueberry = true;
                                    isBlue = true;
                                }
                                break;
                            case "Grape(Clone)":
                                {
                                    GrapeNum++;
                                    if (!isGrape)
                                    {
                                        FruitsNum++;
                                    }
                                    isGrape = true;
                                    isBlue = true;
                                }
                                break;
                            case "KoreanMelon(Clone)":
                                {
                                    KoreanMelonNum++;
                                    if (!isKoreanMelon)
                                    {
                                        FruitsNum++;
                                    }
                                    isKoreanMelon = true;
                                    isNoRedOrBlue = true;
                                }
                                break;
                            case "Lemon(Clone)":
                                {
                                    LemonNum++;
                                    if (!isLemon)
                                    {
                                        FruitsNum++;
                                    }
                                    isLemon = true;
                                    isNoRedOrBlue = true;
                                }
                                break;
                            case "Mango(Clone)":
                                {
                                    MangoNum++;
                                    if (!isMango)
                                    {
                                        FruitsNum++;
                                    }
                                    isMango = true;
                                    isNoRedOrBlue = true;
                                }
                                break;
                            case "Orange(Clone)":
                                {
                                    OrangeNum++;
                                    if (!isOrange)
                                    {
                                        FruitsNum++;
                                    }
                                    isOrange = true;
                                    isNoRedOrBlue = true;
                                }
                                break;
                            case "Peach(Clone)":
                                {
                                    PeachNum++;
                                    if (!isPeach)
                                    {
                                        FruitsNum++;
                                    }
                                    isPeach = true;
                                    isNoRedOrBlue = true;
                                }
                                break;
                            case "Persimmon(Clone)":
                                {
                                    PersimmonNum++;
                                    if (!isPersimmon)
                                    {
                                        FruitsNum++;
                                    }
                                    isPersimmon = true;
                                    isNoRedOrBlue = true;
                                }
                                break;
                            case "Pomegranate(Clone)":
                                {
                                    PomegranateNum++;
                                    if (!isPomegranate)
                                    {
                                        FruitsNum++;
                                    }
                                    isPomegranate = true;
                                    isRed = true;
                                }
                                break;
                            case "Strawberry(Clone)":
                                {
                                    StrawberryNum++;
                                    if (!isStrawberry)
                                    {
                                        FruitsNum++;
                                    }
                                    isStrawberry = true;
                                    isRed = true;
                                }
                                break;
                            case "Tomato(Clone)":
                                {
                                    TomatoNum++;
                                    if (!isTomato)
                                    {
                                        FruitsNum++;
                                    }
                                    isTomato = true;
                                    isRed = true;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                switch (gameManager.RecelptNum)
                {
                    case 0:
                        {
                            gameManager.StarValue = 4;
                            if (AppleNum != 3 && isApple)
                                gameManager.StarValue--;
                            else if (BananaNum != 3 && isBanana)
                                gameManager.StarValue--;
                            else if(BlueberryNum != 3 && isBlueberry) 
                                gameManager.StarValue--;
                            else if (GrapeNum != 3 && isGrape)
                                gameManager.StarValue--;
                            else if (KoreanMelonNum != 3 && isKoreanMelon)
                                gameManager.StarValue--;
                            else if (LemonNum != 3 && isLemon)
                                gameManager.StarValue--;
                            else if (MangoNum != 3 && isMango)
                                gameManager.StarValue--;
                            else if (OrangeNum != 3 && isOrange)
                                gameManager.StarValue--;
                            else if (PeachNum != 3 && isPeach)
                                gameManager.StarValue--;
                            else if (PersimmonNum != 3 && isPersimmon)
                                gameManager.StarValue--;
                            else if (StrawberryNum != 3 && isStrawberry)
                                gameManager.StarValue--;
                            else if (TomatoNum != 3 && isTomato)
                                gameManager.StarValue--;
                            else if (PomegranateNum != 3 && isPomegranate)
                                gameManager.StarValue--;
                            else if(FruitsNum == 0)
                                gameManager.StarValue--;
                            if (FruitsNum != 4)
                                gameManager.StarValue--;
                            if (isNoRedOrBlue)
                                gameManager.StarValue--;
                        }
                        break;
                    case 1:
                        {
                            YellowNum = BananaNum + KoreanMelonNum + MangoNum + LemonNum;
                            AllFruitsNum = AppleNum + BananaNum + BlueberryNum + GrapeNum + KoreanMelonNum + LemonNum
                                + MangoNum + OrangeNum + PeachNum + PersimmonNum + StrawberryNum + TomatoNum + PomegranateNum;
                            gameManager.StarValue = 4;
                            if (isRed)
                                gameManager.StarValue--;
                            if(YellowNum < 6)
                                gameManager.StarValue--;
                            if(FruitsNum < 3)
                                gameManager.StarValue--;
                            if(AllFruitsNum != 7)
                                gameManager.StarValue--;
                        }
                        break;
                    case 2:
                        {
                            OrangeColorNum = OrangeNum + PersimmonNum;
                            AllFruitsNum = AppleNum + BananaNum + BlueberryNum + GrapeNum + KoreanMelonNum + LemonNum
                                + MangoNum + OrangeNum + PeachNum + PersimmonNum + StrawberryNum + TomatoNum + PomegranateNum;
                            gameManager.StarValue = 4;
                            if (isBlue)
                                gameManager.StarValue--;
                            if (PeachNum < 1)
                                gameManager.StarValue--;
                            if (OrangeColorNum < 3)
                                gameManager.StarValue--;
                            if (AllFruitsNum != 5)
                                gameManager.StarValue--;
                        }
                        break;
                    default:
                        break;
                }
                gameManager.Price = AppleNum * 1000 + BananaNum * 1000 + BlueberryNum * 500 + GrapeNum * 1000 + KoreanMelonNum * 1500 + LemonNum * 1000 +
                    MangoNum * 2500 + OrangeNum * 1500 + PeachNum * 1500 + PersimmonNum * 700 + StrawberryNum * 700 + TomatoNum * 700 + PomegranateNum * 2500;
                switch(gameManager.StarValue)
                {
                    case 0:
                        {
                            gameManager.Price = (int)(gameManager.Price * 0.2f);
                        }
                        break;
                    case 1:
                        {
                            gameManager.Price = (int)(gameManager.Price * 0.4f);
                        }
                        break;
                    case 2:
                        {
                            gameManager.Price = (int)(gameManager.Price * 0.6f);
                        }
                        break;
                    case 3:
                        {
                            gameManager.Price = (int)(gameManager.Price * 0.8f);
                        }
                        break;
                    case 4:
                        {
                            gameManager.Price = (int)(gameManager.Price * 1.1f);
                        }
                        break;
                    default:
                        break;
                }
                Basket.gameObject.SetActive(false);
                isDisapear = true;
            }
        }
    }
}
