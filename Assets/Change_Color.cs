using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Color : MonoBehaviour
{
    public GameObject model;
    public Material moño;

    // Lista de colores en formato hexadecimal
    private string[] hexColors = { "#FF8585", "#FFA07A", "#FFE680", "#98FB98", "#64C8FF", "#A68DFF", "#FFCCE5" };
    private int lastIndex = -1; // Último índice usado

    public void ChangeColor_BTN()
    {
        int newIndex;

        // Asegurar que el nuevo color sea diferente al anterior
        do
        {
            newIndex = Random.Range(0, hexColors.Length);
        } while (newIndex == lastIndex);

        lastIndex = newIndex; // Guardar el nuevo índice

        // Convertir el color hexadecimal a Color
        if (ColorUtility.TryParseHtmlString(hexColors[newIndex], out Color newColor))
        {
            // Aplicar el nuevo color al modelo y al moño
            model.GetComponent<Renderer>().material.color = newColor;
            moño.color = newColor;
        }
    }
}


