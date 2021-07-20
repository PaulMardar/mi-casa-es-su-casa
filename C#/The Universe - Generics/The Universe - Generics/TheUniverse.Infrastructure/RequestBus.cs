using System;
using System.Collections.Generic;

namespace iQuest.TheUniverse.Infrastructure
{
    public class RequestBus
    {
        private readonly Dictionary<Type, Type> handlers = new Dictionary<Type, Type>();

        public void RegisterHandler<TRequest, TResponse, THandler>() where THandler : IRequestHandler<TRequest, TResponse>
        {
            if (typeof(THandler).IsAbstract)
            {
                throw new ArgumentException("THandler must be a concrete type", nameof(THandler));
            }

            if (handlers.ContainsKey(typeof(TRequest)))
            {
                throw new ArgumentException("TRequest is already registered.", nameof(TRequest));
            }

            handlers.Add(typeof(TRequest), typeof(THandler));
        }

        public TResponse Send<TRequest, TResponse>(TRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            Type requestType = request.GetType();

            if (!handlers.TryGetValue(requestType, out var requestHandlerType))
            {
                throw new Exception("Request handler not registered for the specified request.");
            }

            if (Activator.CreateInstance(requestHandlerType) is IRequestHandler<TRequest, TResponse> requestHandler)
            {
                return requestHandler.Execute(request);
            }
            else
            {
                throw new Exception("Send instatiated at incorrect generic type parameters");
            }
        }
    }
}
