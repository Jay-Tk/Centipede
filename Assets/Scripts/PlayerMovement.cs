using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float centiSpeed = 0.2f;
    void Start()
    {
        
    }

    void Update()
    {
        handleMove();
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
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
