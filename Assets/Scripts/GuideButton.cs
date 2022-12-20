using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideButton : MonoBehaviour
{
    // List of gameObjects that will appear when clicking the button
    [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();

    // The boolean which controls whether the gameObject is activated or not
    private bool activeState = false;

    // The instance of the button that this script is attached to
    private Button instance;


    private void Awake()
    {
        DisableObjects(); // Set all the gameObject in the list to be disabled
        instance = this.gameObject.GetComponent<Button>(); // Get button component from this gameObject

        // Add the InteractWithObjects method to the button
        instance.onClick.AddListener(delegate { InteractWithObjects(); });
    }

    private void DisableObjects()
    {
               
        // Disable all gameObjects at the start of the scene
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(false); // Deactivating the gameObjects found

            // Deactivating the children of these gameObjects if they have at least one
            if (obj.transform.childCount > 0) GetChildren(obj, false);
        }
    }

    private void GetChildren(GameObject obj, bool activeState)
    {
        foreach (Transform child in obj.transform)
        {
            child.gameObject.SetActive(activeState);
        }

        
    }

    private void InteractWithObjects()
    {
        // Activating the gameObjects
        activeState = true;

        // Looping through all gameObjects in the list, activating them
        foreach (GameObject obj in gameObjects)
        {
            obj.gameObject.SetActive(activeState);
            // Enabling the children of these gameObjects if they have at least one
            if (obj.transform.childCount > 0) GetChildren(obj, activeState);
        }

        // Remove the button onClick method
        instance.onClick.RemoveListener(delegate { InteractWithObjects(); });
    }
}
