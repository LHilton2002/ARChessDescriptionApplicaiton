using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PawnBtnText : MonoBehaviour
{
    // The button that the user needs to touch in order to enable/disable the text
    public Button pawnButton;

    // A reference to the Text component
    public Text messageText;

    // A reference to the game object that holds the Text component
    public GameObject messageTextObject;

    void Start()
    {
        // Add a listener to the button's onClick event
        pawnButton.onClick.AddListener(ToggleText);

        // Get the Text component from the messageTextObject game object
        messageText = messageTextObject.GetComponent<Text>();

        // Set the messageTextObject to inactive
        messageTextObject.SetActive(false);
    }

    // This function will be called when the button is clicked
    void ToggleText()
    {
        // If the messageTextObject is active, set it to inactive
        if (messageTextObject.activeSelf)
        {
            messageTextObject.SetActive(false);
        }
        // Otherwise, set it to active
        else
        {
            messageTextObject.SetActive(true);
        }
    }
}
