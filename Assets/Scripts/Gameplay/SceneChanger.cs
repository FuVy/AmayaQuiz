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
    public void ChangeScene()
    {
        ChangeScene(SceneManager.GetActiveScene().buildIndex, 1.5f);
    }
    
    IEnumerator WaitBeforeChange(int id, float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(id);
    }
}
