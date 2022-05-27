namespace SchneiderHolzApi.Services;

using AutoMapper;
using BCrypt.Net;
using SchneiderHolzApi.Authorization;
using SchneiderHolzApi.Entities;
using SchneiderHolzApi.Helpers;
using SchneiderHolzApi.Models.Users;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
    void Register(RegisterRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}

public class UserService : IUserService
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public UserService(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

        if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
        {
            throw new AppException("Username or password is incorrect");
        }
        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = _jwtUtils.GenerateToken(user);
        return response;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User GetById(int id)
    {
        return getUser(id);
    }

    public void Register(RegisterRequest model)
    {
        if (_context.Users.Any(x => x.Username == model.Username))
        {
            throw new AppException("Username '" + model.Username + "' is already taken");
        }
        var user = _mapper.Map<User>(model);
        user.PasswordHash = BCrypt.HashPassword(model.Password);
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateRequest model)
    {
        var user = getUser(id);

        if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
        {
            throw new AppException("Username '" + model.Username + "' is already taken");
        }

        if (!string.IsNullOrEmpty(model.Password))
        {
            user.PasswordHash = BCrypt.HashPassword(model.Password);
        }
        _mapper.Map(model, user);
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = getUser(id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
    private User getUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}