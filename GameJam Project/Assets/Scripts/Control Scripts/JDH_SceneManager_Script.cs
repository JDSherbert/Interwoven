using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JDH_SceneManager_Script : MonoBehaviour
{
    [System.Serializable]
    public class SceneData
    {
        public string Level0 = "0_MainMenu";
        public string Level1 = "9th Ring - Treachery";
        public string Level2 = "8th Ring - Fraud";
        public string Level3 = "7th Ring - Violence";
        public string Level4 = "6th Ring - Heresy";
        public string Level5 = "5th Ring - Anger";
        public string Level6 = "4th Ring - Greed";
        public string Level7 = "3rd Ring - Gluttony";
        public string Level8 = "2nd Ring - Lust";
        public string Level9 = "1st Ring - Limbo";

        public string URL = "";
    }

    public SceneData sceneData = new SceneData();

    public void PlayGame()
    {
        Debug.Log("Loading...");
        SceneManager.LoadScene(sceneData.Level1);
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
