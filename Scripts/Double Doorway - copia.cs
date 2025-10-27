using UnityEngine;
using UnityEngine.SceneManagement;

public class DoubleDoorway : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            string colectiblesActuals = GameManager.instance.collectibleNumberText.text;
            int  nColectibles=int.Parse(colectiblesActuals);
            if (nColectibles == 1)
            {
                SceneManager.LoadScene("Nivell_2");
            }

        }
    }
}
