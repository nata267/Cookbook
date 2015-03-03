using System;
using Cookbook.Data.Models;

namespace Cookbook.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        CookbookEntities Get();
    }
}

