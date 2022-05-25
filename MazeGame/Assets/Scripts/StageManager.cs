using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {
    void Start() {
        SoundManager.soundManager.PlayBgm(BGMType.InGame);
    }

    void Update() {

    }

    //シーン移動
    public static void ChangeScene(string scnename) {
        SceneManager.LoadScene(scnename);   //シーン移動
    }
}
