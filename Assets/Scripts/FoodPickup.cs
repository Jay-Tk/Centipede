using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FoodPickup : MonoBehaviour
{
    [SerializeField] GameObject prefabCentipedeBody;
    [SerializeField] GameObject prefabFood;
    [SerializeField] GameObject centipedeHead;
    [SerializeField] float bodySpace = .75f;
    [SerializeField] Tilemap floorMap;

    int bodyCount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            GrowCentipede();
            Destroy(collision.gameObject);
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
        Vector3 newBodyPos = centipedeHead.transform.position - new Vector3(bodyOffset, 0);
        Instantiate(prefabCentipedeBody, newBodyPos, Quaternion.identity, centipedeHead.transform);
        bodyCount++;
    }
}
