using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {

	[SerializeField]
	private int targetFrameRate;

	void Awake()
	{
		Application.targetFrameRate = targetFrameRate; 
	}
}