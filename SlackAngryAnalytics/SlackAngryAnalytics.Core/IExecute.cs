using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlackAngryAnalytics.Core
{
    public interface IExecute
    {
        void Execute(object[] parameters);
        T ExecuteAndReturn<T> (object[] parameters);
        void Execute();
        T ExecuteAndReturn<T> ();
    }

    public class RestCaller : IExecute
    {
        private string _token = null;

        public void Execute(object[] parameters)
        {
            throw new NotImplementedException();
        }

        public T ExecuteAndReturn<T>(object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public T ExecuteAndReturn<T>()
        {
            throw new NotImplementedException();
        }
    }
    
}
