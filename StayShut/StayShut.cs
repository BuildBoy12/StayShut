using System;
using Exiled.API.Features;

namespace StayShut
{
    public class StayShut : Plugin<Config>
    {
        public StayShutEventHandler Handler;
        public override string Name => nameof(StayShut);
        public override string Author => "KoukoCocoa";

        public override void OnEnabled()
        {
            Handler = new StayShutEventHandler(this);
            Exiled.Events.Handlers.Warhead.Starting += Handler.RunWhenWarheadIsActive;
            Exiled.Events.Handlers.Warhead.Stopping += Handler.RunWhenWarheadIsStopped;
            Exiled.Events.Handlers.Server.RoundStarted += Handler.RunWhenRoundStarts;
            Exiled.Events.Handlers.Server.RoundEnded += Handler.RunWhenRoundEnded;
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundEnded -= Handler.RunWhenRoundEnded;
            Exiled.Events.Handlers.Server.RoundStarted -= Handler.RunWhenRoundStarts;
            Exiled.Events.Handlers.Warhead.Stopping -= Handler.RunWhenWarheadIsStopped;
            Exiled.Events.Handlers.Warhead.Starting -= Handler.RunWhenWarheadIsActive;
            Handler = null;
        }

        public override void OnReloaded() { }
    }
}
