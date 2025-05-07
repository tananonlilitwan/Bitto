using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagers : MonoBehaviour
{
    public CharacterCustomization characterCustomization;

    // ตัวแปรเก็บสถานะปัจจุบันของแต่ละชิ้นส่วน
    private int currentHairIndex = 0;
    private int currentEarLeftIndex = 0;
    private int currentEarRightIndex = 0;
    private int currentEyeWhiteLeftIndex = 0;
    private int currentEyeWhiteRightIndex = 0;
    private int currentEyeBlackLeftIndex = 0;
    private int currentEyeBlackRightIndex = 0;
    private int currentArmLeftIndex = 0;
    private int currentArmRightIndex = 0;
    private int currentLegLeftIndex = 0;
    private int currentLegRightIndex = 0;
    private int currentTailIndex = 0;
    private int currentHeadIndex = 0;
    private int currentMouthIndex = 0;
    private int currentBodyIndex = 0;

    // จำนวนตัวเลือกของแต่ละชิ้นส่วน (ดึงจาก CharacterCustomization)
    private int earCount;
    private int eyeWhiteCount;
    private int eyeBlackCount;
    private int armCount;
    private int legCount;
    private int tailCount;
    private int headCount;
    private int mouthCount;
    private int bodyCount;

    
    void Start()
    {
        // ดึงจำนวนของแต่ละออปชั่นจาก CharacterCustomization
        earCount = characterCustomization.earLeftOptions.Length; // ใช้ earLeftOptions เพราะซ้าย-ขวามีจำนวนเท่ากัน
        eyeWhiteCount = characterCustomization.eyeWhiteLeftOptions.Length;
        eyeBlackCount = characterCustomization.eyeBlackLeftOptions.Length;
        armCount = characterCustomization.armLeftOptions.Length;
        legCount = characterCustomization.legLeftOptions.Length;
        tailCount = characterCustomization.tailOptions.Length;
        headCount = characterCustomization.headOptions.Length;
        mouthCount = characterCustomization.mouthOptions.Length;
        bodyCount = characterCustomization.bodyOptions.Length;
    }
    
    
    // ฟังก์ชันสำหรับเปลี่ยนทรงผม
    public void ChangeHair()
    {
        //currentHairIndex = (currentHairIndex + 1) % hairCount;
        //characterCustomization.SetHair(currentHairIndex);
    }

    // ฟังก์ชันสำหรับเปลี่ยนหู
    public void ChangeEar()
    {
        currentEarLeftIndex = (currentEarLeftIndex + 1) % earCount;
        currentEarRightIndex = (currentEarRightIndex + 1) % earCount;
        characterCustomization.SetEarLeft(currentEarLeftIndex);
        characterCustomization.SetEarRight(currentEarRightIndex);
    }

    // ฟังก์ชันสำหรับเปลี่ยนตาขาว
    public void ChangeEyeWhite()
    {
        currentEyeWhiteLeftIndex = (currentEyeWhiteLeftIndex + 1) % eyeWhiteCount;
        currentEyeWhiteRightIndex = (currentEyeWhiteRightIndex + 1) % eyeWhiteCount;
        characterCustomization.SetEyeWhiteLeft(currentEyeWhiteLeftIndex);
        characterCustomization.SetEyeWhiteRight(currentEyeWhiteRightIndex);
    }

    // ฟังก์ชันสำหรับเปลี่ยนตาดำ
    public void ChangeEyeBlack()
    {
        currentEyeBlackLeftIndex = (currentEyeBlackLeftIndex + 1) % eyeBlackCount;
        currentEyeBlackRightIndex = (currentEyeBlackRightIndex + 1) % eyeBlackCount;
        characterCustomization.SetEyeBlackLeft(currentEyeBlackLeftIndex);
        characterCustomization.SetEyeBlackRight(currentEyeBlackRightIndex);
    }

    // ฟังก์ชันสำหรับเปลี่ยนแขน
    public void ChangeArm()
    {
        currentArmLeftIndex = (currentArmLeftIndex + 1) % armCount;
        currentArmRightIndex = (currentArmRightIndex + 1) % armCount;
        characterCustomization.SetArmLeft(currentArmLeftIndex);
        characterCustomization.SetArmRight(currentArmRightIndex);
    }

    // ฟังก์ชันสำหรับเปลี่ยนขา
    public void ChangeLeg()
    {
        currentLegLeftIndex = (currentLegLeftIndex + 1) % legCount;
        currentLegRightIndex = (currentLegRightIndex + 1) % legCount;
        characterCustomization.SetLegLeft(currentLegLeftIndex);
        characterCustomization.SetLegRight(currentLegRightIndex);
    }

    // ฟังก์ชันสำหรับเปลี่ยนหาง
    public void ChangeTail()
    {
        currentTailIndex = (currentTailIndex + 1) % tailCount;
        characterCustomization.SetTail(currentTailIndex);
    }

    // ฟังก์ชันสำหรับเปลี่ยนหัว
    public void ChangeHead()
    {
        currentHeadIndex = (currentHeadIndex + 1) % headCount;
        characterCustomization.SetHead(currentHeadIndex);
    }

    // ฟังก์ชันสำหรับเปลี่ยนปาก
    public void ChangeMouth()
    {
        currentMouthIndex = (currentMouthIndex + 1) % mouthCount;
        characterCustomization.SetMouth(currentMouthIndex);
    }

    // ฟังก์ชันสำหรับเปลี่ยนตัว
    public void ChangeBody()
    {
        currentBodyIndex = (currentBodyIndex + 1) % bodyCount;
        characterCustomization.SetBody(currentBodyIndex);
    }
    
    //ปุ่มเลือกชุดหัว:
    public void OnHeadSetButtonClicked(int index)
    {
        //characterCustomization.SetHeadSet(index);
        ChangeEar();
        ChangeEyeWhite();
        ChangeEyeBlack();
        ChangeHead();
        ChangeMouth();

    }
    
    //ปุ่มเลือกชุดตัว:
    public void OnBodySetButtonClicked(int index)
    {
        //characterCustomization.SetBodySet(index);
        ChangeArm();
        ChangeLeg();
        ChangeTail();
        ChangeBody();
    }

    //ปุ่มเลือกอุปกรณ์ตกแต่ง:
    public void OnAccessorySetButtonClicked(int index)
    {
        //characterCustomization.SetAccessorySet(index);
    }
    
    public void OnFinishButtonClicked()
    {
        SceneManager.LoadScene("Join And Host");
    }


}




