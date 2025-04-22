
/*using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    // ตัวแปรเก็บ Prefab ของแต่ละชิ้นส่วน
    public GameObject baseCharacter; // ตัวละครหลักที่เป็น Object Base
    public Sprite[] earLeftOptions; // ตัวเลือกหูซ้าย
    public Sprite[] earRightOptions; // ตัวเลือกหูขวา
    public Sprite[] headOptions; // ตัวเลือกหัว
    public Sprite[] eyeWhiteLeftOptions; // ตัวเลือกตาขาวซ้าย
    public Sprite[] eyeWhiteRightOptions; // ตัวเลือกตาขาวขวา
    public Sprite[] eyeBlackLeftOptions; // ตัวเลือกตาดำซ้าย
    public Sprite[] eyeBlackRightOptions; // ตัวเลือกตาดำขวา
    public Sprite[] mouthOptions; // ตัวเลือกปาก
    public Sprite[] bodyOptions; // ตัวเลือกตัว
    public Sprite[] armLeftOptions; // ตัวเลือกแขนซ้าย
    public Sprite[] armRightOptions; // ตัวเลือกแขนขวา
    public Sprite[] legLeftOptions; // ตัวเลือกขาซ้าย
    public Sprite[] legRightOptions; // ตัวเลือกขาขวา
    public Sprite[] tailOptions; // ตัวเลือกหาง

    // ตัวแปรเก็บอ้างอิงถึงชิ้นส่วนที่ถูกเลือก
    //private SpriteRenderer currentHairRenderer;
    private SpriteRenderer currentEarLeftRenderer;
    private SpriteRenderer currentEarRightRenderer;
    private SpriteRenderer currentHeadRenderer;
    private SpriteRenderer currentEyeWhiteLeftRenderer;
    private SpriteRenderer currentEyeWhiteRightRenderer;
    private SpriteRenderer currentEyeBlackLeftRenderer;
    private SpriteRenderer currentEyeBlackRightRenderer;
    private SpriteRenderer currentMouthRenderer;
    private SpriteRenderer currentBodyRenderer;
    private SpriteRenderer currentArmLeftRenderer;
    private SpriteRenderer currentArmRightRenderer;
    private SpriteRenderer currentLegLeftRenderer;
    private SpriteRenderer currentLegRightRenderer;
    private SpriteRenderer currentTailRenderer;

    
    private Vector3 armLeftStartPos, armRightStartPos; // เก็บตำแหน่งเริ่มต้นของแขนซ้ายและขวา

    
    private void Start()
    {
        // ดึง SpriteRenderer จากชิ้นส่วนต่างๆ ของ Object Base
        // อ้างอิงการดึงแต่ละส่วนของตัวละครที่มีอยู่ใน Object Base
        //currentHairRenderer = baseCharacter.transform.Find("Hair").GetComponent<SpriteRenderer>();
        currentEarLeftRenderer = baseCharacter.transform.Find("EarLeft").GetComponent<SpriteRenderer>();
        currentEarRightRenderer = baseCharacter.transform.Find("EarRight").GetComponent<SpriteRenderer>();
        currentHeadRenderer = baseCharacter.transform.Find("Head").GetComponent<SpriteRenderer>();
        currentEyeWhiteLeftRenderer = baseCharacter.transform.Find("EyeWhiteLeft").GetComponent<SpriteRenderer>();
        currentEyeWhiteRightRenderer = baseCharacter.transform.Find("EyeWhiteRight").GetComponent<SpriteRenderer>();
        currentEyeBlackLeftRenderer = baseCharacter.transform.Find("EyeBlackLeft").GetComponent<SpriteRenderer>();
        currentEyeBlackRightRenderer = baseCharacter.transform.Find("EyeBlackRight").GetComponent<SpriteRenderer>();
        currentMouthRenderer = baseCharacter.transform.Find("Mouth").GetComponent<SpriteRenderer>();
        currentBodyRenderer = baseCharacter.transform.Find("Body").GetComponent<SpriteRenderer>();
        currentArmLeftRenderer = baseCharacter.transform.Find("ArmLeft").GetComponent<SpriteRenderer>();
        currentArmRightRenderer = baseCharacter.transform.Find("ArmRight").GetComponent<SpriteRenderer>();
        currentLegLeftRenderer = baseCharacter.transform.Find("LegLeft").GetComponent<SpriteRenderer>();
        currentLegRightRenderer = baseCharacter.transform.Find("LegRight").GetComponent<SpriteRenderer>();
        currentTailRenderer = baseCharacter.transform.Find("Tail").GetComponent<SpriteRenderer>();
        
        // บันทึกตำแหน่งตั้งต้นของแขน
        armLeftStartPos = currentArmLeftRenderer.transform.localPosition;
        armRightStartPos = currentArmRightRenderer.transform.localPosition;
    }

    // ฟังก์ชันสำหรับเปลี่ยนหูซ้าย
    public void SetEarLeft(int index)
    {
        // เปลี่ยน sprite ของหูซ้ายตามตัวเลือกที่เลือก
        currentEarLeftRenderer.sprite = earLeftOptions[index];
    }

    // ฟังก์ชันสำหรับเปลี่ยนหูขวา
    public void SetEarRight(int index)
    {
        // เปลี่ยน sprite ของหูขวาตามตัวเลือกที่เลือก
        currentEarRightRenderer.sprite = earRightOptions[index];
    }

    // ฟังก์ชันสำหรับเปลี่ยนหัว
    public void SetHead(int index)
    {
        // เปลี่ยน sprite ของหัวตามตัวเลือกที่เลือก
        currentHeadRenderer.sprite = headOptions[index];
    }

    // ฟังก์ชันสำหรับเปลี่ยนตาขาวซ้าย
    public void SetEyeWhiteLeft(int index)
    {
        // เปลี่ยน sprite ของตาขาวซ้ายตามตัวเลือกที่เลือก
        currentEyeWhiteLeftRenderer.sprite = eyeWhiteLeftOptions[index];
    }

    // ฟังก์ชันสำหรับเปลี่ยนตาขาวขวา
    public void SetEyeWhiteRight(int index)
    {
        // เปลี่ยน sprite ของตาขาวขวาตามตัวเลือกที่เลือก
        currentEyeWhiteRightRenderer.sprite = eyeWhiteRightOptions[index];
    }

    // ฟังก์ชันสำหรับเปลี่ยนตาดำซ้าย
    public void SetEyeBlackLeft(int index)
    {
        // เปลี่ยน sprite ของตาดำซ้ายตามตัวเลือกที่เลือก
        currentEyeBlackLeftRenderer.sprite = eyeBlackLeftOptions[index];
    }

    // ฟังก์ชันสำหรับเปลี่ยนตาดำขวา
    public void SetEyeBlackRight(int index)
    {
        // เปลี่ยน sprite ของตาดำขวาตามตัวเลือกที่เลือก
        currentEyeBlackRightRenderer.sprite = eyeBlackRightOptions[index];
    }

    // ฟังก์ชันสำหรับเปลี่ยนปาก
    public void SetMouth(int index)
    {
        // เปลี่ยน sprite ของปากตามตัวเลือกที่เลือก
        currentMouthRenderer.sprite = mouthOptions[index];
    }

    // ฟังก์ชันสำหรับเปลี่ยนตัว
    public void SetBody(int index)
    {
        // เปลี่ยน sprite ของตัวตามตัวเลือกที่เลือก
        currentBodyRenderer.sprite = bodyOptions[index];
    }

    // ฟังก์ชันสำหรับเปลี่ยนแขนซ้าย
    public void SetArmLeft(int index)
    {
        // เปลี่ยน sprite ของแขนซ้ายตามตัวเลือกที่เลือก
        currentArmLeftRenderer.sprite = armLeftOptions[index];
        currentArmLeftRenderer.transform.localPosition = armLeftStartPos; // รีเซ็ตตำแหน่งแขนซ้ายให้กลับไปที่เดิม
    }

    // ฟังก์ชันสำหรับเปลี่ยนแขนขวา
    public void SetArmRight(int index)
    {
        // เปลี่ยน sprite ของแขนขวาตามตัวเลือกที่เลือก
        currentArmRightRenderer.sprite = armRightOptions[index];
        currentArmRightRenderer.transform.localPosition = armRightStartPos; // รีเซ็ตตำแหน่งแขนขวาให้กลับไปที่เดิม
    }

    // ฟังก์ชันสำหรับเปลี่ยนขาซ้าย
    public void SetLegLeft(int index)
    {
        // เปลี่ยน sprite ของขาซ้ายตามตัวเลือกที่เลือก
        currentLegLeftRenderer.sprite = legLeftOptions[index];
    }

    // ฟังก์ชันสำหรับเปลี่ยนขาขวา
    public void SetLegRight(int index)
    {
        // เปลี่ยน sprite ของขาขวาตามตัวเลือกที่เลือก
        currentLegRightRenderer.sprite = legRightOptions[index];
    }

    // ฟังก์ชันสำหรับเปลี่ยนหาง
    public void SetTail(int index)
    {
        // เปลี่ยน sprite ของหางตามตัวเลือกที่เลือก
        currentTailRenderer.sprite = tailOptions[index];
    }
}*/



