using System.Collections.Generic;
using System.Text;

namespace Framework.Identity
{
    public interface IPasswordHasher
    {
        string Hash(string password);

        (bool Verified, bool NeedsUpgrade) Check(string hash, string password);
    }
}