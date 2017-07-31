using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSchemeView : MonoBehaviour {
	public AnimationCurve FadeOut;

	public Sprite Absolute;
	public Sprite Relative;

	public bool StartVisible;

	private Image _image;

	private float _fadeOutStartTime;

	private GameDataStore _dataStore;

	void Start ()
	{
		_image = GetComponent<Image> ();
		_fadeOutStartTime = StartVisible ? Time.time : float.MinValue;
		var dataStoreObject = GameObject.Find ("DataStore");
		if (dataStoreObject != null)
		{
			_dataStore = dataStoreObject.GetComponent<GameDataStore> ();
		}
	}

	void Update ()
	{
		float alpha = FadeOut.Evaluate (Time.time - _fadeOutStartTime);
		_image.color = new Color (_image.color.r, _image.color.g, _image.color.b, alpha);

		if (Input.GetKeyDown (KeyCode.Tab))
		{
			_fadeOutStartTime = Time.time;
			if (_dataStore != null)
			{
				_dataStore.Store ["AbsoluteControls"] = !(bool)_dataStore.Store ["AbsoluteControls"];
				_image.sprite = (bool)_dataStore.Store ["AbsoluteControls"] ? Absolute : Relative;
			}
		}
	}
}
