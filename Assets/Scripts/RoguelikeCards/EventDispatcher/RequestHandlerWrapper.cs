namespace RoguelikeCards.EventDispatcher
{
    public class RequestHandlerWrapper<TRequest> : RequestHandlerBase where TRequest : IRequest
    {
        private readonly IRequestHandler<TRequest> _handler;

        public RequestHandlerWrapper(IRequestHandler<TRequest> handler)
        {
            _handler = handler;
        }

        public void Handle(IRequest request)
        {
            _handler.Handle((TRequest) request);
        }

        public override void Handle(object request)
        {
            Handle((TRequest) request);
        }
    }
}