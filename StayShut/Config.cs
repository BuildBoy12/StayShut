using System;
using System.Collections.Generic;
using Exiled.API.Interfaces;

namespace StayShut
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public float DoorShutTime { get; set; } = 0.5f;
        public List<string> DoorsShut { get; private set; } = new List<string>() { "LCZ_ARMORY", "HCZ_ARMORY", "NUKE_ARMORY" };
    }
}
