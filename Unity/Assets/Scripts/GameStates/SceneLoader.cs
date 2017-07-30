
using UnityEngine.SceneManagement;

public class SceneLoader
{
	private string _scene;

	public SceneLoader (string sceneName)
	{
		_scene = sceneName;
	}

	public void OnEnter ()
	{
		SceneManager.LoadScene (_scene);
	}

	public void OnExit ()
	{
		SceneManager.UnloadSceneAsync (_scene);
	}
}
