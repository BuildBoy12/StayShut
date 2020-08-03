using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;

namespace StayShut
{
    public class StayShutEventHandler
    {
        bool CountdownIsActive = false;
        StayShut plugin;
        CoroutineHandle Handle;
        public StayShutEventHandler(StayShut plugin) => this.plugin = plugin;

        public void RunWhenRoundStarts()
        {
            Handle = Timing.RunCoroutine(CloseAndLockDoors());
            CountdownIsActive = false;
        }

        public void RunWhenRoundEnded(RoundEndedEventArgs EndedRound)
        {
            Timing.KillCoroutines(Handle);
            CountdownIsActive = false;
        }

        public void RunWhenWarheadIsActive(StartingEventArgs WarheadStarted)
        {
            CountdownIsActive = true;
        }

        public void RunWhenWarheadIsStopped(StoppingEventArgs WarheadStopped)
        {
            CountdownIsActive = false;
        }

        public IEnumerator<float> CloseAndLockDoors()
        {
            while (true)
            {
                if (!CountdownIsActive)
                    yield return Timing.WaitForOneFrame;
                else
                {
                    yield return Timing.WaitForSeconds(plugin.Config.DoorShutTime);
                    while (true)
                    {
                        foreach (Door door in Map.Doors)
                        {
                            if (!plugin.Config.DoorsShut.Contains(door.DoorName))
                                continue;

                            if (CountdownIsActive)
                            {
                                door.NetworkisOpen = false;
                                door.Networklocked = true;
                            }
                            else
                                door.Networklocked = false;
                        }
                        if (!CountdownIsActive)
                            break;
                        yield return Timing.WaitForSeconds(1f);
                    }
                }
            }
        }
    }
}
