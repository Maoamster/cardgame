using UnityEngine;
using UnityEngine.SceneManagement;

public class WellInteraction : MonoBehaviour
{
    private bool isPlayerNear = false;
    private ScreenFader screenFader;

    void Start()
    {
        screenFader = FindObjectOfType<ScreenFader>();
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            EnterWell();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void EnterWell()
    {
        Debug.Log("Entering the well...");
        screenFader.StartFadeOut("FallingScene");
    }
}
