namespace DAL.Modules.Comptes;
public static class CompteMethodExtensions
{
    public static bool IsEnable(this Compte compte)
    {
        return compte.EstValider == "1";
    }
}
