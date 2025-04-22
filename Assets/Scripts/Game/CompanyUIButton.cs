using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompanyUIButton : MonoBehaviour
{
    public TMP_Text companyNameText;     // Text แสดงชื่อบริษัท
    public TMP_InputField amountInput;   // InputField ให้ผู้เล่นใส่จำนวนเงิน
    public Button buyButton;         // ปุ่มซื้อ
    public Button sellButton;        // ปุ่มขาย (ถ้ามี)
    
    private string companyName;

    public void SetupUI(string name)
    {
        companyName = name; // กำหนดชื่อบริษัทที่เลือก
        companyNameText.text = name; // แสดงชื่อบริษัทใน UI

        buyButton.onClick.AddListener(OnBuyClicked); // เมื่อกดปุ่มซื้อ
        sellButton.onClick.AddListener(OnSellClicked); // เมื่อกดปุ่มขาย
    }

    public void OnBuyClicked()
    {
        int amount;
        if (int.TryParse(amountInput.text, out amount))
        {
            bool success = GameManager.Instance.BuyStock(companyName, amount); // ตรวจสอบผลลัพธ์จากการซื้อหุ้น
            if (success)
            {
                Debug.Log($"ซื้อหุ้น {companyName} จำนวน {amount} หุ้น สำเร็จ");
            }
            else
            {
                Debug.Log("ไม่สามารถซื้อหุ้นได้เนื่องจากเงินไม่พอหรือไม่พบบริษัท");
            }
        }
        else
        {
            Debug.Log("กรุณากรอกจำนวนเงินที่ถูกต้อง");
        }
    }


    void OnSellClicked()
    {
        // ระบบขายหุ้น: เพิ่มในภายหลัง
        Debug.Log("ยังไม่ทำระบบขาย");
    }
}