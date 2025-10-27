using UnityEngine;
using UnityEngine.UI;
public class BotoMusica : MonoBehaviour
{
    public Toggle toggleMusica;

    void Start()
    {
        // Configurar el toggle depenent si la música està activa o no
        if (MusicManager.Instance != null)
            toggleMusica.isOn = MusicManager.Instance.EstatMusicaActiva();

        // Afegeix el listener per canviar l'estat de la música quan es modifiqui el toggle
        toggleMusica.onValueChanged.AddListener(delegate { CambiarMusica(toggleMusica.isOn); });
    }

    void CambiarMusica(bool activada)
    {
        if (MusicManager.Instance != null)
            MusicManager.Instance.ActivarMusica(activada);
    }

    private void OnDestroy()
    {
        toggleMusica.onValueChanged.RemoveAllListeners();
    }
}

