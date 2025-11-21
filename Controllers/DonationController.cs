using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc_pets.Models;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using mvc_pets.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace mvc_pets.Controllers
{
    [Authorize]
    public class DonationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DonationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Donation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Donation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Donation donation)
        {
            // Remove ApplicationUserId and User from model validation
            ModelState.Remove("ApplicationUserId");
            ModelState.Remove("User");

            if (ModelState.IsValid)
            {
                // Check if user is logged in
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    // If user is not logged in, show error message
                    ModelState.AddModelError(string.Empty, "يجب تسجيل الدخول لإجراء التبرع.");
                    return View(donation);
                }

                // Link donation to user
                donation.ApplicationUserId = user.Id;
                donation.User = user;
                donation.DonationDate = DateTime.Now;
                donation.Status = "Pending"; // Set default status

                try
                {
                    // Add donation to database
                    _context.Donations.Add(donation);
                    await _context.SaveChangesAsync();

                    // Send notification to user
                    var notification = new Notification
                    {
                        UserId = user.Id,
                        Content = $"Thank you! Your donation of ${donation.Amount} has been received. It will be reviewed by the administration soon.",
                        SendDate = DateTime.Now,
                        IsRead = false
                    };
                    _context.Notifications.Add(notification);
                    await _context.SaveChangesAsync();

                    // Redirect to success page after adding donation
                    return RedirectToAction("Success");
                }
                catch (Exception ex)
                {
                    // If an error occurs while saving the donation
                    ModelState.AddModelError(string.Empty, $"حدث خطأ أثناء حفظ التبرع: {ex.Message}");
                }
            }

            // If data is invalid, show the same page with errors
            return View(donation);
        }

        // عرض صفحة النجاح
        public IActionResult Success()
        {
            return View();
        }

        // GET: Donation/Index
        public IActionResult Index()
        {
            // استرجاع جميع التبرعات من قاعدة البيانات
            var donations = _context.Donations.ToList();
            return View(donations);  // عرض التبرعات في الـ View
        }

        // GET: Donation/Manage
        [Authorize(Roles = "Admin")]
        public IActionResult Manage()
        {
            var donations = _context.Donations
                .OrderByDescending(d => d.DonationDate)
                .ToList();
            return View(donations);
        }

        // POST: Donation/Approve/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Approve(int id)
        {
            var donation = await _context.Donations.FindAsync(id);
            if (donation == null)
            {
                return NotFound();
            }

            donation.Status = "Approved";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Manage));
        }

        // POST: Donation/Reject/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Reject(int id)
        {
            var donation = await _context.Donations.FindAsync(id);
            if (donation == null)
            {
                return NotFound();
            }

            // خصم قيمة التبرع المرفوض من إجمالي التبرعات
            var totalDonations = await _context.Donations
                .Where(d => d.Status == "Approved")
                .SumAsync(d => d.Amount);
            
            // إضافة التبرع المرفوض إلى إجمالي التبرعات المرفوضة
            var rejectedDonations = await _context.Donations
                .Where(d => d.Status == "Rejected")
                .SumAsync(d => d.Amount);
            
            rejectedDonations += donation.Amount;

            // Notify user before deleting
            if (!string.IsNullOrEmpty(donation.ApplicationUserId))
            {
                var notification = new Notification
                {
                    UserId = donation.ApplicationUserId,
                    Content = $"Your donation of ${donation.Amount} has been rejected. Please contact support for more information.",
                    SendDate = DateTime.Now,
                    IsRead = false
                };
                _context.Notifications.Add(notification);
            }

            // تحديث حالة التبرع بدلاً من حذفه
            donation.Status = "Rejected";
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Manage));
        }
    }
}