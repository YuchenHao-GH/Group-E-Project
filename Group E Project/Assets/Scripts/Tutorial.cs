using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Button Left;
    public Button Right;
    public Button Tut;
    public GameObject Panel;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public int Textcounter = 1;
    // Start is called before the first frame update
    void Start()
    {
        Left.onClick.AddListener(LeftClick);
        Right.onClick.AddListener(RightClick);
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Textcounter == 4)
        {
            Right.gameObject.SetActive(false);
        }
        if (Textcounter < 4)
        {
            Right.gameObject.SetActive(true);
        }
        if (Textcounter == 1)
        {
            Left.gameObject.SetActive(false);
        }
        if (Textcounter > 1)
        {
            Left.gameObject.SetActive(true);
        }
    }

    public void LeftClick()
    {
        Text1.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
        Text4.SetActive(false);
        Image1.SetActive(false);
        Image2.SetActive(false);
        Image3.SetActive(false);
        Image4.SetActive(false);
        Textcounter--;
       
        switch (Textcounter)
        {
            case 1:
                Text1.SetActive(true);
                Image1.SetActive(true);
                break;
            case 2:
                Text2.SetActive(true);
                Image2.SetActive(true);
                break;
            case 3:
                Text3.SetActive(true);
                Image3.SetActive(true);
                break;
            case 4:
                Text4.SetActive(true);
                Image4.SetActive(true);
                break;
        }
    }

    public void RightClick()
    {
        Text1.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
        Text4.SetActive(false);
        Image1.SetActive(false);
        Image2.SetActive(false);
        Image3.SetActive(false);
        Image4.SetActive(false);
        Textcounter++;
       
        switch (Textcounter)
        {
            case 1:
                Text1.SetActive(true);
                Image1.SetActive(true);
                break;
            case 2:
                Text2.SetActive(true);
                Image2.SetActive(true);
                break;
            case 3:
                Text3.SetActive(true);
                Image3.SetActive(true);
                break;
            case 4:
                Text4.SetActive(true);
                Image4.SetActive(true);
                break;
        }
    }

    public void TutorialBut()
    {
        Panel.SetActive(true);
        Tut.gameObject.SetActive(false);
    }
    public void Exit()
    {
        Panel.SetActive(false);
        Tut.gameObject.SetActive(true);
    }
}
