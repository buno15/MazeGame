using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject mainImage;        // 画像を持つ GameObject
    public GameObject panel;
    public Sprite gameStartSpr;          // GAME OVER 画像
    public Sprite gameClearSpr;         // GAME CLEAR 画像
    public GameObject nextButton;       // ネクストボタン
    Image titleImage;                   // 画像を表示している Image コンポーネント

    void Start() {
        // 画像を非表示にする
        Invoke("InactiveImage", 2.0f);
        mainImage.SetActive(true);
        mainImage.GetComponent<Image>().sprite = gameStartSpr;
        panel.SetActive(false);
        Debug.Log("sas");
    }

    void Update() {
        if (PlayerController.gameState == "gamegoal") {
            CameraOff();
            mainImage.SetActive(true);
            mainImage.GetComponent<Image>().sprite = gameClearSpr;//「GAMR CLEAR」を設定する
            panel.SetActive(true);
        } else if (PlayerController.gameState == "playing") {

        }
    }
    public static void CameraOff() {
        Cursor.lockState = CursorLockMode.None;
        CameraController.cameraLock = true;
    }

    public static void CameraOn() {
        Cursor.lockState = CursorLockMode.Locked;
        CameraController.cameraLock = false;
    }

    // 画像を非表示にする
    void InactiveImage() {
        mainImage.SetActive(false);
    }

    public void GoToStage1() {
        SoundManager.soundManager.SEPlay(SEType.Button);
        SceneManager.LoadScene("Stage1");
    }

    public void GoToStage2() {
        SoundManager.soundManager.SEPlay(SEType.Button);
        SceneManager.LoadScene("Stage2");
    }


    public void GoToStage3() {
        SoundManager.soundManager.SEPlay(SEType.Button);
        SceneManager.LoadScene("Stage3");
    }


    //タイトルに戻る
    public void GoToTitle() {
        SoundManager.soundManager.StopBgm();
        SoundManager.soundManager.SEPlay(SEType.Button);
        SceneManager.LoadScene("Title");
    }
}
