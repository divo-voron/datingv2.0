namespace Dating_For_Natali
{
    class Program
    {
        static void Main(string[] args)
        {
            DatingAction action = new DatingAction();

            action.InitializeSession();
            action.Login();

            //TestFramework.Dispose();
        }
    }
}
