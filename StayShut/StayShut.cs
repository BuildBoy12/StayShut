namespace StayShut
{
    using Exiled.API.Features;
    using ServerEvents = Exiled.Events.Handlers.Server;
    
    public class StayShut : Plugin<Config>
    {
        internal static StayShut Instance;
        private readonly EventHandlers _eventHandlers = new EventHandlers();

        public override void OnEnabled()
        {
            Instance = this;
            ServerEvents.RoundEnded += _eventHandlers.OnRoundEnded;
            ServerEvents.RoundStarted += _eventHandlers.OnRoundStart;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            ServerEvents.RoundEnded -= _eventHandlers.OnRoundEnded;
            ServerEvents.RoundStarted -= _eventHandlers.OnRoundStart;
            Instance = null;
            base.OnDisabled();
        }
    }
}