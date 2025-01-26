using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public static bool RELOADED = false;
    public static bool SETPREFS = false;
    public static bool DEAD = false;
    [SerializeField] GameObject Main;
    [SerializeField] GameObject Retry;
    [SerializeField] GameObject Score;
    [SerializeField] GameObject Prefs;
    [SerializeField] GameObject Pointer_1;
    [SerializeField] GameObject Player_1;
    [SerializeField] GameObject Pointer_2;
    [SerializeField] GameObject Player_2;

    static bool PlayerPref = true;

    void Start() {
        if (RELOADED) {
            Prefs.SetActive(false);
            Main.SetActive(false);
            Retry.SetActive(false);
            Score.SetActive(true);
            if (PlayerPref) {
                Pointer_1.SetActive(false);
                Player_1.SetActive(true);
            } else {
                Pointer_2.SetActive(false);
                Player_2.SetActive(true);
            }
        }
        if (SETPREFS) {
            Main.SetActive(true);
            Prefs.SetActive(false);
            Retry.SetActive(false);
            Score.SetActive(false);
            if (PlayerPref)
                Pointer_1.SetActive(true);
            else
                Pointer_2.SetActive(true);
        }
    }

    public void SetOption(bool Option) {
        PlayerPref = Option;
        if (PlayerPref)
            Pointer_1.SetActive(true);
        else
            Pointer_2.SetActive(true);
        Cursor.visible = false;
        Main.SetActive(true);
        Prefs.SetActive(false);
    }

    public void OnStart(){
        RELOADED = true;
        SceneManager.LoadScene(0);
    }

    public void OnRetry() {
        RELOADED = true;
        DEAD = false;
        SceneManager.LoadScene(0);
    }

    public void Update() {
        if (DEAD) {
            Main.SetActive(false);
            Retry.SetActive(true);
            Score.SetActive(true);
            if (PlayerPref) {
                Pointer_1.SetActive(true);
                Player_1.SetActive(false);
            } else {
                Pointer_2.SetActive(true);
                Player_2.SetActive(false);
            }
        }
    }
}
