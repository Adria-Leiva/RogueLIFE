using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    private AudioSource musica;

    
    
    void Awake()
    {
        //ens assegurem que nom�s hi hagi una inst�ncia de MusicManager per escena
        //i que aquesta inst�ncia no es destrueixi en canviar d'escena
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            //obtenim el component AudioSource i reprodu�m la m�sica si no s'est� reproduint
            musica = GetComponent<AudioSource>();
            if (musica != null && !musica.isPlaying)
            {
                musica.Play();
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void ActivarMusica(bool activada)
    {
        if (musica == null)
            return;

        if (activada)
            musica.Play();
        else
            musica.Pause();
    }

    public bool EstatMusicaActiva()
    {
        if (musica == null)
            return false;
        return musica.isPlaying;
    }

    // Permetre accedir a la instancia desde altres scripts
    public static MusicManager Instance
    {
        get { return instance; }
    }

}
