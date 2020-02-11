using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour
{
    public void Awake(){
        DontDestroyOnLoad(gameObject);
        print("_preload scene loaded.");
        if (LoadingSceneIntegration.otherScene > 0)
        {
            Debug.Log("Returning again to the scene: " + LoadingSceneIntegration.otherScene);
            SceneManager.LoadScene(LoadingSceneIntegration.otherScene);
        }
    }
}
