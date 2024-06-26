﻿using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController : BaseAPIController
{    
    // private readonly DataContext _context;

    // public UsersController(DataContext context)
    // {
    //     this._context = context;
    // }

    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    // [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        // var users = await _context.Users.ToListAsync();
        // return users;
        
        // return Ok(await _userRepository.GetUsersAsync());
        // var users = await _userRepository.GetUsersAsync();
        // var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
        // return Ok(usersToReturn);

        var users = await _userRepository.GetMembersAsync();
        return Ok(users);
        
    }
    
    // [HttpGet("{id}")] //api/users/id
    // public async Task<ActionResult<AppUser>> GetUser(int id) 
    // {
    //     var user = await _context.Users.FindAsync(id);
    //     return user;
    // }

    [HttpGet("{username}")] //api/users/id
    public async Task<ActionResult<MemberDto>> GetUser(string username) 
    {
        // return await _userRepository.GetUserByUsernameAsync(username);
        
        // var user = await _userRepository.GetUserByUsernameAsync(username);
        // return _mapper.Map<MemberDto>(user);

        return await _userRepository.GetMemberAsync(username);
    }
    
}
