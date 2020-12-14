using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CapstoneJesseGajda.Data;
using CapstoneJesseGajda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CapstoneJesseGajda.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        private readonly IUpload _uploadService;
        private readonly IConfiguration _configuration;

        public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService, IUpload uploadService, IConfiguration configuration)
        {
            _userManager = userManager;
            _userService = userService;
            _uploadService = uploadService;
            _configuration = configuration;
        }

        public IActionResult Detail(string id)
        {
            var user = _userService.GetById(id);
            var userRoles = _userManager.GetRolesAsync(user).Result;
            
            var model = new ProfileModel()
            {
                UserId = user.Id,
                UserName = user.NewCustomUsername,
                UserRating = user.Rating.ToString(),
                Email = user.Email,
                ProfileImageUrl = user.ProfileImageUrl,
                IsAdmin = userRoles.Contains("Admin")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfileImage(IFormFile file)
        {
            var userId = _userManager.GetUserId(User);

            //coonect to azure storage account container
            var connectionString = _configuration.GetConnectionString("AzureBlobAccount");
            //get blob container
            var container = _uploadService.GetBlobContainer(connectionString,"profile-images");

            //Parse the content dispostition response header
            var contentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            //grab file name
            var fileName = contentDisposition.FileName.Trim('"');
            //get reference to block blob
            var blockBlob = container.GetBlockBlobReference(fileName);

            //upload our file to block blob
            await blockBlob.UploadFromStreamAsync(file.OpenReadStream());
            //set user profile img to the URI
            await _userService.SetProfileImage(userId, blockBlob.Uri);
            //redirect to the users profile page
            return RedirectToAction("Detail", "Profile", new { id = userId });
        }
    }
}