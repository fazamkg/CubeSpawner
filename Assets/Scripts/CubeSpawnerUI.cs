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

	private float ForceParse(string value)
	{
		value = value.Replace('.', ',');
		var parsed = float.TryParse(value, out float result);
		if (parsed) return result;
		return 0.0f;
	}

	private void UpdateSpawnInterval(string value)
	{
		_cubeSpawner.SpawnInterval = ForceParse(value);
	}

	private void UpdateSpeed(string value)
	{
		_cubeSpawner.Speed = ForceParse(value);
	}
	private void UpdateDistance(string value)
	{
		_cubeSpawner.Distance = ForceParse(value);
	}
}
