using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideButton : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();
    private bool activeState = false;
    private Button instance;


    private void Awake()
    {
        DisableObjects();
        instance = this.gameObject.GetComponent<Button>();
        instance.onClick.AddListener(delegate { InteractWithObjects(); });
    }

    private void DisableObjects()
    {
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(false);
        }
    }
    private void InteractWithObjects()
    {
        activeState = !activeState;
        foreach (GameObject go in gameObjects)
        {     
            go.gameObject.SetActive(activeState);
        }
    }
}
