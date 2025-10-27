using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public float tempsInicial; //el jugador tindra 3 minuts per completar el nivell

    private float tempsRestant;
    private bool tempsAcabat = false;
    private bool pausa = false;

    public TMP_Text textTemporitzador;

    void Start()
    {
        tempsRestant = tempsInicial;
        ActualitzarHUDTemps();
    }

    // Update is called once per frame
    void Update()
    {
        if (pausa)
        {
            return;
        }

        //Time.deltaTime es el temps entre frames, el fem servir per restar temps
        tempsRestant -= Time.deltaTime; 

        if (tempsRestant <= 0)
        {
            tempsRestant = 0;
            //tempsAcabat = true;
            
            ReiniciarNivell(false);
        }
        ActualitzarHUDTemps();
    }

    void ActualitzarHUDTemps()
    {
        int minuts = Mathf.FloorToInt(tempsRestant / 60f);
        int segons = Mathf.FloorToInt(tempsRestant % 60f);
        textTemporitzador.text = string.Format("{0:00}:{1:00}", minuts, segons);
    }

    void ReiniciarNivell(bool Arribat_A_Temps)
    {
        GameManager gm = Object.FindFirstObjectByType<GameManager>();
        if (gm != null)
        {
            gm.ArribatAlFinal(Arribat_A_Temps);
        }
        else
        {
            DadesNivells.victoria = Arribat_A_Temps;
            SceneManager.LoadScene("MenuFinal");
        }
            
    }
    public bool TempsAcabatSenseArribar()
    {
        return tempsAcabat;
    }
}
