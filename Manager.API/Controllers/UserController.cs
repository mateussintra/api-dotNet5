using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Manager.Core.Exceptions;
using Manager.API.ViewModels;
using Manager.Services.Interfaces;
using AutoMapper;
using Manager.Services.DTO;
using Manager.API.Utilities;

namespace Manager.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
        
        [HttpPost]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var userCreated = await _userService.Create(userDTO);
                return Ok(new ResultViewModel {
                    Message = "User created successfully!",
                    Success = true,
                    Data = userCreated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Route("/api/v1/users/update")]
        public async Task<IActionResult> Update([FromBody] UpdateViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);
                var userUpdated = await _userService.Update(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "User successfully updated!",
                    Success = true,
                    Data = userUpdated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Route("/api/v1/users/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _userService.Remove(id);

                return Ok(new ResultViewModel
                {
                    Message = "User successfully removed!",
                    Success = true,
                    Data = null
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }
        [HttpGet]
        [Route("/api/v1/users/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var user = await _userService.Get(id);

                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "User not found with id informed!",
                        Success = false,
                        Data = user
                    });

                return Ok(new ResultViewModel
                {
                    Message = "User found successfully!",
                    Success = true,
                    Data = user
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
          
        }
        
        [HttpGet]
        [Route("/api/v1/users/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allUsers = await _userService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "User found successfully!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/users/get-by-email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            try
            {
                var user = await _userService.GetByEmail(email);

                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "User not found with email informed!",
                        Success = true,
                        Data = user
                    });

                return Ok(new ResultViewModel
                {
                    Message = "User found successfully!",
                    Success = true,
                    Data = user
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/user/search-by-name")]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            try
            {
                var allUsers = await _userService.SearchByName(name);

                if (allUsers.Count == 0)
                    return Ok(new ResultViewModel
                    {
                        Message = "User not found with name informed!",
                        Success = true,
                        Data = null
                    });

                return Ok(new ResultViewModel
                {
                    Message = "User found successfully!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1/users/search-by-email")]
        public async Task<IActionResult> SearchByEmail([FromQuery] string email)
        {
            try
            {
                var allUsers = await _userService.SearchByEmail(email);

                if (allUsers.Count == 0)
                    return Ok(new ResultViewModel
                    {
                        Message = "User not found with email informed!",
                        Success = true,
                        Data = allUsers
                    });

                return Ok(new ResultViewModel
                {
                    Message = "User found successfully!",
                    Success = true,
                    Data = allUsers
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }

}
