using UnityEngine;
using UnityEngine.UI;

public class CubeSpawnerUI : MonoBehaviour
{
	[SerializeField] private InputField _spawnIntervalField;
	[SerializeField] private InputField _speedField;
	[SerializeField] private InputField _distanceField;

	[SerializeField] private CubeSpawner _cubeSpawner;

	private void Awake()
	{
		_spawnIntervalField.onEndEdit.AddListener(UpdateSpawnInterval);
		_speedField.onEndEdit.AddListener(UpdateSpeed);
		_distanceField.onEndEdit.AddListener(UpdateDistance);
	}

	private void Start()
	{
		_spawnIntervalField.text = _cubeSpawner.SpawnInterval.ToString();
		_speedField.text = _cubeSpawner.Speed.ToString();
		_distanceField.text = _cubeSpawner.Distance.ToString();
	}

	private void UpdateSpawnInterval(string value)
	{
		var parsed = float.TryParse(value, out float result);
		if (parsed) _cubeSpawner.SpawnInterval = result;
	}

	private void UpdateSpeed(string value)
	{
		var parsed = float.TryParse(value, out float result);
		if (parsed) _cubeSpawner.Speed = result;
	}
	private void UpdateDistance(string value)
	{
		var parsed = float.TryParse(value, out float result);
		if (parsed) _cubeSpawner.Distance = result;
	}
}
