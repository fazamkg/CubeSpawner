using UnityEngine;
using UnityEngine.Pool;

public class CubeSpawner : MonoBehaviour
{
	[SerializeField] private Transform _origin;
	[SerializeField] private Timer _timer;

	[field: SerializeField] public float SpawnInterval { get; set; }
	[field: SerializeField] public float Speed { get; set; }
	[field: SerializeField] public float Distance { get; set; }
}
