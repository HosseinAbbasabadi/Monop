﻿namespace Framework.Testing.Hosting.Core
{
    public interface IStartableHost : IHost
    {
        void Start();
        void Stop();
    }
}