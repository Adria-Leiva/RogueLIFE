using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptPausa : MonoBehaviour
{
    public GameObject ObjecteMenuPausa;
    public bool Pausa = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Pausa == false)
            {
                ObjecteMenuPausa.SetActive(true);
                Pausa = true;

                Time.timeScale = 0; //el valor de 0 indica que el temps està aturat
                Cursor.visible = true;
                //per evitar que el cursor quedi bloquejat al centre de la pantalla
                Cursor.lockState = CursorLockMode.None; 

                if(MusicManager.Instance != null)
                {
                    MusicManager.Instance.ActivarMusica(false);
                }
            }
            else if (Pausa == true)
            {
                ReprendreJoc();
            }
        }
    }

    public void ReprendreJoc()
    {
        ObjecteMenuPausa.SetActive(false);
        Pausa = false;
        Time.timeScale = 1; //el valor de 1 indica que el temps va a la velocitat normal
        Cursor.visible = false;


        //per bloquejar el cursor al centre de la pantalla
        Cursor.lockState = CursorLockMode.Locked;


        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.ActivarMusica(true);
        }
    }

    public void GoMainMenu(string NomMainMenu)
    {
        Time.timeScale = 1; 
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.ActivarMusica(true);
        }
        SceneManager.LoadScene(NomMainMenu,LoadSceneMode.Single);

    }
    public void SortirJoc()
    {
        Application.Quit();
    }
}
