using System;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour
{
    public long clientId = 123456789012345678; // Bro espero que no hagan nada raro con este ID...
    private Discord.Discord discord;
    private ActivityManager activityManager;

    void Start()
    {
        try
        {
            discord = new Discord.Discord(1342966198140141609, (ulong)Discord.CreateFlags.Default);
            activityManager = discord.GetActivityManager();
            UpdatePresence("Modo: Solitario", "Jugando PvZ-R | Pre-Alfa 0.1.8");
        }
        catch (Exception e)
        {
            Debug.LogError("Error al iniciar Discord SDK: " + e.Message);
        }
    }

    void Update()
    {
        if (discord != null)
        {
            discord.RunCallbacks();
        }
    }

    public void UpdatePresence(string state, string details)
    {
        if (activityManager == null) return;

        var activity = new Activity
        {
            State = state,
            Details = details,
            Assets =
            {
                LargeImage = "icon",
                LargeText = "Plants Vs. Zombies Remade"
            }
        };

        activityManager.UpdateActivity(activity, result =>
        {
            if (result == Result.Ok)
            {
                Debug.Log("Rich Presence actualizado correctamente");
            }
            else
            {
                Debug.LogError("Error al actualizar Rich Presence: " + result);
            }
        });
    }

    void OnApplicationQuit()
    {
        discord?.Dispose();
    }
}