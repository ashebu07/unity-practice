using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Tilemap roadTilemap;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
{
    rb = GetComponent<Rigidbody2D>();

    Vector3Int grid = roadTilemap.WorldToCell(transform.position);
    transform.position = roadTilemap.GetCellCenterWorld(grid);
}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            SetDirection(Vector2.up, 0);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            SetDirection(Vector2.down, 180);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            SetDirection(Vector2.left, 90);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            SetDirection(Vector2.right, -90);

        if (!Input.GetKey(KeyCode.UpArrow) &&
            !Input.GetKey(KeyCode.DownArrow) &&
            !Input.GetKey(KeyCode.LeftArrow) &&
            !Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = Vector2.zero;
        }
    }

void FixedUpdate()
{
    if (moveInput == Vector2.zero) return;

    Vector2 currentPosition = rb.position;
    Vector3Int currentGrid = roadTilemap.WorldToCell(currentPosition);

    bool onCorrectCenter = false;

    if (moveInput.x != 0) // 좌우 이동이면 y가 .5여야 함
        onCorrectCenter = Mathf.Abs(currentPosition.y - (Mathf.Floor(currentPosition.y) + 0.5f)) < 0.05f;
    else if (moveInput.y != 0) // 상하 이동이면 x가 .5여야 함
        onCorrectCenter = Mathf.Abs(currentPosition.x - (Mathf.Floor(currentPosition.x) + 0.5f)) < 0.05f;

    if (!onCorrectCenter)
    {
        rb.velocity = Vector2.zero;
        return;
    }

    Vector2 nextPosition = currentPosition + moveInput * moveSpeed * Time.fixedDeltaTime;
    Vector3Int nextGrid = roadTilemap.WorldToCell(nextPosition);

    if (roadTilemap.HasTile(nextGrid))
    {
        rb.MovePosition(nextPosition);
    }
    else
    {
        rb.velocity = Vector2.zero;
    }
}




void SetDirection(Vector2 direction, float rotationZ)
{
    moveInput = direction;
    transform.eulerAngles = new Vector3(0, 0, rotationZ);

    Vector3 pos = transform.position;

    if (direction.x != 0)
    {
        // 좌우 이동 → y축은 반드시 .5로 정렬
        pos.y = Mathf.Floor(pos.y) + 0.5f;
    }
    else if (direction.y != 0)
    {
        // 상하 이동 → x축은 반드시 .5로 정렬
        pos.x = Mathf.Floor(pos.x) + 0.5f;
    }

    transform.position = pos;
}


}
