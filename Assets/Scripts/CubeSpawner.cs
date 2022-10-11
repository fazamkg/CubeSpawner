using UnityEngine;
using UnityEngine.Pool;

public class CubeSpawner : MonoBehaviour
{
	[SerializeField] private Transform _origin;
	[SerializeField] private Timer _timer;

	public float SpawnInterval
	{
		get => _timer.Interval;
		set
		{
			_timer.Interval = value;
		}
	}
	[field: SerializeField] public float Speed { get; set; }
	[field: SerializeField] public float Distance { get; set; }

	private void Awake()
	{
		_timer.OnTimerEnd += Spawn;
	}

	private void Spawn()
	{

	}
}
