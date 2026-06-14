using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    public GameObject normalPoints, specialPoints;

    public bool specialSpawned = false;

    public float timer, resetTime;

    void Update()
    {
        // Periodically spawn a new point ball
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnPoints();

            timer = resetTime;
        }
    }

    public void SpawnPoints()
    {
        if (specialSpawned == false)
        {
            Instantiate(specialPoints, RandomSpawn(), transform.rotation);
            specialSpawned = true;
        }

        Instantiate(normalPoints, RandomSpawn(), transform.rotation);
    }

    public Vector3 RandomSpawn()
    {
        float x = Random.Range(-8f, 8f);
        float z = Random.Range(-8f, 8f);

        Vector3 randomPoint = new Vector3(x, 1, z);

        return transform.TransformPoint(randomPoint);
    }
}
