using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FoodPickup : MonoBehaviour
{
    [SerializeField] GameObject prefabCentipedeBody;
    [SerializeField] GameObject prefabFood;
    [SerializeField] GameObject centipedeHead;
    List<Transform> bodySegments;
    [SerializeField] int pointsPerFood = 100;
    [SerializeField] Tilemap floorMap;
    AudioPlayer player;
    GameSession gameSession;

    private void Awake()
    {
        player = FindObjectOfType<AudioPlayer>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void Start()
    {
        bodySegments = new List<Transform>();
        bodySegments.Add(this.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            GrowCentipede();
            Destroy(collision.gameObject);
            player.PlayEatingClip();
            gameSession.AddToScore(pointsPerFood);
            SpawnFood();
        }
    }

    private void SpawnFood()
    {
        float newFoodXPos, newFoodYPos;
        newFoodXPos = Random.Range(floorMap.origin.x + 1, floorMap.origin.x + floorMap.size.x);
        newFoodYPos = Random.Range(floorMap.origin.y + 1, floorMap.origin.y + floorMap.size.y);
        Vector3 newFoodPos = new Vector3(Mathf.Round(newFoodXPos), Mathf.Round(newFoodYPos));
        Instantiate(prefabFood, newFoodPos, Quaternion.identity);
    }

    void GrowCentipede()
    {
        GameObject newBodySegment = Instantiate(prefabCentipedeBody);
        newBodySegment.transform.position = bodySegments[bodySegments.Count - 1].position;
        bodySegments.Add(newBodySegment.transform);
    }

    public List<Transform> GetBodySegmentList()
    {
        return bodySegments;
    }
}
