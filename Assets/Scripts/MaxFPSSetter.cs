using UnityEngine;

public class MaxFPSSetter : MonoBehaviour
{
	[SerializeField] private int _targetFPS = 60;

	private void Awake()
	{
		Application.targetFrameRate = _targetFPS;
	}
}
