using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution.Models;
using Solution.Service;

namespace Solution.Controllers
{
    public class YourControllerNameController : Controller
    {
        private readonly IOfferService _offerService;

        public YourControllerNameController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<IActionResult> Index()
        {
            var item = await _offerService.GetAllOffersAsync();
            return View(item);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _offerService.GetOfferByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        private int GetCurrentUserId()
        {
            return User.GetUserId();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Location,Type,BedNumber,BathNumber,NumberOfRooms,Price,Image")] Offer offer)
        {
            // Assigner l'utilisateur connecté (sécurité)
            offer.IdUser = GetCurrentUserId(); 
    
            if (ModelState.IsValid)
            {
                await _offerService.CreateOfferAsync(offer);
                return RedirectToAction(nameof(Index));
            }
            return View(offer);
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var item = await _offerService.GetOfferWithRelationsAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        
        
    }
}