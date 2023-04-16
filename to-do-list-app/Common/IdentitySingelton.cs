namespace to_do_list_app.Common
{
    public class IdentitySingelton
    {
        public long UserId { get; set; }

        private static IdentitySingelton _identitySingelton;
        private IdentitySingelton()
        {

        }

        public static void BuildInstance(long userId)
        {
            if (_identitySingelton is null)
            {
                _identitySingelton = new IdentitySingelton();
                _identitySingelton.UserId = userId;
            }
            else throw new Exception("Instance is not null");
        }

        public static IdentitySingelton GetInstance()
        {
            return _identitySingelton;
        }
    }
}
