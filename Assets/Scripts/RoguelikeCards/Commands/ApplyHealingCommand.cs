using System.Diagnostics;
using RoguelikeCards.EventDispatcher;

namespace RoguelikeCards.Commands
{
    public class ApplyHealingCommand : IRequest
    {
        public ApplyHealingCommand(int heal, Targets targets)
        {
            Heal = heal;
            Targets = targets;
        }

        public int Heal { get; }
        public Targets Targets { get; }
    }

    public class ApplyHealingHandler : IRequestHandler<ApplyHealingCommand>
    {
        private readonly GameFieldNavigator _navigator;

        public ApplyHealingHandler(GameFieldNavigator navigator)
        {
            _navigator = navigator;
        }

        public void Handle(ApplyHealingCommand request)
        {
            if (request.Targets.Is(Targets.Hero))
            {
                var hero = _navigator.Hero;
                hero.ApplyHealing(request.Heal);
            }
        }
    }
}