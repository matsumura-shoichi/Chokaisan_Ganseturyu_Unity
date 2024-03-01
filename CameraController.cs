using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float currentHeight = 6000;
 
    void Update()
    {
        // Y����]
        float rotationInput = Input.GetAxis("Horizontal") * 50 * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationInput);

        // �����ړ��i�O�i�E��ށj
        
        float verticalInput = Input.GetAxis("Vertical") * 2000 * Time.deltaTime;
        transform.Translate(Vector3.forward * verticalInput, Space.Self);
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // Y���̐���i�I�v�V�����j
        float currentYRotation = transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(45f, currentYRotation, 0f);

        // �v���X�}�C�i�X�L�[�̓��͂��擾���ăJ�����̕W����ύX
        if (Input.GetKey(KeyCode.RightShift))
        {
            currentHeight = currentHeight + 1000f * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            currentHeight = currentHeight - 1000f * Time.deltaTime;
        }

    }
}
