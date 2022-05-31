using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
    public float speed = 0;
    public float gravity = -9.8f;
    private float axisH;
    private float axisV;

    public CharacterController controller;
    public Vector3 velocity;
    public Transform groundCheck;
    public Transform frontCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask goalMask;
    bool isGrounded;
    public static string gameState;

    void Start() {
        PlayerController.gameState = "playing";
        Invoke("controllOn", 2.0f);
    }

    void controllOn() {
        GameManager.CameraOn();
    }

    private void Update() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        if (Physics.CheckSphere(frontCheck.position, 0.1f, goalMask) && gameState != "gamegoal") {
            Debug.Log("goal");
            GameGoal();
        }

        if (!CameraController.cameraLock) {
            axisH = Input.GetAxisRaw("Horizontal");
            axisV = Input.GetAxisRaw("Vertical");


            if (axisH != 0 || axisV != 0) {
                if (!SEManager.seSource.isPlaying)
                    SEManager.seManager.footPlay();
            } else if (axisH == 0 && axisV == 0) {
            }

            Vector3 move = transform.right * axisH + transform.forward * axisV;
            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
    void GameGoal() {
        gameState = "gamegoal";
        SoundManager.soundManager.StopBgm();
        //SE再生（ゲームオーバー）
        SoundManager.soundManager.SEPlay(SEType.GameClear);
    }
}