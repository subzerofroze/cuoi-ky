using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char1 : MonoBehaviour
{

    public Transform startLine;
    public Transform finishLine;

    public Rigidbody2D Rchar1;
    public BoxCollider2D Cchar1;

    public float minSpeed = 50f;
    public float maxSpeed = 250f;

    public Vector2 direction = Vector2.right;
    public bool reversed = false; // Đánh dấu hướng di chuyển đảo ngược
    public bool movingRight = true;

    public int targetCount = 2; // Số lần cần đi qua vạch đích để dừng lại
    public int currentCount = 0; // Biến đếm số lần đã đi qua vạch đích

    public bool firstStartLineCollision = true; // Đánh dấu đã đi qua vạch xuất phát lần đầu tiên

    public float finishTime;
    public bool hasFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        MoveCharacter(Rchar1);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        // Kiểm tra nếu GameObject chạm vào startLine
        if (other.transform == startLine && !firstStartLineCollision)
        {
            //Debug.Log("Collided with the start line!");

            movingRight = true;

            // Đảo ngược hướng di chuyển và xoay nhân vật
            ReverseDirection();
        }
        // Kiểm tra nếu GameObject chạm vào finishLine
        else if (other.transform == finishLine)
        { 
            movingRight = false;

            // Tăng biến đếm số lần đi qua vạch đích
            currentCount++;

            if (currentCount < targetCount)
            {
                // Nếu chưa đi qua đủ số lần, đảo ngược hướng di chuyển và xoay nhân vật
                ReverseDirection();
            }
        }

        // Đánh dấu đã đi qua vạch xuất phát lần đầu tiên
        if (other.transform == startLine)
        {
            firstStartLineCollision = false;
        }
    }

    void ReverseDirection()
    {
        // Đảo ngược hướng di chuyển
        reversed = !reversed;

        // Đảo ngược hướng xoay của nhân vật
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        if (movingRight)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

    }

    void StopMovement(Rigidbody2D rb)
    {
        rb.velocity = Vector2.zero;
    }

    void MoveCharacter(Rigidbody2D rb)
    {

        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        // Di chuyển theo hướng và tốc độ xác định
        rb.velocity = direction * randomSpeed;

    }

    public string GetName()
    {
        // Tạo và đặt tên cho GameObject trong script
        GameObject Character1 = new GameObject("Char1Name");

        // Đặt tên cho GameObject thông qua thuộc tính name
        Character1.name = "Chad";

        return Character1.name;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (currentCount == targetCount)
        {
            StopMovement(Rchar1);
        }
        else
        {
            MoveCharacter(Rchar1);
        }

        if (currentCount == targetCount && !hasFinished)
        {
            hasFinished = true;

            finishTime = Time.time;

            Debug.Log(GetName() + " collided with the finish line at " + finishTime );
        }

        OnTriggerEnter2D(Cchar1);

        CurrentPosition();
    }

    public float CurrentPosition()
    {
        return transform.position.x;
    }

    public float FinishTime()
    {
        return finishTime;
    }
}
