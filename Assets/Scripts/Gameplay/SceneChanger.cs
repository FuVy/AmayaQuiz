using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(int id)
    {
        SceneManager.LoadScene(id);
    }
    public void ChangeScene()
    {
        ChangeScene(SceneManager.GetActiveScene().buildIndex);
    }
}
