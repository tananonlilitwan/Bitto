using UnityEngine;
using System.Collections.Generic;


/*[System.Serializable]
public class Company
{
    [SerializeField] public string companyName; // ชื่อบริษัท
    [SerializeField] public int currentPrice; // ราคาหุ้นปัจจุบัน
    public List<int> priceHistory = new List<int>(); // ประวัติราคาหุ้นในแต่ละรอบ

    public string currentEventText; // ข้อความอีเวนต์ที่เกิดขึ้น (ดีหรือไม่ดี)
    public bool isGoodEvent; // true = เหตุการณ์ดี, false = เหตุการณ์ร้าย
    public int priceChangeThisRound; // การเปลี่ยนแปลงราคาหุ้นในรอบนี้

    // ใช้สำหรับกำหนดอีเวนต์ให้บริษัทในรอบนั้น
    public void ApplyEvent(string text, int changeAmount, bool goodEvent)
    {
        currentEventText = text;
        isGoodEvent = goodEvent;
        priceChangeThisRound = changeAmount;
        currentPrice += changeAmount; // อัปเดตราคาหุ้น
        priceHistory.Add(currentPrice); // บันทึกประวัติราคา
    }
}*/

[System.Serializable]
public class Company
{
    [SerializeField] public string companyName; // ชื่อบริษัท
    [SerializeField] public int currentPrice; // ราคาหุ้นปัจจุบัน
    [SerializeField] public List<int> priceHistory = new List<int>(); // ประวัติราคาหุ้นในแต่ละรอบ

    public string goodEventText; // ข้อความสำหรับเหตุการณ์ดี
    public string badEventText;  // ข้อความสำหรับเหตุการณ์ร้าย
    public string currentEventText; // ข้อความของเหตุการณ์ที่เกิดขึ้นในรอบนี้
    public bool isGoodEvent; // true = เหตุการณ์ดี, false = เหตุการณ์ร้าย
    public int priceChangeThisRound; // การเปลี่ยนแปลงราคาหุ้นในรอบนี้

    public void ApplyEvent(string goodText, string badText, int changeAmount, bool goodEvent)
    {
        isGoodEvent = goodEvent;
        priceChangeThisRound = changeAmount;
        currentPrice += changeAmount;
        priceHistory.Add(currentPrice);

        goodEventText = goodText;
        badEventText = badText;

        // กำหนด currentEventText ตามประเภทของเหตุการณ์
        currentEventText = isGoodEvent ? goodText : badText;
    }
}


