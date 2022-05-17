using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] Vector2 startDirection = new Vector2(1, 0);
    [SerializeField] float centiSpeed = 0.2f;
    List<Vector2> playerTurnWayPointList = new List<Vector2>();

    void Start()
    {
        rawInput = startDirection;
    }

    void Update()
    {
        handleMove();
    }

    void OnMove(InputValue value)
    {
        //ToDo prevent changes to rawInput from the opposite vector
        if (value.Get<Vector2>() != new Vector2(0, 0))
        {
            playerTurnWayPointList.Add(transform.position);
            rawInput = value.Get<Vector2>();
        }
    }

    public List<Vector2> GetWaypointList()
    {
        return playerTurnWayPointList;
    }

    void handleMove()
    {
        Vector2 delta = rawInput * centiSpeed * Time.deltaTime;

        Vector2 newPos = new Vector2();
        newPos.x = transform.position.x + delta.x;
        newPos.y = transform.position.y + delta.y;
        transform.position = newPos;
    }
}
