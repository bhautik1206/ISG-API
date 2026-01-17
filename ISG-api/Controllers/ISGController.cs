using ISG_api.Data;
using ISG_api.Models;
using ISG_api.Models.Entities;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static ISG_api.Models.Entities.StoreProcedure;


namespace ISG_api.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ISGController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IDataProtector _protector;
        public ISGController(ApplicationDbContext dbContext,
            IDataProtectionProvider provider)
        {
            this.dbContext = dbContext;
            _protector = provider.CreateProtector("MyPurpose");
        }
        [NonAction]
        public string EncryptData(string plainText)
        {
            return _protector.Protect(plainText);
        }
        [NonAction]
        public string DecryptData(string encryptedData)
        {
            try
            {
                return _protector.Unprotect(encryptedData);
            }
            catch (Exception ex)
            {
                // If decryption fails (e.g., data is tampered or invalid), handle the exception
                return $"Decryption failed: {ex.Message}";
            }
        }
        [HttpPost]
        [Route("add-user")]
        public IActionResult AddOrUpdateUser(UserDTO payload)
        {
            if (payload == null)
            {
                return BadRequest("Payload cannot be null.");
            }

            // Check if the UserID exists in the database
            var existingUser = dbContext.User.FirstOrDefault(u => u.UserID == payload.UserID);

            if (existingUser != null)
            {
                // Update existing user
                existingUser.UserName = payload.UserName;
                existingUser.Email = payload.Email;
                existingUser.Password = EncryptData(payload.Password);
                existingUser.isActive = payload.isActive;
                existingUser.isDelete = payload.isDelete;
                existingUser.UpdateTime = DateTime.Now;

                dbContext.SaveChanges();
                return Ok(new { message = "User updated successfully", user = existingUser });
            }
            else
            {
                    // Add new user
                    var newUser = new User
                    { 
                        UserName = payload.UserName,
                        Email = payload.Email,
                        Password = EncryptData(payload.Password),
                        isActive = payload.isActive,
                        isDelete = payload.isDelete,
                        CreateTime = DateTime.Now,
                        UpdateTime = DateTime.Now
                    };

                    dbContext.User.Add(newUser);
                    dbContext.SaveChanges();
                return Ok(new { message = "User added successfully", user = newUser });
            }
        }

        [HttpPost]
        [Route("add-thread")]
        public async Task<IActionResult> AddThread(ThreadDTO payload)
        {
            try
            {
                if (payload == null)
                {
                    return BadRequest("Payload value is null");
                }

                await dbContext.spAddThread
                    .FromSqlRaw(
                        "CALL spAddThread({0},{1},{2},{3},{4},{5},{6},{7},{8})",
                        payload.ThreadID,
                        payload.UserID,
                        payload.City,
                        payload.RegionID,
                        payload.CountryID,
                        DateTime.UtcNow,
                        payload.Title,
                        payload.Content,
                        payload.UpdateBy
                    )
                    .ToListAsync();

                return Ok("Thread added successfully");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return BadRequest($"Exception error is thrown in spAddThread: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("add-review")]
        public async Task<IActionResult> AddReview(ReviewDTO payload)
        {
            try
            {
                if(payload == null)
                {
                    return BadRequest("Payload is null ");
                }
                await dbContext.spAddReview
             .FromSqlRaw(
                 "CALL spAddReview({0},{1},{2},{3})",
                 payload.UserId,
                 payload.ThreadId,
                 payload.Content,
                 payload.Title
             )
             .ToListAsync();
                return Ok("Review Added Successfully");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return BadRequest($"Exception error is thrown in spAddReview: {ex},{ex.Message}");
            }
        }

        [HttpGet]
        [Route("get-all-thread")]
        public async Task<IActionResult> GetAllThread()
        {
            try
            {
                List<SpGetAllThread_Result> details= await dbContext.spGetAllThread.FromSqlRaw("Call spGetAllThread").ToListAsync();
                return Ok(details);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return BadRequest($"Exception error is throwing in spGetAllThread : {ex}, {ex.Message}");

            }
        }

        [HttpGet]
        [Route("get-all-thread-by-userID/{userID}")]
        public async Task<IActionResult> GetAllThreadByUserID(int userID)
        {
            try
            {
                if (userID == 0)
                {
                    return BadRequest("UserID can't be null or 0");
                }
                bool userExists = await dbContext.User.AnyAsync(u => u.UserID == userID);
                if (!userExists)
                {
                    return NotFound($"User with UserID {userID} does not exist");
                }
                List<SpGetAllThread_Result> details = await dbContext.spGetThreadByUserID.FromSqlRaw("Call spGetThreadByUserID({0})", userID).ToListAsync();
                return Ok(details);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return BadRequest($"Exception error is throwing in spGetThreadByUserID : {ex}, {ex.Message}");

            }
        }
    }

}
