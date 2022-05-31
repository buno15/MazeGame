using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour {
    public static SEManager seManager;
    public AudioClip foot1;      //足音
    public AudioClip foot2;      //足音
    public AudioClip foot3;      //足音
    public AudioClip foot4;      //足音

    public static AudioSource seSource;
    float prev = 1.0f;
    private void Awake() {
        //BGM再生
        if (seManager == null) {
            seManager = this;  //static変数に自分を保存する
            //シーンが変わってもゲームオブジェクトを破棄しない
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);//ゲームオブジェクトを破棄
        }
    }

    void Start() {
        seSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

    }

    //SE再生
    public void footPlay() {
        float rand = Random.Range(1, 5);
        while (rand == prev) {
            rand = Random.Range(1, 5);
            Debug.Log(prev);
        }
        prev = rand;
        if (rand == 1.0f)
            seSource.PlayOneShot(foot1);      //ボタン押し
        else if (rand == 2.0f)
            seSource.PlayOneShot(foot2);      //ボタン押し
        else if (rand == 3.0f)
            seSource.PlayOneShot(foot3);      //ボタン押し  
        else if (rand == 4.0f)
            seSource.PlayOneShot(foot4);      //ボタン押し
    }

    public void footStop() {
        seSource.Stop();
    }
}
