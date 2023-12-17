using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnimation : MonoBehaviour
{
    public float elapsedTime;

    // Hàm tạo AnimationCurve, bạn có thể chỉnh sửa curve trong Inspector
    public AnimationCurve JumpCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);

    // Hàm bắt đầu chuyển động
    public void StartJump()
    {
        elapsedTime = 0f;
    }


    public float jumpHeight = 2.0f;
    public float jumpDuration = 2.0f;

    public float jumpStartTime;

    void Start()
    {
        jumpStartTime = Time.time;
    }

    void Update()
    {
        UpdateJump();
    }

    void UpdateJump()
    {
        float elapsedTime = Time.time - jumpStartTime;
        float t = (Mathf.Sin(elapsedTime / jumpDuration * Mathf.PI * 2) + 1) / 2;

        // Di chuyển nhân vật theo hình dạng của hàm nhảy lên xuống
        float yOffset = Mathf.Lerp(0, jumpHeight, t);
        transform.position = new Vector3(transform.position.x, yOffset, transform.position.z);

        // Khi nhảy xong, đặt lại thời gian bắt đầu nhảy
        if (elapsedTime > jumpDuration)
        {
            jumpStartTime = Time.time;
        }
    }
}
