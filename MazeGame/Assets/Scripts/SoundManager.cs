using System.Collections.Generic;
using UnityEngine;

//BGMタイプ
public enum BGMType {
    None,       //なし
    Title,      //タイトル
    InGame,     //ゲーム中
}
//SEタイプ
public enum SEType {
    GameClear,  //ゲームクリア
    Button,     //ボタン押し
}

public class SoundManager : MonoBehaviour {
    public AudioClip bgmInTitle;    //タイトルBGM
    public AudioClip bgmInGame;     //ゲーム中

    public AudioClip meGameClear;   //ゲームクリア
    public AudioClip seButton;      //ボタン押し

    public static SoundManager soundManager;    //最初のSoundManagerを保存する変数

    public static BGMType plyingBGM = BGMType.None;    //再生中のBGM

    private void Awake() {
        //BGM再生
        if (soundManager == null) {
            soundManager = this;  //static変数に自分を保存する
            //シーンが変わってもゲームオブジェクトを破棄しない
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);//ゲームオブジェクトを破棄
        }
    }

    void Start() {
    }

    void Update() {

    }

    //BGM設定
    public void PlayBgm(BGMType type) {
        if (type != plyingBGM) {
            plyingBGM = type;
            AudioSource audio = GetComponent<AudioSource>();
            if (type == BGMType.Title) {
                audio.clip = bgmInTitle;    //タイトル
            } else if (type == BGMType.InGame) {
                audio.clip = bgmInGame;     //ゲーム中
            }
            audio.Play();
        }
    }
    //BGM停止
    public void StopBgm() {
        GetComponent<AudioSource>().Stop();
        plyingBGM = BGMType.None;
    }

    //SE再生
    public void SEPlay(SEType type) {
        if (type == SEType.GameClear) {
            GetComponent<AudioSource>().PlayOneShot(meGameClear);   //ゲームクリア
        } else if (type == SEType.Button) {
            GetComponent<AudioSource>().PlayOneShot(seButton);      //ボタン押し
        }
    }

}
