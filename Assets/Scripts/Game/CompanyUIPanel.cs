using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CompanyUIPanel : MonoBehaviour
{
    // ตัวแสดงชื่อบริษัท
    public TextMeshProUGUI companyNameText;
    // ตัวแสดงราคาหุ้นต่อ 1 หุ้น
    public TextMeshProUGUI pricePerStockText;
    // ช่องให้กรอกจำนวนหุ้นที่จะซื้อหรือขาย
    public TMP_InputField amountInputField;
    // แสดงราคารวมที่ต้องจ่ายหรือได้รับ
    public TextMeshProUGUI totalCostText;
    // แสดงจำนวนเงินของผู้เล่น
    public TextMeshProUGUI playerMoneyText;
    // ปุ่มซื้อหุ้น
    public Button buyButton;
    // ปุ่มขายหุ้น
    public Button sellButton;
    // ปุ่มปิดหน้าต่างบริษัท
    public Button closeButton;

    // เก็บข้อมูลของบริษัทปัจจุบัน
    private Company company;

    // ฟังก์ชันสำหรับตั้งค่า UI ของบริษัทเมื่อมีการเปิด Panel
    public void Setup(Company _company)
    {
        company = _company;
        companyNameText.text = company.companyName;
        pricePerStockText.text = $"Price/share : {company.currentPrice} B";
        UpdatePlayerMoneyUI(); // อัปเดตเงินของผู้เล่น
        totalCostText.text = "together: 0 B";

        amountInputField.text = "";
        amountInputField.onValueChanged.AddListener(UpdateTotalCost); // คำนวณราคารวมเมื่อกรอกจำนวนหุ้น
        buyButton.onClick.AddListener(Buy);     // เมื่อคลิกปุ่มซื้อ
        sellButton.onClick.AddListener(Sell);   // เมื่อคลิกปุ่มขาย
        closeButton.onClick.AddListener(ClosePanel); // เมื่อคลิกปิดหน้าต่าง
    }

    // ฟังก์ชันแสดงจำนวนเงินของผู้เล่นใน UI
    void UpdatePlayerMoneyUI()
    {
        playerMoneyText.text = $"Your money: {GameManager.Instance.players[GameManager.Instance.currentPlayerIndex].money:n0} B";
    }

    // ฟังก์ชันคำนวณราคารวมตามจำนวนหุ้นที่ผู้เล่นกรอก
    void UpdateTotalCost(string value)
    {
        if (int.TryParse(value, out int amount))
        {
            int total = amount * company.currentPrice;
            totalCostText.text = $"together: {total:n0} B";
        }
        else
        {
            totalCostText.text = "together : 0 B";
        }
    }

    // ฟังก์ชันสำหรับซื้อหุ้น
    void Buy()
    {
        if (int.TryParse(amountInputField.text, out int amount))
        {
            bool success = GameManager.Instance.BuyStock(company.companyName, amount);
            if (success)
            {
                UpdatePlayerMoneyUI(); // อัปเดตจำนวนเงินหลังซื้อ
                UpdateTotalCost(amountInputField.text); // อัปเดตราคารวมใหม่
            }
        }
    }

    // ฟังก์ชันสำหรับขายหุ้น
    void Sell()
    {
        if (int.TryParse(amountInputField.text, out int amount))
        {
            bool success = GameManager.Instance.SellStock(company.companyName, amount);
            if (success)
            {
                UpdatePlayerMoneyUI(); // อัปเดตจำนวนเงินหลังขาย
                UpdateTotalCost(amountInputField.text); // อัปเดตราคารวมใหม่
            }
        }
    }

    // ฟังก์ชันปิดหน้าต่าง UI บริษัท แล้วแสดง UI หลักกลับมา
    void ClosePanel()
    {
        this.gameObject.SetActive(false); // ปิด Panel นี้
        UIManager.Instance.ShowMainUI(true); // เปิด UI หลักกลับมา
    }
}
