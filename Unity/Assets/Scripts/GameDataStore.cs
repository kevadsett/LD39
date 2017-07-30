using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataStore : MonoBehaviour
{
	public Dictionary < string, object> Store;

	void Start()
	{
		Store = new Dictionary<string, object>
		{
			{
				"flavourtext", new List<string>
				{
					"The horror...",
					"Not the eyes!  Please, not the eyes!",
					"A release long to be wished for...",
					"Nothing but darkness now...",
					"Keep telling yourself it is just a nightmare...",
					"A sin like yours cannot be forgiven",
					"Lost to the unknown depths...",
					"Your place is in the shadows. Among us.",
					"Daylight is not for the likes of you.",
					"Damned...damned for eternity"
				}
			}
		};
	}
}
