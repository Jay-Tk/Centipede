using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    PlayerMovement playerMovement;
    List<Vector2> TurnWaypoints = new List<Vector2>();
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        TurnWaypoints = playerMovement.GetWaypointList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
