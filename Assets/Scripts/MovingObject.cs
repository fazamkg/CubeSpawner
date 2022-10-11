using UnityEngine;
using System;

public class MovingObject : MonoBehaviour
{
	private float _currentDistance;

	[field: SerializeField] public float Speed { get; set; }
	[field: SerializeField] public float DeathDistance { get; set; }

	public event Action<MovingObject> OnDeathDistanceReached;

	private void Update()
	{
		var distance = Speed * Time.deltaTime;
		transform.position += distance * Vector3.forward;

		_currentDistance += distance;
		if (_currentDistance >= DeathDistance)
		{
			OnDeathDistanceReached?.Invoke(this);
			gameObject.SetActive(false);
		}
	}

	public void Reset()
	{
		_currentDistance = 0.0f;
	}
}
