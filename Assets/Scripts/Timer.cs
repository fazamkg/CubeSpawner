using UnityEngine;

public class Timer : MonoBehaviour
{
	[SerializeField] private bool _isRepeating = true;

	private bool _isDone;
	private float _timer;

	[field: SerializeField] public float Interval { get; set; }

	private void Update()
	{
		if (_isDone) return;

		_timer += Time.deltaTime;
		if (_timer < Interval) return;

		if (_isRepeating)
		{
			_timer = 0.0f;
		}
		else
		{
			_isDone = true;
		}
	}
}
