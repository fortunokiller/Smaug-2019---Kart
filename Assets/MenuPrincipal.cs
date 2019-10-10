using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviourPunCallbacks
{
    public GameObject panelCreditos, panelConfiguracoes, panelJogarOnline, panelSala;

    public InputField nickName;

    public GameObject sala, painelDeSalas;

    public GameObject panelJogadoresConectados, jogadorConectado;

    

    public void FecharJogo()
    {
        Debug.Log("Fechar o jogo...");
        Application.Quit();           
    }

    public void Creditos()
    {
        panelCreditos.SetActive(true);
    }
    public void JogarOnline()
    {
        
        PhotonNetwork.ConnectUsingSettings();
        if (PhotonNetwork.IsConnected)
        {
            panelJogarOnline.SetActive(true);
            Debug.Log("Conectado ao Photon");
        }
        
    }
    public void Configuracoes()
    {
        panelConfiguracoes.SetActive(true);
    }

    public void Voltar()
    {
        panelCreditos.SetActive(false);
        panelJogarOnline.SetActive(false);
        panelConfiguracoes.SetActive(false);
        panelSala.SetActive(false);
    }

    public override void OnCreatedRoom()
    {
        if (nickName.text != "")
        {
            base.OnCreatedRoom();
            Debug.Log("Criando uma sala");
            Instantiate(sala,painelDeSalas.transform);
            
        }       
    }

    public override void OnJoinedRoom()
    {
        if (nickName.text != "")
        {
            base.OnJoinedRoom();
            panelSala.SetActive(true);
            Instantiate(jogadorConectado, panelJogadoresConectados.transform);
            
            Debug.Log("entrando neste sala");
        }      
    }
}
