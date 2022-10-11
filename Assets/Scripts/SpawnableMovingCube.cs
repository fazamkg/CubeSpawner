using UnityEngine;
using System;

public class SpawnableMovingCube : MonoBehaviour
{
	private float _currentDistance;
	private CubeSpawner _cubeSpawner;

	public event Action<SpawnableMovingCube> OnDeathDistanceReached;

	private void Update()
	{
		var distance = _cubeSpawner.Speed * Time.deltaTime;
		transform.position += distance * Vector3.forward;

		_currentDistance += distance;
		if (_currentDistance >= _cubeSpawner.Distance)
		{
			OnDeathDistanceReached?.Invoke(this);
			gameObject.SetActive(false);
		}
	}

	public void Reset()
	{
		_currentDistance = 0.0f;
	}

	public void Initialize(CubeSpawner cubeSpawner)
	{
		_cubeSpawner = cubeSpawner;
	}
}
