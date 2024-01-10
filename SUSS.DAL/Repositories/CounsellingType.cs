namespace SUSS.DAL.Repositories
{
    public class CounsellingType : ICounsellingType
    {
        private static int _counsellingID = 0;
        void ICounsellingType.SetCounsellingType(string key)
        {
            switch (key.ToUpper())
            {
                case ("COUNSELLING"): _counsellingID = 1; break;
                case ("DREAMWORKS"): _counsellingID = 2; break;
                case ("COACHING"): _counsellingID = 3; break;
            }
        }

        int ICounsellingType.GetCounsellingType()
        {
            return _counsellingID;
        }

        void ICounsellingType.SetCounsellingType(int key)
        {
            _counsellingID = key;
        }
    }
}
