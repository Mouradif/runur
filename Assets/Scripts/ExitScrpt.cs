using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScrpt : MonoBehaviour
{
    public void QuitGame(int exitCode)
    {
        Application.Quit(exitCode);
    }
}
