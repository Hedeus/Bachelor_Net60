using System.Threading.Tasks;

namespace Bachelor_Net60.Infrastructure
{
    internal delegate Task ActionAsync();

    internal delegate Task ActionAsync<in T>(T parameter);
}
