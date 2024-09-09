using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform Player;
    public float CameraSpeed;
    public Vector2 AreaCenter;
    public Vector2 AreaSize;

    private float cameraHalfHeight;
    private float cameraHalfWidth;

    void Start()
    {
        // 월드공간에서의 카메라 가로, 세로 구하기
        cameraHalfHeight = Camera.main.orthographicSize; // 화면 높이의 절반 크기
        cameraHalfWidth = cameraHalfHeight * Screen.width / Screen.height; // 월드 가로 = 월드 세로 * 스크린 가로 / 스크린 세로
    }
    
    private void OnDrawGizmos()
    {
        // 카메라 제한 영역 잘 보이기 표시하기: center를 중심으로 size크기의 큐브를 표시함.
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(AreaCenter, AreaSize);
    }

    void LateUpdate()
    {
        // 카메라 부드럽게 target 따라다니기.
        // Vector.Lerp(a, b, c): a와 b 사이의 벡터값을 반환
        // Time.deltaTime: 전 프레임이 완료된 시간
        Vector3 targetPosition = Player.position + new Vector3(0f, 0.6f, 0f);
        transform.position = Vector3.Lerp(transform.position, targetPosition, CameraSpeed * Time.deltaTime);

        // 카메라 제한 영역 안에서만 움직이게 하기.
        float maxX = AreaSize.x * 0.5f - cameraHalfWidth;
        float clampX = Mathf.Clamp(transform.position.x, AreaCenter.x - maxX, AreaCenter.x + maxX);
        float maxY = AreaSize.y * 0.5f - cameraHalfHeight;
        float clampY = Mathf.Clamp(transform.position.y, AreaCenter.y - maxY, AreaCenter.y + maxY);
        transform.position = new Vector3(clampX, clampY, -10f); // z값 고정해놔야 카메라가 화면 밖으로 안 나감.
    }
}
