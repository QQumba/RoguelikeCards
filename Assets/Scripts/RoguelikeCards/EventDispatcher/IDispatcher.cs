namespace RoguelikeCards.EventDispatcher
{
    public interface IDispatcher
    {
        void Dispatch(IRequest request);
    }
}