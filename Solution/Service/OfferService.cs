using Microsoft.EntityFrameworkCore;
using Solution.Data;
using Solution.Models;
using Solution.Service;

namespace Solution.Service;

public class OfferService : IOfferService
{
    private readonly ContextDataBase _context;

    public OfferService(ContextDataBase context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Offer>> GetAllOffersAsync()
    {
        return await _context.Offers.ToListAsync();
    }

    public async Task<Offer> GetOfferByIdAsync(int id)
    {
        return await _context.Offers.FirstOrDefaultAsync(o => o.Id == id);
    }
    
    public async Task<Offer> GetOfferWithRelationsAsync(int id)
    {
        return await _context.Offers
            .Include (o => o.OfferUser)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Offer> CreateOfferAsync(Offer offer)
    {
        _context.Offers.Add(offer);
        await _context.SaveChangesAsync();
        return offer;
    }
}