/*
using UnityEngine;

/*public class UIManager : MonoBehaviour
{
    public CharacterCustomization characterCustomization;

    private int currentHeadIndex = 0;
    private int currentBodyIndex = 0;
    private int currentAccessoryIndex = 0;

    private int headCount;
    private int bodyCount;
    private int accessoryCount;

    void Start()
    {
        headCount = characterCustomization.headOptions.Length;
        bodyCount = characterCustomization.bodyOptions.Length;
        accessoryCount = characterCustomization.earLeftOptions.Length; // ใช้จำนวนหูซ้ายเป็นตัวแทน
    }

    public void OnHeadSetButtonClicked(int direction)
    {
        currentHeadIndex = (currentHeadIndex + direction + headCount) % headCount;
        characterCustomization.SetHeadSet(currentHeadIndex);
    }

    public void OnBodySetButtonClicked(int direction)
    {
        currentBodyIndex = (currentBodyIndex + direction + bodyCount) % bodyCount;
        characterCustomization.SetBodySet(currentBodyIndex);
    }

    public void OnAccessorySetButtonClicked(int direction)
    {
        currentAccessoryIndex = (currentAccessoryIndex + direction + accessoryCount) % accessoryCount;
        characterCustomization.SetAccessorySet(currentAccessoryIndex);
    }

    public void NextHead() => OnHeadSetButtonClicked(1);
    public void PreviousHead() => OnHeadSetButtonClicked(-1);
    public void NextBody() => OnBodySetButtonClicked(1);
    public void PreviousBody() => OnBodySetButtonClicked(-1);
    public void NextAccessory() => OnAccessorySetButtonClicked(1);
    public void PreviousAccessory() => OnAccessorySetButtonClicked(-1);
}#1#

using UnityEngine;

public class UIManagers : MonoBehaviour
{
    public CharacterCustomization characterCustomization;

    private int currentHeadIndex = 0;
    private int currentBodyIndex = 0;
    private int currentAccessoryIndex = 0;

    private int headCount;
    private int bodyCount;
    private int accessoryCount;

    void Start()
    {
        headCount = characterCustomization.headOptions.Length;
        bodyCount = characterCustomization.bodyOptions.Length;
        accessoryCount = characterCustomization.earLeftOptions.Length; // ใช้จำนวนหูซ้ายเป็นตัวแทน
        
        // อัปเดตค่าเริ่มต้น
        UpdateCharacter();
    }

    public void OnHeadSetButtonClicked(int direction)
    {
        currentHeadIndex = (currentHeadIndex + direction + headCount) % headCount;
        UpdateCharacter();
    }

    public void OnBodySetButtonClicked(int direction)
    {
        currentBodyIndex = (currentBodyIndex + direction + bodyCount) % bodyCount;
        UpdateCharacter();
    }

    public void OnAccessorySetButtonClicked(int direction)
    {
        currentAccessoryIndex = (currentAccessoryIndex + direction + accessoryCount) % accessoryCount;
        UpdateCharacter();
    }

    public void NextHead() => OnHeadSetButtonClicked(1);
    public void PreviousHead() => OnHeadSetButtonClicked(-1);
    public void NextBody() => OnBodySetButtonClicked(1);
    public void PreviousBody() => OnBodySetButtonClicked(-1);
    public void NextAccessory() => OnAccessorySetButtonClicked(1);
    public void PreviousAccessory() => OnAccessorySetButtonClicked(-1);

    private void UpdateCharacter()
    {
        characterCustomization.SetHeadSet(currentHeadIndex);
        characterCustomization.SetBodySet(currentBodyIndex);
        characterCustomization.SetAccessorySet(currentAccessoryIndex);
    }
}
*/
