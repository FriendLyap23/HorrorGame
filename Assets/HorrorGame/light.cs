using System;
using UnityEngine;
using UnityEngine.Rendering;

public class light : MonoBehaviour
{
    private void Update()
    {
        // �������� ������� �������, � �������� ���������� ���� ������
        Vector3 playerPosition = transform.position;

        // ������� ���������� ��� �������� Spherical Harmonics
        SphericalHarmonicsL2 sh = new SphericalHarmonicsL2();

        // �������� ����������������� �������� ����
        LightProbes.GetInterpolatedProbe(playerPosition, null, out sh);

        // ��������� ���������� Spherical Harmonics ��� ��������� ����� ������������� �����
        float intensity = sh[0, 0] + sh[1, 0] + sh[2, 0]; // �������, ������� � ����� ������

        // ������� ������������� ����� � �������
        Debug.Log("Intensity of light on player: " + intensity);
    }
}
