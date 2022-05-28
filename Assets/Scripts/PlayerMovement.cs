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
        //check to see if input.x and input.y are both not equal to last moves
        if (value.Get<Vector2>() != new Vector2(0, 0))
        {
            playerTurnWayPointList.Add(transform.position);
            rawInput = value.Get<Vector2>();
            RotateHead(rawInput);
        }
    }

    private void RotateHead(Vector2 rawInput)
    {
        if (rawInput == new Vector2(0, 1))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (rawInput == new Vector2(-1, 0))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (rawInput == new Vector2(0, -1))
        {
            transform.eulerAngles = new Vector3(0, 0, 270);
        }
        else if (rawInput == new Vector2(1, 0))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
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
