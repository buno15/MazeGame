using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {
    public string firstSceneName;

    void Start() {
        SoundManager.soundManager.PlayBgm(BGMType.Title);
    }

    void Update() {

    }

    public void StartButtonClicked() {
        SceneManager.LoadScene(firstSceneName);
        SoundManager.soundManager.SEPlay(SEType.Button);
    }
}
