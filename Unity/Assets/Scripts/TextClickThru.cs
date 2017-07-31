using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Text))]
public class TextClickThru : MonoBehaviour {
	[SerializeField] string[] texts;
	[SerializeField] bool exitOnFinished;

	Text uiText;
	int textIndex;

	void Awake () {
		uiText = GetComponent<Text> ();
	}

	void Update () {
		if (textIndex < texts.Length) {
			uiText.text = texts[textIndex];
		} else {
			uiText.text = texts[texts.Length - 1];
		}

		if (Input.GetMouseButtonDown (0)) {
			textIndex++;
		}

		if (exitOnFinished && textIndex > texts.Length) {
			Application.Quit ();
		}
	}
}
