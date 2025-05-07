using System.Collections;
using UnityEngine;
using TMPro;

public class Created : MonoBehaviour
{
    public GameObject[] imageObjects; // รูปภาพ 3 รูป
    public GameObject[] textObjects; // ข้อความ 9 อัน (TMPro)

    public float imageFadeDuration = 0.5f;
    public float imageDisplayTime = 0.5f;
    public float textMoveDuration = 0.5f;
    public float textDelay = 0.3f;

    private void OnEnable()
    {
        StartCoroutine(PlaySequence());
    }

    private IEnumerator PlaySequence()
    {
        // ซ่อนข้อความทั้งหมดก่อนเริ่ม
        foreach (var text in textObjects)
            text.SetActive(false);

        // เฟดอินและเฟดเอาท์รูปภาพทีละอัน
        foreach (var image in imageObjects)
        {
            CanvasGroup cg = image.GetComponent<CanvasGroup>();
            if (cg == null) cg = image.AddComponent<CanvasGroup>();

            image.SetActive(true);
            yield return StartCoroutine(FadeCanvasGroup(cg, 0f, 1f, imageFadeDuration)); // เฟดอิน
            yield return new WaitForSeconds(imageDisplayTime);
            yield return StartCoroutine(FadeCanvasGroup(cg, 1f, 0f, imageFadeDuration)); // เฟดเอาท์

            image.SetActive(false);
        }

        // แสดงข้อความทีละตัวพร้อมแอนิเมชันเลื่อนขึ้น
        foreach (var text in textObjects)
        {
            text.SetActive(true);
            RectTransform rect = text.GetComponent<RectTransform>();
            Vector3 startPos = rect.anchoredPosition - new Vector2(0, 50);
            Vector3 endPos = rect.anchoredPosition;

            rect.anchoredPosition = startPos;
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime / textMoveDuration;
                rect.anchoredPosition = Vector3.Lerp(startPos, endPos, t);
                yield return null;
            }

            yield return new WaitForSeconds(textDelay); // รอหน่อยก่อนขึ้นตัวต่อไป
        }
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float duration)
    {
        float t = 0f;
        cg.alpha = start;
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            cg.alpha = Mathf.Lerp(start, end, t);
            yield return null;
        }
        cg.alpha = end;
    }
}
