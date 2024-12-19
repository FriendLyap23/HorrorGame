using Cinemachine;
using UnityEngine;
using Zenject;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private float _sensitivity;

    private CinemachineVirtualCamera _virtualCamera;
    public CinemachinePOV _cinemachinePOV;
    private CinemachineTransposer _cinemachineTransposer;

    private Character _character;

    [Inject]
    public void Constructor(Character character)
    {
        _character = character;
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _cinemachinePOV = _virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        _cinemachineTransposer = _virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

        SetVirtualCamera();
    }

    private void SetVirtualCamera()
    {
        _virtualCamera.Follow = _character.Head;

        //The displacement of the camera relative to the character
        _cinemachineTransposer.m_FollowOffset = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        _cinemachinePOV.m_VerticalAxis.m_MaxSpeed = _sensitivity;
        _cinemachinePOV.m_HorizontalAxis.m_MaxSpeed = _sensitivity;

        _character.Hand.transform.rotation = Quaternion.Euler(_cinemachinePOV.m_VerticalAxis.Value, 
            _cinemachinePOV.m_HorizontalAxis.Value, 0);
    }
}
