using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class WhitePawnSpawner : MonoBehaviour
{
    // The prefab that we want to spawn
    public GameObject whitePrefab;

    // The button that the user needs to touch in order to spawn the prefab
    public Button pieceButton;

    // The ARRaycastManager that will be used to raycast against real-world surfaces
    public ARRaycastManager arRaycastManager;

    // A reference to the Placement plane
    public GameObject placementPlane;

    // A list to hold the raycast hits
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // A reference to the previously spawned prefab
    GameObject spawnedPrefab;

    // A reference to the Text component
    public Text messageText;

    // A reference to the Info Panel
    public GameObject infoPanel;

    // An AudioSource component to play the audio cue
    public AudioSource audioSource;

    void Start()
    {
        // Add a listener to the button's onClick event
        pieceButton.onClick.AddListener(SpawnWhitePawnPrefab);

        // Get the Text component from the messageTextObject game object
        messageText = messageText.GetComponent<Text>();

        //message text inactive on start up
        messageText.enabled = false;

        //Information Panel inactive on start up
        infoPanel.SetActive(false);
    }

    // This function will be called when the button is clicked
    void SpawnWhitePawnPrefab()
    {
        // If a prefab has already been spawned, remove it
        if (spawnedPrefab != null)
        {
            Destroy(spawnedPrefab);
            spawnedPrefab = null;
            messageText.enabled = false;
            placementPlane.SetActive(true);
            infoPanel.SetActive(false);
            return;
        }

        // Raycast against the Placement plane
        if (arRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            // Get the pose of the hit point
            Pose hitPose = hits[0].pose;

            // Instantiate the prefab at the hit point
            spawnedPrefab = Instantiate(whitePrefab, hitPose.position, hitPose.rotation);

            // Play the audio cue
            audioSource.Play();

            // Set the text of the messageText component
            messageText.enabled = true;

            // Hide the placement plane
            placementPlane.SetActive(false);

            // Show the information Panel
            infoPanel.SetActive(true);
        }
    }
}