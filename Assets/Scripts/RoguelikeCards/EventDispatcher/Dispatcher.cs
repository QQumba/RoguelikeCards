using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace RoguelikeCards.EventDispatcher
{
    public class Dispatcher : IDispatcher
    {
        private readonly Dictionary<Type, RequestHandlerBase> _handlers =
            new Dictionary<Type, RequestHandlerBase>();

        public void Dispatch(IRequest request)
        {
            var handler = _handlers[request.GetType()];
            handler.Handle(request);
        }

        public void RegisterHandler<TRequest>(IRequestHandler<TRequest> handler) where TRequest : IRequest
        {
            _handlers.Add(typeof(TRequest), new RequestHandlerWrapper<TRequest>(handler));
        }
    }
}