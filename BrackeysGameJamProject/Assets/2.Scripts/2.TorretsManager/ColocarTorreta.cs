using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarTorreta : MonoBehaviour
{
    [SerializeField] private GameObject torretaPrefab;
    [SerializeField] private GameObject previewTorreta;
    [SerializeField] private Grid grid;  // Arrastra tu Grid aquí desde el inspector

    void Update()
    {
        ColocarTorretaTorreta();
    }

    bool EsCeldaVacia(Vector3Int posicion)
    {
        // Aquí puedes añadir tu lógica para verificar si la celda está vacía
        // Por ejemplo, guardar un array de celdas ocupadas
        return true;  // Por ahora, asumimos que siempre está vacía
    }

    void ColocarTorretaEn(Vector3Int posicion)
    {
        Vector3 worldPosition = grid.CellToWorld(posicion);  // Convertir la celda a coordenadas del mundo
        Vector3 ajusteCentro = new Vector3(grid.cellSize.x / 2, grid.cellSize.y / 2, 0);
        Instantiate(torretaPrefab, worldPosition + ajusteCentro, Quaternion.identity);
    }

    void ColocarTorretaTorreta()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        // Ajustar la posición de la vista previa al centro de la celda
        Vector3 worldPosition = grid.CellToWorld(gridPosition);
        Vector3 ajusteCentro = new Vector3(grid.cellSize.x / 2, grid.cellSize.y / 2, 0);

        // Mover la vista previa de la torreta a la posición corregida
        previewTorreta.transform.position = worldPosition + ajusteCentro;

        if (Input.GetMouseButtonDown(0) && EsCeldaVacia(gridPosition))
        {
            ColocarTorretaEn(gridPosition);
        }
    }
}
