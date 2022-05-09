using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FoodPickup : MonoBehaviour
{
    [SerializeField] GameObject prefabCentipedeBody;
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
            //floorMap.GetTilesBlock(floorMap.cellBounds);
            //ToDo Spawn new food
        }
    }

    void GrowCentipede()
    {
        float bodyOffset = bodySpace * bodyCount;
        Vector3 newBodyPos = centipedeHead.transform.position - new Vector3(bodyOffset, 0);
        Instantiate(prefabCentipedeBody, newBodyPos, Quaternion.identity, centipedeHead.transform);
        bodyCount++;
    }
}
