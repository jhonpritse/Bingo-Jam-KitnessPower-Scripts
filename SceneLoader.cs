
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    
    public int sceneToLoad;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<Movement>().enabled = false; 
            var manager = GameObject.Find("SceneManager").GetComponent<SceneManagerScript>();  
            manager.loadingScreen.SetActive(true);        
            manager.sceneIndex = sceneToLoad;
          
        }
    }
}
