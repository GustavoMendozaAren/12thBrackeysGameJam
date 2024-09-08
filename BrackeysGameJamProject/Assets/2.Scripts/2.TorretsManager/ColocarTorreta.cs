using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColocarTorreta : MonoBehaviour
{
    bool modoContruccion = false;
    [SerializeField] private GameObject torretaPrefab;
    [SerializeField] private GameObject previewTorreta;
    [SerializeField] private Grid grid;  // Arrastra tu Grid aquí desde el inspector
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase tilePermitido;  // El tipo de Tile en el que se puede colocar torretas
    

    public TimerManagerScript timerManager;

    void Update()
    {
        if(modoContruccion)
            ColocarTorretaYPreview();
    }

    void ColocarTorretaYPreview()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        // Ajustar la posición de la vista previa al centro de la celda
        Vector3 worldPosition = grid.CellToWorld(gridPosition);
        Vector3 ajusteCentro = new Vector3(grid.cellSize.x / 2, grid.cellSize.y / 2, 0);
        // Mover la vista previa de la torreta a la posición corregida
        previewTorreta.transform.position = worldPosition + ajusteCentro;

        if (Input.GetMouseButtonDown(0) && EsTileValidoParaColocar(gridPosition))
        {
            ColocarTorretaEn(gridPosition);
            timerManager.DayTime -= 3;
            modoContruccion = false;
        }

        ColoresDeValidacion(gridPosition);
    }

    void ColoresDeValidacion(Vector3Int _gridPosition)
    {
        if (EsTileValidoParaColocar(_gridPosition))
        {
            previewTorreta.GetComponent<SpriteRenderer>().color = Color.blue;  // Color normal
        }
        else
        {
            previewTorreta.GetComponent<SpriteRenderer>().color = Color.red;    // Color de advertencia
        }
    }

    bool EsTileValidoParaColocar(Vector3Int posicion)
    {
        // Obtenemos el Tile en la posición de la cuadrícula
        TileBase tileActual = tilemap.GetTile(posicion);

        // Comparamos si el Tile es igual al tipo permitido
        if (tileActual == tilePermitido)
        {
            return true;  // Es un tile donde se puede colocar la torreta
        }

        return false;  // No es un tile válido, no colocar torreta
    }

    void ColocarTorretaEn(Vector3Int posicion)
    {
        Vector3 worldPosition = grid.CellToWorld(posicion);  // Convertir la celda a coordenadas del mundo
        Vector3 ajusteCentro = new Vector3(grid.cellSize.x / 2, grid.cellSize.y / 2, 0);
        Instantiate(torretaPrefab, worldPosition + ajusteCentro, Quaternion.identity);
    }

    public void ModoContruccionAcitvado()
    {
        modoContruccion = true;
    }
}
