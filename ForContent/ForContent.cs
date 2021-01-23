using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modding;


namespace ForContent
{
    /// <summary>
    /// Disables isma's tear and lantern. Can be disabled from mod menu.
    /// </summary>
    public class ForContent : Mod, ITogglableMod
    {

        public override string GetVersion() => "1.0";

        // Hook to GetPlayerBoolHook
        public override void Initialize()
        {
            Log("Disabling Isma's and Lantern...");
            ModHooks.Instance.GetPlayerBoolHook += PlayerBoolGet;
        }

        // Unhook from GetPlayerBoolHook
        public void Unload()
        {
            Log("Allowing Isma's and Lantern...");
            ModHooks.Instance.GetPlayerBoolHook -= PlayerBoolGet;
        }

        // Overrides isma's and lantern bool gets.
        public bool PlayerBoolGet(string target)
        {
            switch (target)
            {
                // Prevent game from reading isma's or lantern
                case "hasAcidArmour":
                case "hasLantern":
                    return false;
                // Allow other bools through
                default:
                    return PlayerData.instance.GetBoolInternal(target);
            }
            
        }

    }
}
