using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text collectibleNumberText;
    public int collectibleNumber = 0;

    public TMP_Text TotalcollectibleNumberText;
    //private int TotalcollectibleNumber = 1;

    public AudioSource audioCollectible;

    public static GameManager instance; //es crea una instància global per accedir des d'altres scripts

    private void Awake()
    {


        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.ActivarMusica(true);
        }
        //gurdem la quantitat total de coleccionables 
        DadesNivells.totalColectibles = transform.childCount;
        TotalcollectibleNumberText.text = DadesNivells.totalColectibles.ToString();
    }



    public void AddCollectible()
    {
        audioCollectible.Play();
        collectibleNumber++;
        DadesNivells.collectibles = collectibleNumber;
        collectibleNumberText.text = collectibleNumber.ToString();
    }
    public void ArribatAlFinal(bool arribat_a_temps)
    {
        DadesNivells.victoria = arribat_a_temps;
        SceneManager.LoadScene("MenusFinal");
    }

    
}
