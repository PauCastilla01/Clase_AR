using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Color : MonoBehaviour
{
    public GameObject model;
    public Material moño;

    // Lista de colores en formato hexadecimal
    private string[] hexColors = { "#FF8585", "#FFA07A", "#FFE680", "#98FB98", "#64C8FF", "#A68DFF", "#FFCCE5" };
    private int currentIndex = 0; // Índice del color actual

    public void ChangeColor_BTN()
    {
        // Convertir el color hexadecimal a Color
        Color newColor;
        if (ColorUtility.TryParseHtmlString(hexColors[currentIndex], out newColor))
        {
            // Aplicar el nuevo color al modelo y al moño
            model.GetComponent<Renderer>().material.color = newColor;
            moño.color = newColor;
        }

        // Cambiar al siguiente color en la lista
        currentIndex = (currentIndex + 1) % hexColors.Length;
    }
}

