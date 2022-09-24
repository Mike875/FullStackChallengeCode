namespace Sample.Repositories
{
    public class BusinessDBContextSingleton
    {
        private const byte _MAX_REF_COUNT = 200;

        private static BusinessDBContextSingleton _Instance;

        private BusinessDBContext _BusinessDBContext;

        private byte _ReferenceCount;

        public BusinessDBContext BusinessDBContext
        {
            get
            {
                _ReferenceCount++;

                if(_ReferenceCount >= _MAX_REF_COUNT)
                {
                    _BusinessDBContext.Dispose();
                    _BusinessDBContext = new BusinessDBContext();
                }

                return _BusinessDBContext;
            }
            set
            {
                _BusinessDBContext = value;
            }
        }

        private BusinessDBContextSingleton()
        {
            _ReferenceCount = 0;
        }

        public static BusinessDBContextSingleton Instance()
        {
            if(_Instance == null) { _Instance = new BusinessDBContextSingleton(); }
            return _Instance;
        }
    }
}
