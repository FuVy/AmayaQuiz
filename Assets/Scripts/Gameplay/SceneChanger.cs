using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(int id, float time)
    {
        StartCoroutine(WaitBeforeChange(id, time));
    }
    public void ChangeScene(float time)
    {
        StartCoroutine(WaitBeforeChange(SceneManager.GetActiveScene().buildIndex, time));
        PlayerPrefs.SetString("afterRestart", "true");
    }
    public void ChangeScene()
    {
        ChangeScene(SceneManager.GetActiveScene().buildIndex, 1.5f);
    }
    
    IEnumerator WaitBeforeChange(int id, float time)
    {
        yield return new WaitForSeconds(time);
        PlayerPrefs.SetString("hasCrushed", "false");
        SceneManager.LoadScene(id);
    }
}
