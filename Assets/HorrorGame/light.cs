using System;
using UnityEngine;
using UnityEngine.Rendering;

public class light : MonoBehaviour
{
    private void Update()
    {
        // Получаем позицию объекта, к которому прикреплен этот скрипт
        Vector3 playerPosition = transform.position;

        // Создаем переменную для хранения Spherical Harmonics
        SphericalHarmonicsL2 sh = new SphericalHarmonicsL2();

        // Получаем интерполированные значения проб
        LightProbes.GetInterpolatedProbe(playerPosition, null, out sh);

        // Суммируем компоненты Spherical Harmonics для получения общей интенсивности света
        float intensity = sh[0, 0] + sh[1, 0] + sh[2, 0]; // Красный, зеленый и синий каналы

        // Выводим интенсивность света в консоль
        Debug.Log("Intensity of light on player: " + intensity);
    }
}
