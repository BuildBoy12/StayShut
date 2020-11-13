namespace StayShut
{
    using Exiled.API.Interfaces;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("Delay before doors close after the warhead starts.")]
        public int DoorShutTime { get; private set; } = 10;
        
        [Description("Name of all doors that close when the warhead starts.")]
        public List<string> DoorsShut { get; private set; } = new List<string>
        {
            "LCZ_ARMORY", "HCZ_ARMORY", "NUKE_ARMORY"
        };
    }
}