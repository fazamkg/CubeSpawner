using UnityEngine;
using UnityEngine.Pool;

public class CubeSpawner : MonoBehaviour
{
	[SerializeField] private MovingObject _cubePrefab;

	[SerializeField] private Transform _origin;
	[SerializeField] private Timer _timer;

	private ObjectPool<MovingObject> _pool;

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
		if (_timer == null) _timer = GetComponent<Timer>();
		if (_origin == null) _origin = transform;

		_pool = new ObjectPool<MovingObject>(Spawn, OnGet);

		_timer.OnTimerEnd += Get;
	}

	private void Get() => _pool.Get();

	private MovingObject Spawn()
	{
		var cube = Instantiate(_cubePrefab, _origin.position, Quaternion.identity, _origin);

		cube.Speed = Speed;
		cube.DeathDistance = Distance;
		cube.OnDeathDistanceReached += _pool.Release;

		return cube;
	}

	private void OnGet(MovingObject cube)
	{
		cube.gameObject.SetActive(true);
		cube.transform.position = _origin.position;
		cube.Reset();
	}
}
