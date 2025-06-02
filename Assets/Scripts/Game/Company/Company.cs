using UnityEngine;
using System.Collections.Generic;

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


