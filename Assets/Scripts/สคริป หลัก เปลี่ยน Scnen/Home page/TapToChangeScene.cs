using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToChangeScene : MonoBehaviour
{
    void Update()
    {
        // ตรวจจับการแตะหน้าจอ
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // โหลด Scene ชื่อ "JoinAndHost"
            SceneManager.LoadScene("Create character");
        }

        // สำหรับทดสอบใน PC (คลิกเมาส์ซ้าย)
        if (Application.isEditor && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Create character");
        }
    }
}