using UnityEngine;

/*
public class CharacterCustomization : MonoBehaviour
{
    public GameObject baseCharacter;

    public Sprite[] headOptions, eyeWhiteLeftOptions, eyeWhiteRightOptions;
    public Sprite[] eyeBlackLeftOptions, eyeBlackRightOptions;
    public Sprite[] mouthOptions; //hatOptions;

    public Sprite[] bodyOptions, armLeftOptions, armRightOptions;
    public Sprite[] legLeftOptions, legRightOptions;

    public Sprite[] earLeftOptions, earRightOptions, tailOptions;

    private SpriteRenderer currentHeadRenderer, currentEyeWhiteLeftRenderer, currentEyeWhiteRightRenderer;
    private SpriteRenderer currentEyeBlackLeftRenderer, currentEyeBlackRightRenderer;
    private SpriteRenderer currentMouthRenderer, currentHatRenderer;
    private SpriteRenderer currentBodyRenderer, currentArmLeftRenderer, currentArmRightRenderer;
    private SpriteRenderer currentLegLeftRenderer, currentLegRightRenderer;
    private SpriteRenderer currentEarLeftRenderer, currentEarRightRenderer, currentTailRenderer;

    private void Start()
    {
        currentHeadRenderer = baseCharacter.transform.Find("Head").GetComponent<SpriteRenderer>();
        currentEyeWhiteLeftRenderer = baseCharacter.transform.Find("EyeWhiteLeft").GetComponent<SpriteRenderer>();
        currentEyeWhiteRightRenderer = baseCharacter.transform.Find("EyeWhiteRight").GetComponent<SpriteRenderer>();
        currentEyeBlackLeftRenderer = baseCharacter.transform.Find("EyeBlackLeft").GetComponent<SpriteRenderer>();
        currentEyeBlackRightRenderer = baseCharacter.transform.Find("EyeBlackRight").GetComponent<SpriteRenderer>();
        currentMouthRenderer = baseCharacter.transform.Find("Mouth").GetComponent<SpriteRenderer>();
        //currentHatRenderer = baseCharacter.transform.Find("Hat").GetComponent<SpriteRenderer>();

        currentBodyRenderer = baseCharacter.transform.Find("Body").GetComponent<SpriteRenderer>();
        currentArmLeftRenderer = baseCharacter.transform.Find("ArmLeft").GetComponent<SpriteRenderer>();
        currentArmRightRenderer = baseCharacter.transform.Find("ArmRight").GetComponent<SpriteRenderer>();
        currentLegLeftRenderer = baseCharacter.transform.Find("LegLeft").GetComponent<SpriteRenderer>();
        currentLegRightRenderer = baseCharacter.transform.Find("LegRight").GetComponent<SpriteRenderer>();

        currentEarLeftRenderer = baseCharacter.transform.Find("EarLeft").GetComponent<SpriteRenderer>();
        currentEarRightRenderer = baseCharacter.transform.Find("EarRight").GetComponent<SpriteRenderer>();
        currentTailRenderer = baseCharacter.transform.Find("Tail").GetComponent<SpriteRenderer>();
    }

    public void SetHeadSet(int index)
    {
        currentHeadRenderer.sprite = headOptions[index];
        currentEyeWhiteLeftRenderer.sprite = eyeWhiteLeftOptions[index];
        currentEyeWhiteRightRenderer.sprite = eyeWhiteRightOptions[index];
        currentEyeBlackLeftRenderer.sprite = eyeBlackLeftOptions[index];
        currentEyeBlackRightRenderer.sprite = eyeBlackRightOptions[index];
        currentMouthRenderer.sprite = mouthOptions[index];
        //currentHatRenderer.sprite = hatOptions[index];
    }

    public void SetBodySet(int index)
    {
        currentBodyRenderer.sprite = bodyOptions[index];
        currentArmLeftRenderer.sprite = armLeftOptions[index];
        currentArmRightRenderer.sprite = armRightOptions[index];
        currentLegLeftRenderer.sprite = legLeftOptions[index];
        currentLegRightRenderer.sprite = legRightOptions[index];
    }

    public void SetAccessorySet(int index)
    {
        currentEarLeftRenderer.sprite = earLeftOptions[index];
        currentEarRightRenderer.sprite = earRightOptions[index];
        currentTailRenderer.sprite = tailOptions[index];
    }
}
*/


