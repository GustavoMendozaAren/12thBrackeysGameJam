using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColocarTorreta : MonoBehaviour
{

    bool modoContruccion = false;
    bool faroTower = false;
    bool archerTower = false;

    [Header("PANEL DE CONSTRUCCION")]
    [SerializeField] private GameObject panelDeCosntruccion;

    [Header("TORRETAS")]
    [SerializeField] private GameObject torretaPrefab;
    [SerializeField] private GameObject faroPrefab;

    [Header("PREVIEW TORRETAS")]
    [SerializeField] private GameObject torretaPreviewPrefab;
    [SerializeField] private GameObject faroPreviewPrefab;

    [Header("COSAS MAPA")]
    [SerializeField] private Grid grid;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase tilePermitido;

    [Header("SCRIPTS LLAMADOS")]
    [SerializeField] private TimerManagerScript timerManager;

    private GameObject previewActual = null;

    // Lista para almacenar las posiciones de las torretas ya colocadas
    private List<Vector3Int> posicionesDeTorretas = new List<Vector3Int>();

    void Update()
    {
        if (modoContruccion && previewActual != null)
        {
            ColocarTorretaYPreview();
        }

        ActualizarPanelDeConstruccion();
    }

    void ColocarTorretaYPreview()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        Vector3 worldPosition = grid.CellToWorld(gridPosition);
        Vector3 ajusteCentro = new Vector3(grid.cellSize.x / 2, grid.cellSize.y / 2, 0);

        previewActual.transform.position = worldPosition + ajusteCentro;

        if (Input.GetMouseButtonDown(0) && EsTileValidoParaColocar(gridPosition))
        {
            ColocarTorretaEn(gridPosition);
            timerManager.DayTimeMin -= 3;
            modoContruccion = false;

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
                previewActual.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else
            {
                previewActual.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    bool EsTileValidoParaColocar(Vector3Int posicion)
    {
        TileBase tileActual = tilemap.GetTile(posicion);

        // Verifica si el tile es permitido y si no hay torretas en esa posición
        return tileActual == tilePermitido && !posicionesDeTorretas.Contains(posicion);
    }

    void ColocarTorretaEn(Vector3Int posicion)
    {
        Vector3 worldPosition = grid.CellToWorld(posicion);
        Vector3 ajusteCentro = new Vector3(grid.cellSize.x / 2, grid.cellSize.y / 2, 0);

        if (archerTower)
            Instantiate(torretaPrefab, worldPosition + ajusteCentro, Quaternion.identity);

        if (faroTower)
            Instantiate(faroPrefab, worldPosition + ajusteCentro, Quaternion.identity);

        // Añade la posición a la lista para evitar colocar otra torreta encima
        posicionesDeTorretas.Add(posicion);
    }

    public void ArcherTowerBttn()
    {
        modoContruccion = true;
        archerTower = true;

        if (previewActual != null)
            Destroy(previewActual);

        previewActual = Instantiate(torretaPreviewPrefab);

        ActualizarAldeanosDisponibles();
    }

    public void FaroTowerBttn()
    {
        modoContruccion = true;
        faroTower = true;

        if (previewActual != null)
            Destroy(previewActual);

        previewActual = Instantiate(faroPreviewPrefab);

        ActualizarAldeanosDisponibles();
    }

    void ActualizarAldeanosDisponibles()
    {
        StaticVariables.cantidadBuildersDisponibles--;

        TextMeshProUGUI spareBuildersTxt = GameObject.Find("BuildersDisponibles_Txt").GetComponent<TextMeshProUGUI>();
        spareBuildersTxt.text = "SPARE: " + StaticVariables.cantidadBuildersDisponibles;
    }

    void ActualizarPanelDeConstruccion()
    {
        if(timerManager.DayTimeMin < 3 || StaticVariables.cantidadBuildersDisponibles < 1)
        {
            panelDeCosntruccion.SetActive(false);
        }
        else
        {
            panelDeCosntruccion.SetActive(true);
        }
    }
}
