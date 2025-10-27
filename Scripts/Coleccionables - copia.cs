using UnityEngine;

public class Coleccionables : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public int punts = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Buscar el GameManager en l'escena i afegeix +1 al nombre de coleccionables
            FindAnyObjectByType<GameManager>().AddCollectible();

            

            // Destruir el coleccionable
            Destroy(gameObject);
        }
    }
}

