using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody Rigidbody;
    private scene_transition scene_Transition;

    public float moveSpeed = 5f; // 움직일 때의 속도
    private int count = 0; //지상 충돌 카운트

    //텍스쳐 icon
    public Texture2D icon = null;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        scene_Transition = GetComponent<scene_transition>();
    }

    // Update is called once per frame
    void Update()
    {
        //이동키 값 읽어옴
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //이동키를 누르고 있다면 moveSpeed의 값만큼 힘을 가함
        //if (xInput != 0 || zInput != 0)
            Rigidbody.AddForce(xInput * moveSpeed , 0, zInput * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.name == "ground")
        //충돌체가 ground 태그를 가졌을 경우 카운트
        //카운트 값이 7 초과라면tarnsition() 메소드, 씬 이동 실행
        if (collision.collider.CompareTag("ground"))
        {
            count++;

            if (count > 7)
                scene_Transition.transition();
        }

        //충돌체의 태그가 death라면 즉시 씬 이동
        if (collision.collider.CompareTag("death"))
            scene_Transition.transition();

        // 충돌체의 이름 출력
        Debug.Log(collision.gameObject.name);
    }

    private void OnGUI()
    {
        //아이콘(이미지)를 스크린 좌측 하단에 삽입
        GUI.DrawTexture(new Rect(0, Screen.height - 64, 64, 64), icon);
        //카운트 값을 가진 Label을 아이콘 옆에 출력
        GUI.Label(new Rect(81, Screen.height - 40, 256, 64), "Jumping : " +count.ToString());
    }
}
