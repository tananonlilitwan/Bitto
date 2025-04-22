using UnityEngine;

public class CompanyIconButton : MonoBehaviour
{
    public string companyName; // ตั้งชือให้ตรงกับที่ใช้ใน UIManager
    public void OnClick()
    {
        Company company = GameManager.Instance.companies.Find(c => c.companyName == companyName);
        if (company != null)
        {
            UIManager.Instance.ShowCompanyPanel(companyName);
        }
    }
}
