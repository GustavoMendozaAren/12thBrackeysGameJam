using System.Collections;
using TMPro;
using UnityEngine;

public class MaquinaDeEscribir : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Asigna el componente TextMeshProUGUI
    public float totalDuration = 2f; // Duración total para escribir el texto (en segundos)
    public float fadeDuration = 0.3f; // Tiempo que tarda cada letra en aparecer completamente

    private string fullText; // Texto completo del TextMeshPro

    private void Start()
    {
        if (textMeshPro == null)
            textMeshPro = GetComponent<TextMeshProUGUI>();

        fullText = textMeshPro.text; // Obtén el texto del TextMeshPro
        textMeshPro.text = ""; // Asegúrate de que el texto inicial esté vacío

        StartCoroutine(ShowTextWithGlobalDuration());
    }

    private IEnumerator ShowTextWithGlobalDuration()
    {
        textMeshPro.text = fullText; // Configura el texto completo para procesar los caracteres
        textMeshPro.ForceMeshUpdate();
        textMeshPro.alpha = 1; // Asegúrate de que el texto general sea visible

        TMP_TextInfo textInfo = textMeshPro.textInfo;

        // Calcula el delay entre letras basado en la duración total
        int visibleCharactersCount = 0;
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (textInfo.characterInfo[i].isVisible) visibleCharactersCount++;
        }

        float letterDelay = totalDuration / Mathf.Max(visibleCharactersCount, 1);

        // Inicializa la transparencia de todas las letras
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            SetAlphaForCharacter(i, 0);
        }

        // Anima letra por letra
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (textInfo.characterInfo[i].isVisible) // Solo procesa caracteres visibles
            {
                StartCoroutine(FadeInCharacter(i));
                yield return new WaitForSeconds(letterDelay);
            }
        }
    }

    private IEnumerator FadeInCharacter(int index)
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            SetAlphaForCharacter(index, alpha);
            yield return null;
        }

        // Asegúrate de que el alpha sea 100% al finalizar
        SetAlphaForCharacter(index, 1);
    }

    private void SetAlphaForCharacter(int index, float alpha)
    {
        TMP_TextInfo textInfo = textMeshPro.textInfo;

        var charInfo = textInfo.characterInfo[index];
        if (!charInfo.isVisible) return;

        int vertexIndex = charInfo.vertexIndex;
        Color32[] vertexColors = textInfo.meshInfo[charInfo.materialReferenceIndex].colors32;

        // Modifica el alpha de los vértices del carácter
        for (int j = 0; j < 4; j++)
        {
            vertexColors[vertexIndex + j].a = (byte)(alpha * 255);
        }

        // Actualiza la malla con los nuevos colores
        textMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
    }
}
