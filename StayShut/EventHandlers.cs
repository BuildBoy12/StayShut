namespace StayShut
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;
    using System.Collections.Generic;
    using static StayShut;
    
    public class EventHandlers
    {
        private CoroutineHandle _handle;

        public void OnRoundStart()
        {
            _handle = Timing.RunCoroutine(CloseAndLockDoors());
        }

        public void OnRoundEnded(RoundEndedEventArgs _)
        {
            Timing.KillCoroutines(_handle);
        }
        
        public IEnumerator<float> CloseAndLockDoors()
        {
            while (true)
            {
                Timing.WaitUntilTrue(() => Warhead.IsInProgress);
                yield return Timing.WaitForSeconds(Instance.Config.DoorShutTime);
                while (true)
                {
                    foreach (Door door in Map.Doors)
                    {
                        if (!Instance.Config.DoorsShut.Contains(door.DoorName))
                            continue;

                        if (Warhead.IsInProgress)
                        {
                            door.NetworkisOpen = false;
                            door.Networklocked = true;
                        }
                        else
                            door.Networklocked = false;
                    }
                    if (!Warhead.IsInProgress)
                        break;
                    yield return Timing.WaitForSeconds(1f);
                }
            }
        }
    }
}