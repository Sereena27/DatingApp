using API.Interfaces;
using AutoMapper;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;

        private readonly Datacontext _context;
        public UnitOfWork(Datacontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }
        public IUserRepository UserRepository => new UserRepository(_context, _mapper);

        public IMessageRepository MessageRepository => new MessageRepository(_context, _mapper);

        public ILikeRepository LikeRepository => new LikeRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
           return _context.ChangeTracker.HasChanges(); 
        }
    }
}