using UnityEngine;
using System;

public class MovingObject : MonoBehaviour
{
	private float _currentDistance;

	[field: SerializeField] public float Speed { get; set; }
	[field: SerializeField] public float DeathDistance { get; set; }

	public event Action OnDeathDistanceReached;

	private void Update()
	{
		var distance = Speed * Time.deltaTime;
		transform.position += distance * Vector3.forward;

		_currentDistance += distance;
		if (_currentDistance >= DeathDistance)
		{
			OnDeathDistanceReached?.Invoke();
			gameObject.SetActive(false);
		}
	}
}
