using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FallingScene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(TransitionToDungeon());
    }

    IEnumerator TransitionToDungeon()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds (fall duration)
        SceneManager.LoadScene("DungeonScene");
    }
}
