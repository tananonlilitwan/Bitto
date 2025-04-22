/*using UnityEngine;

public class RandomEventManager : MonoBehaviour
{
    // สุ่มอีเวนต์ให้บริษัทที่กำหนด
    public void TriggerRandomEvent(Company company)
    {
        bool isGood = Random.value > 0.5f; // 50% ที่จะเป็นเหตุการณ์ดี
        int change = Random.Range(10, 51) * (isGood ? 1 : -1); // เพิ่มหรือลดราคาหุ้น
        string text = isGood ? "บริษัทมีกำไรสูง!" : "บริษัทขาดทุนหนัก!";

        company.ApplyEvent(text, change, isGood); // ใช้เหตุการณ์นั้นกับบริษัท
        Debug.Log($"{company.companyName} Event: {company.currentEventText} เปลี่ยนราคา {change} บาท");
    }
}*/

using UnityEngine;

public class RandomEventManager : MonoBehaviour
{
    public void TriggerRandomEvent(Company company)
    {
        bool isGood = Random.value > 0.5f;
        int change = Random.Range(10, 51) * (isGood ? 1 : -1);

        // ข้อความสำหรับทั้งเหตุการณ์ดีและร้าย
        string goodText = "The company has profited from new projects.!"; // บริษัทได้รับกำไรจากโครงการใหม่
        string badText = "The company is facing a financial crisis.!"; //บริษัทเผชิญกับวิกฤตการเงิน

        company.ApplyEvent(goodText, badText, change, isGood);

        Debug.Log($"{company.companyName} Event: {company.currentEventText} เปลี่ยนราคา {change} บาท");
    }
}
