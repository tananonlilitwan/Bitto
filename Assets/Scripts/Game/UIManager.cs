using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Text;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject mainUI; // พาเนลหลักที่แสดงเงิน
    //public GameObject[] companyPanels; // ลาก Panel แต่ละอันจาก Inspector มาใส่ใน Array

    public TextMeshProUGUI playerMoneyText;
    
    [System.Serializable]
    public class CompanyPanelEntry
    {
        public string companyName;
        public GameObject panel;
    }
    
    public CompanyPanelEntry[] companyPanelEntries; // ตั้งค่าผ่าน Inspector
    private Dictionary<string, GameObject> companyPanels = new Dictionary<string, GameObject>();

    
    public GameObject myPortPanel; // พาเนลแสดง My Port
    public TMP_Text myPortText; // Text UI ตัวเดียวสำหรับแสดงทั้งหมด
    
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI currentPlayerText;
    public TextMeshProUGUI totalPlayersText;
    
    public TextMeshProUGUI dayText;
    
    private void Awake()
    {
        Instance = this;
        
        // สร้าง Dictionary จาก Array ที่กำหนดใน Inspector
        foreach (var entry in companyPanelEntries)
        {
            if (!companyPanels.ContainsKey(entry.companyName))
                companyPanels.Add(entry.companyName, entry.panel);
        }
    }

    public void ShowMainUI(bool show)
    {
        mainUI.SetActive(show);
    }

    public void ShowCompanyPanel(string companyName)
    {
        ShowMainUI(false);

        // ปิดทุก panel
        foreach (var existingPanel in companyPanels.Values)
            existingPanel.SetActive(false);

        // เปิด panel ที่ตรงชื่อ
        if (companyPanels.TryGetValue(companyName, out GameObject selectedPanel)) // เปลี่ยนชื่อเป็น selectedPanel
        {
            selectedPanel.SetActive(true);

            // เรียก Setup ถ้ามี CompanyUIPanel
            var company = GameManager.Instance.companies.Find(c => c.companyName == companyName);
            var uiPanel = selectedPanel.GetComponent<CompanyUIPanel>();
            if (company != null && uiPanel != null)
            {
                uiPanel.Setup(company);
            }
        }
        else
        {
            Debug.LogWarning($"ไม่พบ Panel สำหรับบริษัท: {companyName}");
        }
    }

    
    public void UpdatePlayerMoneyUI()
    {
        var player = GameManager.Instance.players[GameManager.Instance.currentPlayerIndex];
        playerMoneyText.text = $"Your money: {player.money:n0} B";
    }
    
    public void UpdateMyPortUI()
    {
        var player = GameManager.Instance.players[GameManager.Instance.currentPlayerIndex];

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("My Port:");
        
        foreach (var investment in player.investments)
        {
            string companyName = investment.Key;
            int amount = investment.Value;

            sb.AppendLine("----------------------------------");
            sb.AppendLine($"|  {companyName.PadRight(15)}| Number of shares: {amount.ToString().PadRight(4)}|");
        }
        sb.AppendLine("----------------------------------");

        myPortText.text = sb.ToString();

        myPortPanel.SetActive(true);
    }
    
    // ปิด My Port
    public void CloseMyPort()
    {
        myPortPanel.SetActive(false);
    }
    
    public void UpdateTurnInfo(string playerName, int currentPlayerIndex, int totalPlayers, float timeLeft)
    {
        currentPlayerText.text = $"Turn to : {playerName}";
        totalPlayersText.text = $"All players: {totalPlayers} person";
        timerText.text = $"Time remaining: {Mathf.CeilToInt(timeLeft)} second";
    }
    
    public void UpdateDayInfo(int currentDay, int maxDays)
    {
        dayText.text = $"Day: {currentDay} / {maxDays}";
    }
}