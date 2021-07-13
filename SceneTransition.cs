using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public void StartLoadingScene()
    {
        GameObject.Find("SceneManager").GetComponent<SceneManagerScript>().canStartLoad = true;
    }
}
