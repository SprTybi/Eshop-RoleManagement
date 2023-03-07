namespace Framework.Services
{
    public interface IPasswordHasher
    {
       //Password Must be hashed
        string Hash(string password);

        (bool Verified, bool NeedsUpgrade) Check(string hash, string password);
    }
}