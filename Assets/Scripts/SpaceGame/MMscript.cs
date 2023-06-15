using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MMscript : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadScene("JessedK");
    }
    public void Quit()
    {
        //Deze gaat uiteindelijk naar de game toe
    }

}
