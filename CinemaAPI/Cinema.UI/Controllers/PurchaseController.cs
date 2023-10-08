using Cinema.Domain.Models.DTOs;
using Cinema.Domain.RequestFeatures;
using Cinema.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Cinema.UI.Controllers;

[Route("api/purchase")]
[ApiController]
public class PurchaseController : ControllerBase
{
    private readonly IServiceManager _service;

    public PurchaseController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPurchases([FromQuery] PurchaseParameters purchaseParameters) 
    {
        var pagedResult = await _service.PurchaseService.GetAllAsync(purchaseParameters);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

        return Ok(pagedResult.purchases);
    }

    [HttpGet("user/{userDetailsId:int}")]
    public async Task<IActionResult> GetAllByUserDetailsIdPurchases(int userDetailsId)
    {
        var purchases = await _service.PurchaseService.GetAllByUserDetailsIdAsync(userDetailsId);

        return Ok(purchases);
    }

    [HttpGet("{id:int}", Name = "PurchaseById")]
    public async Task<IActionResult> GetPurchaseByUserIdAsync(int id)
    {
        var purchase = await _service.PurchaseService.GetAsync(id);

        return Ok(purchase);
    }

    [HttpGet("ticket/{id:int}")]
    public async Task<IActionResult> GetTicket(int id)
    {
        var result = await _service.PdfService.GetTicket(id);

        return File(result, "application/pdf", "Ticket.pdf");
    }

    [HttpPost]
    public async Task<IActionResult> AddPurchaseAsync([FromBody] AddPurchaseRequest addPurchaseRequest)
    {
        var createdPurchase = await _service.PurchaseService.AddAsync(addPurchaseRequest);

        return CreatedAtRoute("PurchaseById", new { id = createdPurchase.Id }, createdPurchase);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeletePurchaseAsync(int id)
    {
        await _service.PurchaseService.DeleteAsync(id);

        return NoContent();
    }
}
