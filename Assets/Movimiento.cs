using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Movimiento : MonoBehaviour
{
    // Objeto 3D que se moverá
    public GameObject model;

    // Lista de marcadores de imagen de Vuforia
    public ObserverBehaviour[] ImageTargets;

    // Índice del marcador actual
    public int currentTarget;

    // Velocidad del movimiento del modelo
    public float speed = 1.0f;

    // Bandera para saber si el modelo está en movimiento
    private bool isMoving = false;

    // Método para mover el modelo al siguiente marcador
    public void moveToNextMarker(int targetIndex)
    {
        // Si el modelo no está en movimiento y el índice es válido, inicia la corutina de movimiento
        if (!isMoving && targetIndex >= 0 && targetIndex < ImageTargets.Length)
        {
            StartCoroutine(MoveModel(targetIndex));
        }
    }

    // Corutina que mueve el modelo al marcador especificado
    private IEnumerator MoveModel(int targetIndex)
    {
        // Marca que el modelo está en movimiento
        isMoving = true;

        // Obtiene el marcador de destino
        ObserverBehaviour target = ImageTargets[targetIndex];

        // Verifica si el marcador es válido y está siendo rastreado
        if (target == null || !(target.TargetStatus.Status == Status.TRACKED || target.TargetStatus.Status == Status.EXTENDED_TRACKED))
        {
            isMoving = false; // Si no es válido, cancela el movimiento
            yield break;
        }

        // Guarda las posiciones de inicio y destino
        Vector3 startPosition = model.transform.position;
        Vector3 endPosition = target.transform.position;

        // Variable para calcular el progreso del movimiento
        float journey = 0;

        // Interpola la posición del modelo hasta llegar al destino
        while (journey <= 1f)
        {
            journey += Time.deltaTime * speed; // Incrementa el progreso basado en el tiempo y la velocidad
            model.transform.position = Vector3.Lerp(startPosition, endPosition, journey); // Mueve el modelo suavemente
            yield return null; // Espera al siguiente frame
        }

        // Marca que el modelo ha terminado de moverse
        isMoving = false;
    }
}
