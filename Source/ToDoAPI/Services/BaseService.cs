namespace ToDoAPI.Services
{
    public partial class BaseService<DataDTO> : IBaseService<DataDTO>
    {
        private readonly IAccessBase<DataDTO> _accessBase;

        public BaseService(IAccessBase<DataDTO> accessBase)
        {
            _accessBase = accessBase;
        }

        public IResponse GetAll(out int errCode)
        {
            try
            {
                // Get all from db
                var result = _accessBase.GetAll(out errCode);
                if (errCode == Message.OK)
                {
                    return new DataResponse(result);
                }
            }
            catch
            {
                errCode = Message.ExceptionError;
            }

            return new MessageResponse(Define.StatusType.ERROR, errCode);
        }

        public void BeginTransaction()
        {
            _accessBase.BeginTransaction();
        }

        public void Commit()
        {
            _accessBase.Commit();
        }

        public void Rollback()
        {
            _accessBase.Rollback();
        }
    }
}
