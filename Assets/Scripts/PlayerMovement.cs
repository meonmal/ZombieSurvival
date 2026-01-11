using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 플레이어의 이동속도
    public float moveSpeed = 5f;
    // 플레이어의 회전속도
    public float rotateSpeed = 180f;

    // 플레이어의 입력감지
    private PlayerInput playerInput;
    // 플레이어의 리지드바디
    private Rigidbody playerRigidbody;
    // 플레이어의 애니메이터
    private Animator playerAnimator;

    private void Start()
    {
        // 컴포넌트 가져오기
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // 물리 갱신 주기에 맞춰 실행됨
    private void FixedUpdate()
    {
        // 회전 실행
        Rotate();
        // 움직임 실행
        Move();

        // 입력값에 따라 애니메이터의 Move 파라미터값 변경
        playerAnimator.SetFloat("Move", playerInput.move);
    }

    private void Move()
    {
        // 상대적으로 이동할 거리 계산
        Vector3 moveDistance = playerInput.move * transform.forward * moveSpeed * Time.deltaTime;
        // 리지드바디로 오브젝트의 위치 변경
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }

    private void Rotate()
    {
        // 상대적으로 회전할 수치 계산
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;
        // 리지드바디를 이용해 게임 오브젝트 회전 변경
        playerRigidbody.rotation = playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);
    }
}
