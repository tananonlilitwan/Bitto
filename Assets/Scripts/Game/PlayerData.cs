using UnityEngine;
 using System.Collections.Generic;
 
 public class PlayerData
 {
    public string playerName; // ชื่อผู้เล่น
    public int money = 150000000; // เงินเริ่มต้น 10 ล้านบาท

    // รายการการลงทุนของผู้เล่น: ชื่อบริษัท -> จำนวนเงินที่ลงทุน
    public Dictionary<string, int> investments = new Dictionary<string, int>();
    
    public void BuyStock(string companyName, int amount)
    {
        var player = GameManager.Instance.players[GameManager.Instance.currentPlayerIndex];
        var company = GameManager.Instance.companies.Find(c => c.companyName == companyName);

        int price = company.currentPrice;
        int totalCost = price * amount; // คำนวณราคาหุ้นทั้งหมด

        if (player.money >= totalCost) // เช็คว่าเงินพอซื้อหรือไม่
        {
            player.money -= totalCost; // หักเงินจากผู้เล่น

            if (player.investments.ContainsKey(companyName)) 
            {
                player.investments[companyName] += amount; // เพิ่มจำนวนหุ้นใน Dictionary
            }
            else
            {
                player.investments[companyName] = amount; // ถ้ายังไม่มีบริษัทใน Dictionary ให้เพิ่มเข้าไป
            }

            Debug.Log($"{player.playerName} ซื้อหุ้น {companyName} จำนวน {amount} หุ้น มูลค่า {totalCost} บาท");
        }
        else
        {
            Debug.Log("เงินไม่พอในการซื้อหุ้น");
        }
    }
    

    
    public void SellStock(string companyName, int amount)
    {
        var player = GameManager.Instance.players[GameManager.Instance.currentPlayerIndex];
        var company = GameManager.Instance.companies.Find(c => c.companyName == companyName);

        if (player.investments.ContainsKey(companyName) && player.investments[companyName] >= amount)
        {
            int price = company.currentPrice;
            int sellValue = price * amount; // คำนวณมูลค่าหุ้นที่ขาย

            player.money += sellValue; // เพิ่มเงินให้กับผู้เล่น
            player.investments[companyName] -= amount; // ลดจำนวนหุ้นใน Dictionary

            if (player.investments[companyName] == 0) 
            {
                player.investments.Remove(companyName); // ถ้าไม่มีหุ้นเหลือก็ลบออกจาก Dictionary
            }

            Debug.Log($"{player.playerName} ขายหุ้น {companyName} จำนวน {amount} หุ้น มูลค่า {sellValue} บาท");
        }
        else
        {
            Debug.Log("ไม่มียอดหุ้นพอที่จะขาย");
        }
    }
}
