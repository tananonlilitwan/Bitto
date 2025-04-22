using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<Company> companies = new List<Company>(); // รายชื่อบริษัททั้งหมด
    public List<PlayerData> players = new List<PlayerData>(); // รายชื่อผู้เล่นทั้งหมด

    public int currentPlayerIndex = 0; // ผู้เล่นที่กำลังเล่นอยู่ในรอบนี้
    public float playerTurnTime = 120f; // เวลาต่อคน (2 นาที)
    private float currentTime; // ตัวจับเวลาของรอบ
    
    public int currentRound = 1; // รอบปัจจุบัน
    public int maxRounds = 10;   // จำนวนรอบสูงสุด
    
    public const int MAX_PLAYERS = 6;
    public List<string> joinedPlayerNames = new List<string>(); // ผู้เล่นที่เข้ามาจริง

    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitCompanies(); // สร้างบริษัท
        InitPlayers(); // สร้างผู้เล่น
        StartTurn(); // เริ่มรอบแรก

        // เพื่ออัปเดต UI ทันทีเมื่อเกมเริ่ม
        UIManager.Instance.UpdatePlayerMoneyUI();
    }

    void InitCompanies()
    {
        companies = new List<Company>
        {
            new Company { companyName = "Bank", currentPrice = 100 },
            new Company { companyName = "Business", currentPrice = 150 },
            new Company { companyName = "Crypto", currentPrice = 50 },
            new Company { companyName = "Forex", currentPrice = 80 },
            new Company { companyName = "Gold", currentPrice = 200 },
            new Company { companyName = "RealEstate", currentPrice = 300 },
            new Company { companyName = "Stocks", currentPrice = 120 },
        };
    }

    void InitPlayers()
    {
        for (int i = 0; i < 6; i++)
        {
            players.Add(new PlayerData { playerName = $"Players {i + 1}" });
        }
        
        /*players.Clear();

        int playerCount = Mathf.Min(joinedPlayerNames.Count, MAX_PLAYERS); // จำกัดไม่เกิน 6 คน

        for (int i = 0; i < playerCount; i++)
        {
            players.Add(new PlayerData { playerName = joinedPlayerNames[i] });
        }

        Debug.Log($"All players: {players.Count} person");*/
        
    }

    void StartTurn()
    {
        currentTime = playerTurnTime; // ตั้งเวลาใหม่
        Debug.Log($"ถึงตาของ: {players[currentPlayerIndex].playerName}"); // แสดงผลว่าตาใคร
        
        // สุ่ม Event ให้ทุกบริษัทในแต่ละรอบ
        foreach (var company in companies)
        {
            FindObjectOfType<RandomEventManager>().TriggerRandomEvent(company);
        }
        
        // ✅ อัปเดตวันที่ตรงนี้
        UIManager.Instance.UpdateDayInfo(currentRound, maxRounds);
    }

    private void Update()
    {
        /*currentTime -= Time.deltaTime; // นับเวลาถอยหลัง
        if (currentTime <= 0f)
        {
            NextPlayer(); // ถ้าเวลาหมด ให้เปลี่ยนไปยังผู้เล่นถัดไป
        }*/
        
        currentTime -= Time.deltaTime;

        // อัปเดต UI ทุกเฟรม
        UIManager.Instance.UpdateTurnInfo(
            players[currentPlayerIndex].playerName,
            currentPlayerIndex + 1,
            players.Count,
            currentTime
        );

        if (currentTime <= 0f)
        {
            NextPlayer();
        }
    }

    public void NextPlayer()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count; // เปลี่ยนผู้เล่นแบบวน
        
        if (currentPlayerIndex == 0)
            currentRound++;

        if (currentRound > maxRounds)
        {
            EndGame();
        }
        else
        {
            StartTurn(); // เริ่มตารอบใหม่
        }
    }
    
    void EndGame()
    {
        PlayerData winner = players[0];
        foreach (var player in players)
        {
            if (player.money > winner.money)
                winner = player;
        }

        Debug.Log($"เกมจบแล้ว! ผู้ชนะคือ {winner.playerName} ด้วยเงิน {winner.money} บาท");
    }
    
    // ผู้เล่นทำการซื้อหุ้น
    public bool BuyStock(string companyName, int amount)
    {
        var player = players[currentPlayerIndex]; // เข้าถึงผู้เล่นที่กำลังเล่นอยู่
        var company = companies.Find(c => c.companyName == companyName); // หาบริษัทที่ตรงกับชื่อที่ได้รับ

        if (company != null && player.money >= amount * company.currentPrice) // ตรวจสอบว่าผู้เล่นมีเงินพอไหม
        {
            player.BuyStock(companyName, amount); // เรียกใช้งานฟังก์ชัน BuyStock จาก PlayerData

            UIManager.Instance.UpdatePlayerMoneyUI(); // หลังจากซื้อหุ้นสำเร็จ
        
            Debug.Log($"{player.playerName} ซื้อหุ้น {companyName} จำนวน {amount} หุ้น");
            return true;  // คืนค่าผลลัพธ์ว่าเป็นการซื้อหุ้นที่สำเร็จ
        }
        else
        {
            Debug.Log("เงินไม่พอหรือไม่พบบริษัทนี้");
            return false; // คืนค่าผลลัพธ์ว่าไม่สามารถซื้อหุ้นได้
        }
    }
    

    // ฟังก์ชันขายหุ้น
    public bool SellStock(string companyName, int amount)
    {
        var player = players[currentPlayerIndex];
        var company = companies.Find(c => c.companyName == companyName);

        if (company != null && player.investments.ContainsKey(companyName) && player.investments[companyName] >= amount)
        {
            player.SellStock(companyName, amount); // เรียกใช้งานฟังก์ชัน SellStock จาก PlayerData

            UIManager.Instance.UpdatePlayerMoneyUI(); // อัปเดต UI หลังขาย
        
            Debug.Log($"{player.playerName} ขายหุ้น {companyName} จำนวน {amount} หุ้น");

            return true;
        }
        else
        {
            Debug.Log("คุณไม่มีหุ้นเพียงพอหรือไม่พบบริษัทนี้");
            return false;
        }
    }
    
    public void AddPlayer(string playerName)
    {
        if (joinedPlayerNames.Count < MAX_PLAYERS)
        {
            joinedPlayerNames.Add(playerName);
            Debug.Log($"ผู้เล่นเข้าร่วม: {playerName}");
        }
        else
        {
            Debug.Log("เต็มแล้ว! มีผู้เล่นครบ 6 คน");
        }
    }

    
    

}
