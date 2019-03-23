﻿using System;
using UnityEngine;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Unity;
using BeardedManStudios.Forge.Networking.Generated;

/// <summary>
/// Creates a new <see cref="InputListenerPlayer2"/> when a <see cref="NetworkingPlayer"/> connects to 
/// the active scene and assigns it to that <see cref="NetworkingPlayer"/> via ownership.
/// </summary>
public class InputListenerPlayerSpawner2 : MonoBehaviour {
    //Functions
    #region Unity
    void Start () {
        if (NetworkManager.Instance == null || !NetworkManager.Instance.IsServer) {
            return;
        }

        NetworkManager.Instance.Networker.playerAccepted += Networker_playerAccepted;
    }

    #endregion

    #region Events
    void Networker_playerAccepted (NetworkingPlayer pPlayer, NetWorker pSender) {
        MainThreadManager.Run(() => {
            if (NetworkManager.Instance == null) {
                return;
            }

            InputListenerPlayer2Behavior playerBehavior = NetworkManager.Instance.InstantiateInputListenerPlayer2();
            if (playerBehavior == null) {
                return;
            }

            pPlayer.disconnected += (networker) => {
                playerBehavior.networkObject.Destroy();
            };

            playerBehavior.networkObject.ownerId = pPlayer.NetworkId;
        });
    }

    #endregion
}