using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpcionsMenu : MonoBehaviour
{
    
    public TMP_Dropdown dropdownNivells;
    public List<string> nombresEscenas; // Lista de nombres de las escenas

   
    public Button botonMenuPrincipal;

    [Header("Toggle de música")]
    public Toggle toggleMusica;

    void Start()
    {
        // Configurar Dropdown per cambiar d'escena
        if (dropdownNivells != null)
            dropdownNivells.onValueChanged.AddListener(CargarNivell);

        // Configurar botó per tornar al menú principal
        if (botonMenuPrincipal != null)
            botonMenuPrincipal.onClick.AddListener(CarregarMenuPrincipal);

        // Configurar Toggle de música
        if (toggleMusica != null && MusicManager.Instance != null)
        {
            toggleMusica.isOn = MusicManager.Instance.EstatMusicaActiva();
            toggleMusica.onValueChanged.AddListener(delegate { MusicManager.Instance.ActivarMusica(toggleMusica.isOn); });
        }
    }

    // Funció per carregar l'escena seleccionada en el Dropdown
    //alhora de cridar la funcio en el listener automaticament Unity passa l'index
    //de l'element seleccionat en el dropdown, no cal indicar-lo quan es crida
    void CargarNivell(int index)
    {
        string NomNivell = dropdownNivells.options[index].text;
        //comprovem que la string que rebem no estigui buida i llavors carreguem el nivell
        if (!string.IsNullOrEmpty(NomNivell) && !NomNivell.Equals("Opcions"))
            SceneManager.LoadScene(NomNivell);
    }

    
    void CarregarMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal"); 
    }

    private void OnDestroy()
    {
        //hem d'eliminar tots els listeners per evitar errors de referencia a
        //un objecte inexistent quan es destrueixi l'objecte al passar d'escena
        if (dropdownNivells != null)
            dropdownNivells.onValueChanged.RemoveAllListeners();

        if (botonMenuPrincipal != null)
            botonMenuPrincipal.onClick.RemoveAllListeners();

        if (toggleMusica != null)
            toggleMusica.onValueChanged.RemoveAllListeners();
    }

}
