using UnityEngine;
public class SceneManager : MonoBehaviour
{

    public void ChangeScene(int sceneNum)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNum);
    }

}

