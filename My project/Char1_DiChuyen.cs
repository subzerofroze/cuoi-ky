using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char1_DiChuyen : MonoBehaviour
{

    public Rigidbody2D char1;
    public float minSpeed = 1.5f;
    public float maxSpeed = 5.5f;

    void MoveCharacter()
    {

        // Tạo một hướng từ trái sang phải
        Vector2 rightDirection = Vector2.right;

        // Tạo một tốc độ ngẫu nhiên trong khoảng từ minSpeed đến maxSpeed
        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        // Đặt tốc độ di chuyển cho nhân vật
        char1.velocity = rightDirection * randomSpeed;
    }

    public void StopCharacterMovement()
    {
        // Cài đặt tốc độ di chuyển là 0 để dừng chuyển động
        char1.MovePosition(char1.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Gọi hàm MoveCharacters khi bắt đầu game
        MoveCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        float currentXPosition = transform.position.x;

        // Kiểm tra điều kiện vị trí
        if (currentXPosition >= 7.5f)
        {
            // Nếu vị trí X lớn hơn hoặc bằng 11, dừng chuyển động
            StopCharacterMovement();
        }
        else
        {
            // Nếu không, tiếp tục chuyển động
            MoveCharacter();
        }
    }
}
