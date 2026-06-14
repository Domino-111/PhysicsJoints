using System.Data;
using UnityEngine;

public class ExtraPoints : MonoBehaviour
{
    public GameManager gm;

    public int points;

    public bool specialPoints = false;

    public PointSpawner ps;

    void Awake()
    {
        gm = FindFirstObjectByType<GameManager>();

        ps = FindFirstObjectByType<PointSpawner>();
    }

    // If the ball is normal you only need to touch it to earn points
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && specialPoints == false)
        {
            gm.score += points;
            Destroy(gameObject);
        }
    }

    // If the ball is special to earn extra points you need to keep your NPC in its hitbox to continual earn points
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && specialPoints == true)
        {
            gm.score += points;
        }
    }

    // If the ball is special and the NPC leaves its hitbox it'll disappear
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && specialPoints == true)
        {
            ps.specialSpawned = false;
            Destroy(gameObject);
        }
    }
}
