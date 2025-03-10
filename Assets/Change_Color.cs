using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Color : MonoBehaviour
{
    public GameObject model;
    public Material moño;

    // Nuevo material público que se puede asignar desde el Inspector
    public Material materialDeVestido;

    // Lista de colores en formato hexadecimal
    private string[] hexColors = { "#FF8585", "#FFA07A", "#FFE680", "#98FB98", "#64C8FF", "#A68DFF", "#FFCCE5" };
    private int lastIndex = -1; // Último índice usado

    private Texture[] texturas; // Arreglo para almacenar las texturas

    private int lastTextureIndex = -1; // Última textura usada

    void Start()
    {
        // Cargar todas las texturas desde la carpeta Resources/Texturas
        texturas = Resources.LoadAll<Texture>("Texturas");
    }

    public void ChangeColor_BTN()
    {
        int newTextureIndex;

        // Asegurarse de que la nueva textura sea diferente a la anterior
        do
        {
            newTextureIndex = Random.Range(0, texturas.Length);
        } while (newTextureIndex == lastTextureIndex);

        lastTextureIndex = newTextureIndex; // Guardar el nuevo índice de la textura

        // Aplicar la nueva textura al material asignado
        materialDeVestido.SetTexture("_MainTex", texturas[newTextureIndex]);

        // Opcional: Cambiar el color del modelo, si se desea
        int newColorIndex;
        do
        {
            newColorIndex = Random.Range(0, hexColors.Length);
        } while (newColorIndex == lastIndex);

        lastIndex = newColorIndex; // Guardar el nuevo índice de color

        // Convertir el color hexadecimal a Color
        if (ColorUtility.TryParseHtmlString(hexColors[newColorIndex], out Color newColor))
        {
            // Aplicar el nuevo color al modelo y al moño
            model.GetComponent<Renderer>().material.color = newColor;
            moño.color = newColor;
        }
    }
}