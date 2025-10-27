using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            string colectiblesActuals = GameManager.instance.collectibleNumberText.text;
            int nColectibles = int.Parse(colectiblesActuals);
            if (nColectibles >= 6)
            {
                SceneManager.LoadScene("MenusFinal");
            }

        }
    }
}