public class CharacterCustomization : MonoBehaviour
{
    public GameObject baseCharacter;

    public Sprite[] headOptions, eyeWhiteLeftOptions, eyeWhiteRightOptions;
    public Sprite[] eyeBlackLeftOptions, eyeBlackRightOptions;
    public Sprite[] mouthOptions;

    public Sprite[] bodyOptions, armLeftOptions, armRightOptions;
    public Sprite[] legLeftOptions, legRightOptions;

    public Sprite[] earLeftOptions, earRightOptions, tailOptions;

    private SpriteRenderer currentHeadRenderer, currentEyeWhiteLeftRenderer, currentEyeWhiteRightRenderer;
    private SpriteRenderer currentEyeBlackLeftRenderer, currentEyeBlackRightRenderer;
    private SpriteRenderer currentMouthRenderer;
    private SpriteRenderer currentBodyRenderer, currentArmLeftRenderer, currentArmRightRenderer;
    private SpriteRenderer currentLegLeftRenderer, currentLegRightRenderer;
    private SpriteRenderer currentEarLeftRenderer, currentEarRightRenderer, currentTailRenderer;

    private void Awake()
    {
        currentHeadRenderer = baseCharacter.transform.Find("Head").GetComponent<SpriteRenderer>();
        currentEyeWhiteLeftRenderer = baseCharacter.transform.Find("EyeWhiteLeft").GetComponent<SpriteRenderer>();
        currentEyeWhiteRightRenderer = baseCharacter.transform.Find("EyeWhiteRight").GetComponent<SpriteRenderer>();
        currentEyeBlackLeftRenderer = baseCharacter.transform.Find("EyeBlackLeft").GetComponent<SpriteRenderer>();
        currentEyeBlackRightRenderer = baseCharacter.transform.Find("EyeBlackRight").GetComponent<SpriteRenderer>();
        currentMouthRenderer = baseCharacter.transform.Find("Mouth").GetComponent<SpriteRenderer>();
        
        currentBodyRenderer = baseCharacter.transform.Find("Body").GetComponent<SpriteRenderer>();
        currentArmLeftRenderer = baseCharacter.transform.Find("ArmLeft").GetComponent<SpriteRenderer>();
        currentArmRightRenderer = baseCharacter.transform.Find("ArmRight").GetComponent<SpriteRenderer>();
        currentLegLeftRenderer = baseCharacter.transform.Find("LegLeft").GetComponent<SpriteRenderer>();
        currentLegRightRenderer = baseCharacter.transform.Find("LegRight").GetComponent<SpriteRenderer>();

        currentEarLeftRenderer = baseCharacter.transform.Find("EarLeft").GetComponent<SpriteRenderer>();
        currentEarRightRenderer = baseCharacter.transform.Find("EarRight").GetComponent<SpriteRenderer>();
        currentTailRenderer = baseCharacter.transform.Find("Tail").GetComponent<SpriteRenderer>();
    }

    public void SetHeadSet(int index)
    {
        currentHeadRenderer.sprite = headOptions[index];
        currentEyeWhiteLeftRenderer.sprite = eyeWhiteLeftOptions[index];
        currentEyeWhiteRightRenderer.sprite = eyeWhiteRightOptions[index];
        currentEyeBlackLeftRenderer.sprite = eyeBlackLeftOptions[index];
        currentEyeBlackRightRenderer.sprite = eyeBlackRightOptions[index];
        currentMouthRenderer.sprite = mouthOptions[index];
    }

    public void SetBodySet(int index)
    {
        currentBodyRenderer.sprite = bodyOptions[index];
        currentArmLeftRenderer.sprite = armLeftOptions[index];
        currentArmRightRenderer.sprite = armRightOptions[index];
        currentLegLeftRenderer.sprite = legLeftOptions[index];
        currentLegRightRenderer.sprite = legRightOptions[index];
    }

    public void SetAccessorySet(int index)
    {
        currentEarLeftRenderer.sprite = earLeftOptions[index];
        currentEarRightRenderer.sprite = earRightOptions[index];
        currentTailRenderer.sprite = tailOptions[index];
    }
}
