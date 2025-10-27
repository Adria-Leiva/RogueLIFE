using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;//Cal fer l'importació per poder manipular TextMeshPro

public class MenuFinal : MonoBehaviour
{
    public GameObject menuFinal;
    

    public static MenuFinal instance; //es crea una instància global per accedir des d'altres scripts

    public TMP_Text titolResultat;
    public TMP_Text ResultatFinalColectibles;


    private void Start()
    {
        Cursor.visible = true;
        
        Cursor.lockState = CursorLockMode.None;

        // Mostrar cantidad de coleccionables
        ResultatFinalColectibles.text = "Coleccionables: "+DadesNivells.collectibles + " / " + DadesNivells.totalColectibles;

        // Mostrar Victoria o Derrota
        //titolResultat.text = DadesNivells.victoria ? "Victoria!" : "Derrota!";

        if (DadesNivells.collectibles == DadesNivells.totalColectibles) {
            titolResultat.text = "Victoria!";
        }
        else
        {
            titolResultat.text = "Derrota!";
        }

    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.ActivarMusica(true);
        }
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void Sortir()
    {
               Application.Quit();
    }
}
