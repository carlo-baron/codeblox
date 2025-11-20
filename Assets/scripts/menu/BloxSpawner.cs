using UnityEngine;
using System.Collections.Generic;

public class BloxSpawner : MonoBehaviour
{
    public GameObject menuBloxPrefab;

    [SerializeField]
    private List<string> keywords;
    public List<string> Keywords => keywords;

    [SerializeField]
    private float spawnCooldown = 1.5f;
    private float nextSpawnTime = 0f;

    void Update()
    {
        if(Time.time >= nextSpawnTime){
            Vector2 startingPos = GetRandomHorizontalPosition();
            Instantiate(menuBloxPrefab, startingPos, Quaternion.identity, transform);

            nextSpawnTime = Time.time + spawnCooldown;
        }
    }

    Vector2 GetRandomHorizontalPosition(){
        float cameraWidth = Camera.main.orthographicSize * ((float)Screen.width / Screen.height);
        float min = transform.position.x - cameraWidth;
        float max = transform.position.x + cameraWidth;

        return new Vector2(Random.Range(min, max), transform.position.y + Random.Range(0, 2));
    }
}
