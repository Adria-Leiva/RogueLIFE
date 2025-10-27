using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jugar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Nivell_1", LoadSceneMode.Single);
    }
    public void Sortir()
    {
        Application.Quit();
    }

    public void LoadOpcions()
    {
                SceneManager.LoadScene("MenuOpcions");
    }
}
