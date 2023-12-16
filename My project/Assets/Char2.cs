﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char2 : MonoBehaviour
{
    public DiChuyen diChuyen;

    public Transform startLine;
    public Transform finishLine;

    public Rigidbody2D Rchar2;
    public BoxCollider2D Cchar2;

    public Animator animator;

    public float minSpeed = 125f;
    public float maxSpeed = 150f;
    //phan them vao
    public float currentSpeed;
    public float randomSpeed;
    public float distanceTraveled = 0f;
    public bool hasEncounteredAnimation = false;
    public bool hasEncounteredAnimation2 = false;

    public float elapsedTime = 0f;
    public float elapsedTime2 = 0f;

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
        MoveCharacter(Rchar2);
        diChuyen = GameObject.FindGameObjectWithTag("Set1").GetComponent<DiChuyen>();
        animator = GetComponent<Animator>();
        randomSpeed = Random.Range(minSpeed, maxSpeed);
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
            else
            {
                if (diChuyen.Ranking(this) == 1)
                {
                    animator.SetTrigger("JumpTrigger");
                }
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
        //xoa float vi da khai bao o tren
        //randomSpeed = Random.Range(minSpeed, maxSpeed);
        //Them
        currentSpeed = randomSpeed;

        //Chinh sua 1 xiu
        // Di chuyển theo hướng và tốc độ xác định
        rb.velocity = direction * currentSpeed;

    }

    public string GetName()
    {
        // Tạo và đặt tên cho GameObject trong script
        GameObject Character2 = new GameObject("Char2Name");

        // Đặt tên cho GameObject thông qua thuộc tính name
        Character2.name = "Brock";

        return Character2.name;
    }

    // Update is called once per frame

    // Ham bua them vao
    private IEnumerator EncounterAnimation()
    {
        // Mark that the character has encountered an animation
        hasEncounteredAnimation = true;

        int randomValue = UnityEngine.Random.Range(1, 101);

        int selectedAnimation;

        if (randomValue <= 90) // 90% chance (4/5) for each case 1-5
        {
            selectedAnimation = UnityEngine.Random.Range(1, 6);
        }
        else // 10% chance for case 6
        {
            selectedAnimation = 6;
        }

        switch (selectedAnimation)
        {
            case 1:
                Debug.Log("Slow down for 3 seconds.");
                diChuyen.addtext.text = GetName() + " got slow down for 3 seconds.";
                randomSpeed /= 2; // Slow down the speed
                yield return new WaitForSeconds(3f);
                randomSpeed *= 2;
                break;
            case 2:
                Debug.Log("Speed up for 3 seconds.");
                diChuyen.addtext.text = GetName() + " got speed up for 3 seconds.";
                randomSpeed *= 2; // Speed up the speed
                yield return new WaitForSeconds(3f);
                randomSpeed /= 2;
                break;
            case 3:
                Debug.Log("Sudden stop for 3 seconds.");
                diChuyen.addtext.text = GetName() + " got sudden stop for 3 seconds.";
                float temp = randomSpeed;
                randomSpeed = 0f; //Stop the character
                animator.enabled = false; //Stop the animation
                yield return new WaitForSeconds(3f);
                randomSpeed = temp;
                break;
            case 4:
                Debug.Log("Teleport forward 10 meters.");
                diChuyen.addtext.text = GetName() + " move forward 3 meters.";
                Transform Char2transform = transform;
                Vector2 Char2position = Char2transform.position;
                float xPosition = Char2position.x;
                distanceTraveled += 150f; // Teleport forward by 3 meters
                Char2position.x = xPosition + distanceTraveled;
                Rchar2.position = Char2position; // Update the character position
                MoveCharacter(Rchar2); // Start the race again
                yield break;

            case 5:
                Debug.Log("Teleport backward 10 meters.");
                diChuyen.addtext.text = GetName() + " move backward 3 meters.";
                Char2transform = transform;
                Char2position = Char2transform.position;
                xPosition = Char2position.x;
                distanceTraveled -= 150f; // Teleport backward by 3 meters
                Char2position.x = xPosition + distanceTraveled;
                Rchar2.position = Char2position; // Update the character position
                MoveCharacter(Rchar2); // Start the race again
                yield break;
            case 6:
                Debug.Log("Teleport backward to start line.");
                diChuyen.addtext.text = GetName() + " move backward to start line.";
                Char2transform = transform;
                Char2position = Char2transform.position;
                Char2position.x = startLine.position.x + 25f; // Teleport backward startLine
                Rchar2.position = Char2position; // Update the character position
                MoveCharacter(Rchar2); // Start the race again
                yield break;
        }

        // Wait for 3 seconds while the animation is active
        if (selectedAnimation == 3)
        {
            MoveCharacter(Rchar2);
            animator.enabled = true;
        }
        // Resume normal speed after encountering the animation
        currentSpeed = randomSpeed;

    }
    void Update()
    {
        if (currentCount == targetCount)
        {
            StopMovement(Rchar2);
        }
        else
        {
            MoveCharacter(Rchar2);
        }

        OnTriggerEnter2D(Cchar2);

        if (!hasEncounteredAnimation2)
        {
            elapsedTime2 += Time.deltaTime;

            if (elapsedTime2 >= 25f)
            {
                hasEncounteredAnimation2 = true;
                int randomValue2 = UnityEngine.Random.Range(1, 101);
                //10% chance to teleport to finished line
                if (randomValue2 >= 90)
                {
                    Debug.Log("Teleport to finished line.");
                    diChuyen.addtext.text = GetName() + " teleport to finished line.";
                    Transform Char2transform = transform;
                    Vector2 Char2position = Char2transform.position;
                    Char2position.x = finishLine.position.x; //Nhảy đến vạch đích và dừng chuyển động
                    Rchar2.position = Char2position;
                    StopMovement(Rchar2);
                }
            }
        }

        //phan them vao
        if (!hasEncounteredAnimation)
        {
            elapsedTime += Time.deltaTime;

            float randomTime = Random.Range(4f, 7f);

            // Check if a few seconds have passed before encountering an animation
            if (elapsedTime >= randomTime)
            {
                StartCoroutine(EncounterAnimation());
            }
        }

        if (currentCount == targetCount && !hasFinished)
        {
            hasFinished = true;

            finishTime = Time.time;

            Debug.Log(GetName() + " collided with the finish line at " + finishTime);
        }

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
