using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    List<GameObject> launcherPrefabs = new List<GameObject>(3);

    //Timer Support
    Timer spawnTimer;
    float spawnTime = 5;

    int prefabNumber = 0;

    Vector3 spawnPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = spawnTime;

        spawnTimer.Run();
    }

    private void Update()
    {
        if (spawnTimer.Finished)
        {
            if (prefabNumber < launcherPrefabs.Count) {
                Instantiate(launcherPrefabs[prefabNumber], spawnPosition, Quaternion.identity);
                prefabNumber++;

                spawnPosition.y++;

                spawnTimer.Run();
            }
        }
    }
}
