
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    [HideInInspector]public bool canStartLoad;
    [HideInInspector]public int sceneIndex;
    private void Update()
    {
        if (canStartLoad)
        {
            StartCoroutine(LoadAsync());
        }
    }

    IEnumerator LoadAsync( )
    {
   
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            var progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            
            yield return null;
        }
    }


}