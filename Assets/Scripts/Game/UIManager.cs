using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Text;

public partial class UIManager : MonoBehaviour
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
    
    public GameObject playerDetailsPanel;
    private bool isPlayerDetailsVisible = false;
    
    public GameObject playerUIIcons;
    
    public GameObject animatedDayPanel; // Panel ที่จะเลื่อนลง-ขึ้น
    public TextMeshProUGUI animatedDayText; // ตัวเลขวันลอยตัว
    private int lastAnimatedDay = -1;
    private Coroutine currentDayAnimCoroutine = null;
    
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
        playerMoneyText.text = $"{player.money:n0} B";
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
        playerUIIcons.SetActive(false);
    }
    
    // ปิด My Port
    public void CloseMyPort()
    {
        myPortPanel.SetActive(false);
        playerUIIcons.SetActive(true);
    }
    
    public void UpdateTurnInfo(string playerName, int currentPlayerIndex, int totalPlayers, float timeLeft, int currentDay, int maxDays)
    {
        currentPlayerText.text = $"Turn to : {playerName}";
        totalPlayersText.text = $"All players: {totalPlayers} person";
        timerText.text = $" {Mathf.CeilToInt(timeLeft)}"; // เวลา 
        //=========================================================
        dayText.text = $"Day: {currentDay} / {maxDays}";
        ShowAnimatedDay(currentDay); // แสดงตัวเลขวันแบบแอนิเมชัน
    }
    
    public void UpdateDayInfo(int currentDay, int maxDays)
    {
        dayText.text = $"Day: {currentDay} / {maxDays}";
    }
    
    public void TogglePlayerDetailsPanel()
    {
        isPlayerDetailsVisible = !isPlayerDetailsVisible;
        playerDetailsPanel.SetActive(isPlayerDetailsVisible);
    }
    
    public void ShowAnimatedDay(int dayNumber)
    {
        //StartCoroutine(AnimateDayNumber(dayNumber));
        if (dayNumber == lastAnimatedDay) return; // ป้องกันการเล่นซ้ำถ้าวันยังไม่เปลี่ยน

        lastAnimatedDay = dayNumber;

        if (currentDayAnimCoroutine != null)
            StopCoroutine(currentDayAnimCoroutine);

        currentDayAnimCoroutine = StartCoroutine(AnimateDayNumber(dayNumber));
    }

    
    
    private IEnumerator AnimateDayNumber(int dayNumber)
    {
        // ปิด player UI icons ก่อนเริ่ม
        playerUIIcons.SetActive(false);
        // อัปเดตตัวเลข
        animatedDayText.text = dayNumber.ToString();

        // เริ่มตำแหน่ง (บนจอ)
        Vector3 startPos = new Vector3(0, Screen.height, 0); // เหนือจอ
        Vector3 midPos = new Vector3(0, 0, 0);               // กลางจอ
        Vector3 endPos = new Vector3(0, Screen.height, 0);   // กลับขึ้นไป

        RectTransform panelRect = animatedDayPanel.GetComponent<RectTransform>();

        animatedDayPanel.SetActive(true);

        float t = 0f;
        float duration = 0.5f;

        // เลื่อนลงกลางจอ
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            panelRect.anchoredPosition = Vector3.Lerp(startPos, midPos, t);
            yield return null;
        }

        // ค้างกลางจอ 1.2 วิ
        yield return new WaitForSeconds(1.2f);

        // รีเซ็ตตัวแปรแล้วเคลื่อนขึ้น
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            panelRect.anchoredPosition = Vector3.Lerp(midPos, endPos, t);
            yield return null;
        }

        animatedDayPanel.SetActive(false);
        playerUIIcons.SetActive(true);
    }

    //=================================================================================================================
    public GameObject dailyReportsPanel;
    public GameObject lastRankPanel;
    public GameObject createdPanel;

    public void ShowEndSequence()
    {
        StartCoroutine(ShowEndSequenceCoroutine());
    }

    private IEnumerator ShowEndSequenceCoroutine()
    {
        // แสดง Daily Reports
        dailyReportsPanel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        dailyReportsPanel.SetActive(false);

        // แสดง Last Rank
        lastRankPanel.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        lastRankPanel.SetActive(false);

        // แสดง Created
        createdPanel.SetActive(true);
    }



}