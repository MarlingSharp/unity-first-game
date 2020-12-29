using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject floorTile;

    [SerializeField]
    private GameObject coin;

    private float timeSinceSpawn = 0;

    private void Start()
    {
        SpawnCoinAndTile();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn > 2)
        {
            SpawnCoinAndTile();

            timeSinceSpawn = 0;
        }
    }

    void SpawnCoinAndTile()
    {
        Vector3 coinPos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        Instantiate(coin, coinPos, transform.rotation);
        Instantiate(floorTile, transform.position, transform.rotation);
        transform.position = new Vector3(transform.position.x + 2,
            transform.position.y,
            transform.position.z);
    }
}
