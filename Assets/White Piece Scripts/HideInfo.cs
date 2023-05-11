using UnityEngine;
using UnityEngine.UI;


public class HideInfo : MonoBehaviour
{
    // Declare the UI elements that you want to hide/show
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;

    // Declaring Hide and Show strings for button text change
    public string hideText = "Hide Info";
    public string showText = "Show Info";

    // Declaring buttons
    public GameObject HideBtn;
    public GameObject ShowBtn;

    public void Start()
    {
        HideBtn.SetActive(true);
    }

    // Called when the button is clicked
    public void OnButtonClick()
    {
        // Get a reference to the Text component of the button
        Text buttonText = GetComponent<Text>();

        // Toggle the visibility of the elements that are currently visible
        if (text1.color == Color.white)
        {
            text1.color = Color.clear;
        }
        else
        {
            text1.color = Color.white;
        }

        if (text2.color == Color.white)
        {
            text2.color = Color.clear;
        }
        else
        {
            text2.color = Color.white;
        }

        if (text3.color == Color.white)
        {
            text3.color = Color.clear;
        }
        else
        {
            text3.color = Color.white;
        }

        if (text4.color == Color.white)
        {
            text4.color = Color.clear;
        }
        else
        {
            text4.color = Color.white;
        }
        if (text5.color == Color.white)
        {
            text5.color = Color.clear;
        }
        else
        {
            text5.color = Color.white;
        }

        if (text6.color == Color.white)
        {
            text6.color = Color.clear;
        }
        else
        {
            text6.color = Color.white;
        }

        if (panel1.activeSelf)
        {
            panel1.SetActive(false);
        }
        else
        {
            panel1.SetActive(true);
        }

        if (panel2.activeSelf)
        {
            panel2.SetActive(false);
        }
        else
        {
            panel2.SetActive(true);
        }

        if (panel3.activeSelf)
        {
            panel3.SetActive(false);
        }
        else
        {
            panel3.SetActive(true);
        }

        if (panel4.activeSelf)
        {
            panel4.SetActive(false);
        }
        else
        {
            panel4.SetActive(true);
        }
        if (panel5.activeSelf)
        {
            panel5.SetActive(false);
        }
        else
        {
            panel5.SetActive(true);
        }

        if (panel6.activeSelf)
        {
            panel6.SetActive(false);
        }
        else
        {
            panel6.SetActive(true);
        }

    }

    public void OnButton1Clicked()
    {
        HideBtn.SetActive(false);

        ShowBtn.SetActive(true);

    }

    public void OnButton2Clicked()
    {
        HideBtn.SetActive(true);

        ShowBtn.SetActive(false);
    }

}

