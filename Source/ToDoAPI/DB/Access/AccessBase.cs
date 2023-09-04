using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.DB
{
    public abstract class AccessBase<Entity, DataDTO> : IAccessBase<DataDTO> where Entity : class
    {
        /// <summary>Database context</summary>
        protected readonly TodoDbContext _context;
        protected readonly IMapper _mapper;

        protected AccessBase(TodoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual List<DataDTO> GetAll(out int errCode)
        {
            errCode = Message.OK;
            try
            {
                return _context.Set<Entity>().AsNoTracking()
                               .Select(p => _mapper.Map<DataDTO>(p)).ToList();
            }
            catch
            {
                errCode = Message.ExceptionError;
                return default;
            }
        }

        public virtual void Insert(dynamic obj, out int errCode)
        {
            errCode = Message.OK;
            try
            {
                var data = _mapper.Map<Entity>(obj);
                _context.Set<Entity>().Add(data);
                _context.SaveChanges();
            }
            catch
            {
                errCode = Message.ExceptionError;
            }
        }

        public virtual void Update(dynamic obj, out int errCode)
        {
            errCode = Message.OK;
            try
            {
                var id = (int)obj.Id;
                var data = _context.Set<Entity>().Find(id);

                foreach (var item in obj)
                {
                    var property = typeof(Entity).GetProperty(item.Name);
                    if (property != null)
                    {
                        var type = property.PropertyType;
                        property.SetValue(data, Convert.ChangeType(item.Value, type));
                    }
                }

                _context.SaveChanges();
            }
            catch
            {
                errCode = Message.ExceptionError;
            }
        }

        public virtual void Delete(int id, out int errCode)
        {
            errCode = Message.OK;
            try
            {
                var data = _context.Set<Entity>().Find(id);
                if (data != null)
                {
                    _context.Set<Entity>().Remove(data);
                    _context.SaveChanges();
                }
            }
            catch
            {
                errCode = Message.ExceptionError;
            }
        }

        public void BeginTransaction()
        {
            _context.BeginTransaction();
        }

        public void Commit()
        {
            _context.Commit();
        }

        public void Rollback()
        {
            _context.Rollback();
        }
    }
}
