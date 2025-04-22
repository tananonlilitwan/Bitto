using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    private TcpListener tcpListener;
    private TcpClient tcpClient;
    private NetworkStream networkStream;

    private void Start()
    {
        StartServer();
    }

    // เริ่มต้น Server
    private void StartServer()
    {
        tcpListener = new TcpListener(IPAddress.Any, 7777); // IPAddress.Any เพื่อรับการเชื่อมต่อจากทุกที่
        tcpListener.Start();
        Debug.Log("Server Started, waiting for connection...");
        tcpListener.BeginAcceptTcpClient(OnClientConnect, tcpListener); // เริ่มรอ client
    }

    // เมื่อมีการเชื่อมต่อกับ client
    private void OnClientConnect(IAsyncResult result)
    {
        tcpClient = tcpListener.EndAcceptTcpClient(result);
        networkStream = tcpClient.GetStream();
        Debug.Log("Client Connected!");

        // เริ่มฟังการรับข้อมูลจาก client
        ReceiveData();
    }

    // รับข้อมูลจาก client
    private void ReceiveData()
    {
        byte[] buffer = new byte[1024];
        networkStream.BeginRead(buffer, 0, buffer.Length, OnDataReceived, buffer);
    }

    // เมื่อรับข้อมูลจาก client
    private void OnDataReceived(IAsyncResult result)
    {
        byte[] buffer = (byte[])result.AsyncState;
        int bytesRead = networkStream.EndRead(result);
        
        if (bytesRead > 0)
        {
            string message = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Debug.Log("Received: " + message);
        }

        // หลังจากรับข้อมูลเสร็จแล้ว เราจะฟังข้อมูลใหม่จาก client
        ReceiveData();
    }

    // ส่งข้อมูลไปยัง client
    public void SendData(string message)
    {
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(message);
        networkStream.Write(buffer, 0, buffer.Length);
    }

    private void OnApplicationQuit()
    {
        if (tcpListener != null)
        {
            tcpListener.Stop();
        }
        if (tcpClient != null)
        {
            tcpClient.Close();
        }
    }
}