using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnPlatform : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the platform trigger zone.");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
