
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader
{
	private string _sceneName;

	public SceneLoader (string sceneName)
	{
		_sceneName = sceneName;
	}

	public void OnEnter ()
	{
		SceneManager.LoadScene (_sceneName);
		Time.timeScale = 1;
	}

	public void OnExit ()
	{
	}
}
