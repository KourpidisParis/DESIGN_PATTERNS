using System;

namespace DesignPatterns.Behavioral.ChainOfResponsibilityPattern
{
    /// <summary>
    /// Abstract Handler - Base class for all support handlers
    /// </summary>
    public abstract class SupportHandler
    {
        protected SupportHandler _nextHandler;

        public void SetNext(SupportHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public abstract void HandleRequest(SupportRequest request);
    }
}