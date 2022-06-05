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
    [SerializeField] int pointsPerFood = 10;
    [SerializeField] float bodySpace = .75f;
    [SerializeField] Tilemap floorMap;
    AudioPlayer player;

    int bodyCount = 1;

    private void Awake()
    {
        player = FindObjectOfType<AudioPlayer>();
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
            FindObjectOfType<GameSession>().AddToScore(pointsPerFood);
            Destroy(collision.gameObject);
            player.PlayEatingClip();
            SpawnFood();
        }
    }

    private void SpawnFood()
    {
        float newFoodXPos, newFoodYPos;
        newFoodXPos = Random.Range(floorMap.origin.x, floorMap.origin.x + floorMap.size.x);
        newFoodYPos = Random.Range(floorMap.origin.y, floorMap.origin.y + floorMap.size.y);
        Vector3 newFoodPos = new Vector3(newFoodXPos, newFoodYPos);
        Instantiate(prefabFood, newFoodPos, Quaternion.identity);
    }

    void GrowCentipede()
    {
        float bodyOffset = bodySpace * bodyCount;
        GameObject newBodySegment = Instantiate(prefabCentipedeBody);
        newBodySegment.transform.position = bodySegments[bodySegments.Count - 1].position;
        bodySegments.Add(newBodySegment.transform);
        bodyCount++;
    }

    public List<Transform> GetBodySegmentList()
    {
        return bodySegments;
    }
}
