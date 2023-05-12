using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
   public void CambiarNivel (string nombreNivel)
   {
    SceneManager.LoadScene(nombreNivel);
   }

   public void CambiarNivel (int numeroNivel)
   {
    SceneManager.LoadScene(numeroNivel);
   }


}
