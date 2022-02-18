using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private MineralClickHandler mineralPrefab;

    [SerializeField] private int spawnAmount;

    [SerializeField] private int defaulfCapacity;
    [SerializeField] private int maxCapacity;

    private ObjectPool<MineralClickHandler> pool;

    private void Start()
    {
        pool = new ObjectPool<MineralClickHandler>(() =>
        {
            return Instantiate(mineralPrefab);

        }, mineralPrefab => {
            mineralPrefab.gameObject.SetActive(true);

        }, mineralPrefab => {
            mineralPrefab.gameObject.SetActive(false);

        }, mineralPrefab => {
            Destroy(mineralPrefab.gameObject);

        }, true, defaulfCapacity, maxCapacity);


        InvokeRepeating(nameof (SpawnObject), 1f, 1f);
    }

    private void SpawnObject()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            var spawnedObject = pool.Get();
            spawnedObject.transform.position = transform.position + Random.insideUnitSphere * 2f;
            spawnedObject.Init(KillObject);
        }
    }

    private void KillObject(MineralClickHandler mineral)
    {
        pool.Release(mineral);
        //Destroy(mineral.gameObject);
    }
}
