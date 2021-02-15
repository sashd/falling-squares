using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<FallingObjectData> objectData;

    [Min(0)]
    [SerializeField] private int poolSize;

    [SerializeField] private GameObject prefabRef;

    [SerializeField] private float spawnOffsetY = 0f;

    [Min(0)]
    [SerializeField] private float spawnTime;

    [Min(0)]
    [SerializeField] private float startTime;

    public static Dictionary<GameObject, FallingObject> objectsMap = new Dictionary<GameObject, FallingObject>();
    private Queue<GameObject> currentObjects = new Queue<GameObject>();

    private void Start()
    {
        InitPool();

        FallingObject.OnObjectDestroy += ReturnToPool;
    }
    private void Update()
    {
        startTime -= Time.deltaTime;
        if (!GameManager.GameOver && startTime < 0)
        {
            Spawn();
            startTime = spawnTime;
        }
    }

    private void InitPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            ExpandPool();
        }
    }
    private void ExpandPool()
    {
        GameObject gameObject = Instantiate(prefabRef);
        gameObject.SetActive(false);
        FallingObject fallingObject = gameObject.GetComponent<FallingObject>();
        objectsMap.Add(gameObject, fallingObject);
        currentObjects.Enqueue(gameObject);
    }

    private void Spawn()
    {
        if (currentObjects.Count > 0)
        {
            GameObject gameObject = currentObjects.Dequeue();
            FallingObject fallingObject = objectsMap[gameObject];
            gameObject.SetActive(true);

            int rand = Random.Range(0, objectData.Count);
            fallingObject.Init(objectData[rand]);

            float spawnPositionX = Random.Range(-CameraBorders.Borders.x, CameraBorders.Borders.x);
            gameObject.transform.position = new Vector3(spawnPositionX, CameraBorders.Borders.y + spawnOffsetY, 0);
        }
        else
        {
            ExpandPool();
        }
    }

    private void ReturnToPool(GameObject _object)
    {
        _object.transform.position = CameraBorders.Borders;
        _object.SetActive(false);
        currentObjects.Enqueue(_object);
    }

    private void OnDestroy()
    {
        FallingObject.OnObjectDestroy -= ReturnToPool;
    }
}
