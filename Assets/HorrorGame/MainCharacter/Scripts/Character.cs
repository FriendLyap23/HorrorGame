using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    private const float _gravity = -9.81f;

    [SerializeField] private float _speed;

    [Space(10)]
    [SerializeField] private Transform _groundCheckerPivot;
    [SerializeField] private float _checkGroundRadious;
    [SerializeField] private LayerMask _groundMask;

    private CharacterController _controller;
    private Vector3 _moveDirection;

    private float _velocityFall;

    [field: SerializeField] public Transform Head { get; set; }
    [field: SerializeField] public Transform Hand { get; set; }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        _moveDirection = (forward * moveZ + right * moveX);
    }

    private void FixedUpdate()
    {
        if (IsOnTheGround())
            _velocityFall = -2;

        MovementCharacter(_moveDirection);
        DoGravity();
    }

    private bool IsOnTheGround()
    {
        bool result = Physics.CheckSphere(_groundCheckerPivot.position, _checkGroundRadious, _groundMask);
        return result;
    }

    private void MovementCharacter(Vector3 direction)
    {
        _controller.Move(direction * _speed * Time.fixedDeltaTime);
    }

    private void DoGravity()
    {
        _velocityFall += _gravity * Time.fixedDeltaTime;
        _controller.Move(Vector3.up * _velocityFall * Time.fixedDeltaTime);
    }
}