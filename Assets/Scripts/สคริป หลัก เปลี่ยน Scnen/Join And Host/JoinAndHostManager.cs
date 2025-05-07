using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class JoinAndHostManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject joinAndHostPanel;
    public GameObject joinRoomPanel;
    public GameObject lobbyPanel;

    [Header("Lobby Settings")]
    public GameObject[] imageSlots; // 6 รูปภาพ
    public TextMeshProUGUI imageCountText;
    public Button startGameButton;

    [Header("Join Input")]
    public TextMeshProUGUI joinCodeText;
    private string currentCode = "";
    
    private Coroutine revealCoroutine;

    private void Start()
    {
        joinAndHostPanel.SetActive(true);
        joinRoomPanel.SetActive(false);
        lobbyPanel.SetActive(false);
    }

    // ----------- HOST FLOW -----------
    public void OnHostClicked()
    {
        joinAndHostPanel.SetActive(false);
        lobbyPanel.SetActive(true);
        //StartCoroutine(RevealImages());
        revealCoroutine = StartCoroutine(RevealImages());
    }

    // ----------- JOIN FLOW -----------
    public void OnJoinClicked()
    {
        joinAndHostPanel.SetActive(false);
        joinRoomPanel.SetActive(true);
    }

    public void OnNumberButtonClicked(string num)
    {
        if (currentCode.Length < 6)
        {
            currentCode += num;
            joinCodeText.text = currentCode;
        }
    }

    public void OnDeleteClicked()
    {
        if (currentCode.Length > 0)
        {
            currentCode = currentCode.Substring(0, currentCode.Length - 1);
            joinCodeText.text = currentCode;
        }
    }

    public void OnOkClicked()
    {
        if (currentCode.Length == 6)
        {
            joinRoomPanel.SetActive(false);
            lobbyPanel.SetActive(true);
            //StartCoroutine(RevealImages());
            revealCoroutine = StartCoroutine(RevealImages());
            
            // Reset Code Text
            currentCode = "";
            joinCodeText.text = "";
        }
    }

    // ----------- IMAGE REVEAL FLOW -----------
    /*IEnumerator RevealImages() // รอคนครบแล้วเริ่มเกม ออโต้
    {
        int revealedCount = 0;
        Shuffle(imageSlots);

        foreach (var img in imageSlots)
        {
            img.SetActive(true);
            revealedCount++;
            imageCountText.text = $"Player {revealedCount} / 6";
            yield return new WaitForSeconds(1.2f);
        }

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Game");
    }*/
    IEnumerator RevealImages()
    {
        int revealedCount = 0;
        Shuffle(imageSlots);

        foreach (var img in imageSlots)
        {
            img.SetActive(true);
            revealedCount++;
            imageCountText.text = $" {revealedCount} / 6";

            // ถ้าครบ 6 คน ให้แสดงปุ่ม Start Game
            if (revealedCount == 6)
            {
                startGameButton.interactable = true; // หรือ .SetActive(true);
            }

            yield return new WaitForSeconds(1.2f);
        }
    }


    void Shuffle(GameObject[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int rnd = Random.Range(0, i + 1);
            var temp = array[i];
            array[i] = array[rnd];
            array[rnd] = temp;
        }
    }
    
    public void OnStartGameClicked()
    {
        SceneManager.LoadScene("Game");
        startGameButton.interactable = false;

    }

    
    public void OnExitLobbyClicked()
    {
        // หยุดการเปิดรูปถ้ายังเปิดไม่ครบ
        if (revealCoroutine != null)
        {
            StopCoroutine(revealCoroutine);
            revealCoroutine = null;
        }

        // รีเซตรูปให้ปิดทั้งหมด
        foreach (var img in imageSlots)
        {
            img.SetActive(false);
        }

        // รีเซตข้อความ
        imageCountText.text = "Player 0 / 6";

        // ปิด Lobby และกลับไปหน้า Join/Host
        lobbyPanel.SetActive(false);
        joinAndHostPanel.SetActive(true);
    }

    public void BackToJoinAndHostPanel()
    {
        joinRoomPanel.SetActive(false);
        joinAndHostPanel.SetActive(true);
        revealCoroutine = StartCoroutine(RevealImages());
            
        // Reset Code Text
        currentCode = "";
        joinCodeText.text = "";
    }

}
