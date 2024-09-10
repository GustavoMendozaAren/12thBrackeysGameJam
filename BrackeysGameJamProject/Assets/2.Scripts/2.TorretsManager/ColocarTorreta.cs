using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColocarTorreta : MonoBehaviour
{
    /*
    bool modoContruccion = false;
    bool faroTower = false;
    bool archerTower = false;

    [Header("TORRETAS")]
    [SerializeField] private GameObject torretaPrefab;
    [SerializeField] private GameObject faroPrefab;

    [Header("PREVIEW TORRETAS")]
    [SerializeField] private GameObject previewTorreta;
    [SerializeField] private GameObject previewFaro;

    [Header("COSAS MAPA")]
    [SerializeField] private Grid grid;  // Arrastra tu Grid aquí desde el inspector
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase tilePermitido;  // El tipo de Tile en el que se puede colocar torretas

    [Header("SCRIPTS LLAMADOS")]
    [SerializeField] private TimerManagerScript timerManager;

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

        // PREVIEW DE LAS TORRERTAS
        if(faroTower)
            previewFaro.transform.position = worldPosition + ajusteCentro;

        if(archerTower)
            previewTorreta.transform.position = worldPosition + ajusteCentro;

        if (Input.GetMouseButtonDown(0) && EsTileValidoParaColocar(gridPosition))
        {
            ColocarTorretaEn(gridPosition);
            timerManager.DayTimeMin -= 3;
            modoContruccion = false;
            faroTower = false;
            archerTower = false;
        }

        ColoresDeValidacion(gridPosition);
    }

    void ColoresDeValidacion(Vector3Int _gridPosition)
    {
        if (EsTileValidoParaColocar(_gridPosition))
        {
            if(archerTower)
                previewTorreta.GetComponent<SpriteRenderer>().color = Color.blue;  // Color normal

            if (faroTower)
                previewFaro.GetComponent<SpriteRenderer>().color = Color.blue;  // Color normal
        }
        else
        {
            if (archerTower)
                previewTorreta.GetComponent<SpriteRenderer>().color = Color.red;    // Color de advertencia

            if (faroTower)
                previewFaro.GetComponent<SpriteRenderer>().color = Color.red;    // Color de advertencia
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

        if(archerTower)
            Instantiate(torretaPrefab, worldPosition + ajusteCentro, Quaternion.identity);

        if (faroTower)
            Instantiate(faroPrefab, worldPosition + ajusteCentro, Quaternion.identity);
    }

    public void ArcherTowerBttn()
    {
        modoContruccion = true;
        archerTower = true;
    }

    public void FaroTowerBttn()
    {
        modoContruccion = true;
        faroTower = true;
    }
    */

    bool modoContruccion = false;
    bool faroTower = false;
    bool archerTower = false;

    [Header("TORRETAS")]
    [SerializeField] private GameObject torretaPrefab;
    [SerializeField] private GameObject faroPrefab;

    [Header("PREVIEW TORRETAS")]
    [SerializeField] private GameObject torretaPreviewPrefab;  // Prefab para el preview de la torreta con rango
    [SerializeField] private GameObject faroPreviewPrefab;     // Prefab para el preview del faro con rango

    [Header("COSAS MAPA")]
    [SerializeField] private Grid grid;  // Arrastra tu Grid aquí desde el inspector
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase tilePermitido;  // El tipo de Tile en el que se puede colocar torretas

    [Header("SCRIPTS LLAMADOS")]
    [SerializeField] private TimerManagerScript timerManager;

    private GameObject previewActual = null;  // Referencia al preview instanciado

    void Update()
    {
        if (modoContruccion && previewActual != null)
        {
            ColocarTorretaYPreview();
        }
    }

    void ColocarTorretaYPreview()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        // Ajustar la posición de la vista previa al centro de la celda
        Vector3 worldPosition = grid.CellToWorld(gridPosition);
        Vector3 ajusteCentro = new Vector3(grid.cellSize.x / 2, grid.cellSize.y / 2, 0);

        // Mueve la vista previa a la posición del ratón
        previewActual.transform.position = worldPosition + ajusteCentro;

        if (Input.GetMouseButtonDown(0) && EsTileValidoParaColocar(gridPosition))
        {
            ColocarTorretaEn(gridPosition);
            timerManager.DayTimeMin -= 3;
            modoContruccion = false;

            // Desactiva el preview
            Destroy(previewActual);
            previewActual = null;
            faroTower = false;
            archerTower = false;
        }

        ColoresDeValidacion(gridPosition);
    }

    void ColoresDeValidacion(Vector3Int _gridPosition)
    {
        if (previewActual != null)
        {
            if (EsTileValidoParaColocar(_gridPosition))
            {
                previewActual.GetComponent<SpriteRenderer>().color = Color.blue;  // Color normal
            }
            else
            {
                previewActual.GetComponent<SpriteRenderer>().color = Color.red;   // Color de advertencia
            }
        }
    }

    bool EsTileValidoParaColocar(Vector3Int posicion)
    {
        TileBase tileActual = tilemap.GetTile(posicion);

        return tileActual == tilePermitido;  // Verifica si el Tile es el permitido
    }

    void ColocarTorretaEn(Vector3Int posicion)
    {
        Vector3 worldPosition = grid.CellToWorld(posicion);
        Vector3 ajusteCentro = new Vector3(grid.cellSize.x / 2, grid.cellSize.y / 2, 0);

        if (archerTower)
            Instantiate(torretaPrefab, worldPosition + ajusteCentro, Quaternion.identity);

        if (faroTower)
            Instantiate(faroPrefab, worldPosition + ajusteCentro, Quaternion.identity);
    }

    public void ArcherTowerBttn()
    {
        modoContruccion = true;
        archerTower = true;

        // Elimina el preview anterior si existe
        if (previewActual != null)
            Destroy(previewActual);

        // Instancia el nuevo preview
        previewActual = Instantiate(torretaPreviewPrefab);
    }

    public void FaroTowerBttn()
    {
        modoContruccion = true;
        faroTower = true;

        // Elimina el preview anterior si existe
        if (previewActual != null)
            Destroy(previewActual);

        // Instancia el nuevo preview
        previewActual = Instantiate(faroPreviewPrefab);
    }
}
