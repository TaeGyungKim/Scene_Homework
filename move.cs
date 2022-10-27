using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody Rigidbody;
    private scene_transition scene_Transition;

    public float moveSpeed = 5f; // ������ ���� �ӵ�
    private int count = 0; //���� �浹 ī��Ʈ

    //�ؽ��� icon
    public Texture2D icon = null;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        scene_Transition = GetComponent<scene_transition>();
    }

    // Update is called once per frame
    void Update()
    {
        //�̵�Ű �� �о��
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //�̵�Ű�� ������ �ִٸ� moveSpeed�� ����ŭ ���� ����
        //if (xInput != 0 || zInput != 0)
            Rigidbody.AddForce(xInput * moveSpeed , 0, zInput * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.name == "ground")
        //�浹ü�� ground �±׸� ������ ��� ī��Ʈ
        //ī��Ʈ ���� 7 �ʰ����tarnsition() �޼ҵ�, �� �̵� ����
        if (collision.collider.CompareTag("ground"))
        {
            count++;

            if (count > 7)
                scene_Transition.transition();
        }

        //�浹ü�� �±װ� death��� ��� �� �̵�
        if (collision.collider.CompareTag("death"))
            scene_Transition.transition();

        // �浹ü�� �̸� ���
        Debug.Log(collision.gameObject.name);
    }

    private void OnGUI()
    {
        //������(�̹���)�� ��ũ�� ���� �ϴܿ� ����
        GUI.DrawTexture(new Rect(0, Screen.height - 64, 64, 64), icon);
        //ī��Ʈ ���� ���� Label�� ������ ���� ���
        GUI.Label(new Rect(81, Screen.height - 40, 256, 64), "Jumping : " +count.ToString());
    }
}
