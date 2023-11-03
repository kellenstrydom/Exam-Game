using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public Image rotatingImage;
    public string nextSceneName;
    public float loadTime = 6.0f;

    private AsyncOperation asyncOperation;

    void Start()
    {
        asyncOperation = SceneManager.LoadSceneAsync(nextSceneName);
        asyncOperation.allowSceneActivation = false;

       
        StartCoroutine(LoadingCoroutine());
    }

    private IEnumerator LoadingCoroutine()
    {
        float startTime = Time.time;
        float endTime = startTime + loadTime;

        while (Time.time < endTime)
        {
            float progress = Mathf.Clamp01((Time.time - startTime) / loadTime);
  
            float rotationAngle = 360f * progress; 
            rotatingImage.rectTransform.rotation = Quaternion.Euler(0, 0, rotationAngle);

            yield return null;
        }

     
        asyncOperation.allowSceneActivation = true;
    }
}
