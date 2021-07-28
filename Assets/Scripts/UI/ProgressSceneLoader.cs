using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ProgressSceneLoader : MonoBehaviour
{
	[SerializeField]
	private TMP_Text progressText;
	[SerializeField]
	private Slider slider;

	private AsyncOperation operation;
	private Canvas canvas;

	private void Awake()
	{
		canvas = GetComponentInChildren<Canvas>(true);
		DontDestroyOnLoad(gameObject);
	}

	public void LoadScene(int id)
	{
		UpdateProgressUI(0);
		canvas.gameObject.SetActive(true);

		StartCoroutine(BeginLoad(id));
	}

	private IEnumerator BeginLoad(int id)
	{
		operation = SceneManager.LoadSceneAsync(id);

		while (!operation.isDone)
		{
			UpdateProgressUI(operation.progress);
			yield return null;
		}

		UpdateProgressUI(operation.progress);
		operation = null;
		canvas.gameObject.SetActive(false);
	}

	private void UpdateProgressUI(float progress)
	{
		slider.value = progress;
		progressText.text = (int)(progress * 100f) + "%";
	}
}
