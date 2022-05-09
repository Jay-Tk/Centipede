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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Vector3 newBodyPos = centipedeHead.transform.position - new Vector3(bodySpace, 0);
            Instantiate(prefabCentipedeBody, newBodyPos, Quaternion.identity, centipedeHead.transform);
            Destroy(collision.gameObject);
            //floorMap.GetTilesBlock(floorMap.cellBounds);
            //ToDo Spawn new food
        }
    }
}
